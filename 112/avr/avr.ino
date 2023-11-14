#include "button.h"
#include "led.h"
#include "oled.h"
#include "time.h"

volatile uint8_t state = 0;

#include "bluetooth.h"

uint64_t preMillis = millis();

void Loop(void) {
  one = time.quarter;

  if (button[3].status == HOLD && button[3].holdTime >= 1000) Init2();
}

// 顯示時間（hh:mm:ss）
void Loop0(void) {
  char buffer[32];

  if (time.half) {
    sprintf(buffer, "%04u-%02u-%02u, %02u:%02u:%02u", time.year, time.month, time.day, time.hour, time.minute, time.second);
  } else {
    sprintf(buffer, "%04u-%02u-%02u, %02u %02u %02u", time.year, time.month, time.day, time.hour, time.minute, time.second);
  }

  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print(buffer);

  if (button[0].status == PRESS) state = 1;
}

// 顯示溫度（xx.xx）
void Loop1(void) {
  char buffer[32];

  sprintf(buffer, "%u.%u", time.tempInt, time.tempFloat);

  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print(buffer);
  oled.display();

  if (button[0].status == PRESS) state = 0;
}

// 設定時間（hh:mm:ss）
time_t set;
void Init2(void) {
  DateTime now = rtc.now();
  set.year = now.year();
  set.month = now.month();
  set.day = now.day();
  set.hour = now.hour();
  set.minute = now.minute();
  set.second = now.second();

  state = 2;
}
void Loop2(void) {
  static uint8_t index = 0;
  char buffer[32];

  if (time.quarter) {
    sprintf(buffer, "%02u:%02u:%02u", set.hour, set.minute, set.second);
  } else {
    sprintf(buffer, "%02u %02u %02u", set.hour, set.minute, set.second);
  }

  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print(buffer);

  // 確認更改
  if (button[0].status == PRESS) {
    if (++index >= 3) {
      rtc.adjust((DateTime){set.year, set.month, set.day, set.hour, set.minute, set.second});
      index = 0;
      state = 0;
    }
  }

  // 設定值增加
  if (button[1].status == PRESS || (button[1].status == HOLD && button[1].holdTime >= 1000)) {
    if (button[1].status == HOLD) button[1].holdTime -= 125;
    switch (index) {
      case 0:
        set.second = (set.second + 1) % 60;
        break;

      case 1:
        set.minute = (set.minute + 1) % 60;
        break;

      case 2:
        set.hour = (set.hour + 1) % 24;
        break;

      default:
        break;
    }
  }

  // 設定值減少
  if (button[2].status == PRESS || (button[2].status == HOLD && button[2].holdTime >= 1000)) {
    if (button[2].status == HOLD) button[2].holdTime -= 125;
    switch (index) {
      case 0:
        set.second = (set.second + 59) % 60;
        break;

      case 1:
        set.minute = (set.minute + 59) % 60;
        break;

      case 2:
        set.hour = (set.hour + 23) % 24;
        break;

      default:
        break;
    }
  }

  // 離開設定
  if (button[3].status == PRESS) {
    state = 0;
  }
}

void Loop3(void) {
}

void setup(void) {
  InitLED();
  InitBluetooth();
  InitButton();
  InitOLED();
  InitTime();
}

void loop(void) {
  LoopLED();
  LoopBluetooth();
  LoopButton();
  LoopOLED();
  LoopTime();

  Loop();

  switch (state) {
    case 0:
      Loop0();
      break;

    case 1:
      Loop1();
      break;

    case 2:
      Loop2();
      break;

    case 3:
      Loop3();
      break;

    default:
      break;
  }

  delay(1);
}
