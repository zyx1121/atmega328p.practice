#include "led.h"
#include "time.h"
#include "button.h"
#include "bluetooth.h"
#include "oled.h"

volatile uint8_t mode = 1;

static uint64_t preMillis = millis();
static uint64_t preMillis1 = millis();
// oled display example
void Loop1(void) {
  char buffer[32];
  // sprintf(buffer, "%02u:%02u:%02u, %u.%u", time.hour, time.minute, time.second, time.tempInt, time.tempFloat);
  sprintf(buffer, "%u%u%u%u", 1 * (button[0].status != IDLE ? 1 : 0),
            1 * (button[1].status != IDLE ? 1 : 0),
            1 * (button[2].status != IDLE ? 1 : 0),
            1 * (button[3].status != IDLE ? 1 : 0));
  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print(buffer);
  oled.display();

  static uint8_t flag = 0;

  // if ((millis() - time.millis) % 100) {
  //   flag = (ledPWM == 9 || ledPWM == 0) ? !flag : flag;
  //   ledPWM = flag ? ledPWM - 1 : ledPWM + 1;
  // }

  if (millis() >= preMillis1 + 25) {
    preMillis1 = millis();
    flag = (ledPWM == 9 || ledPWM == 0) ? !flag : flag;
    ledPWM = flag ? ledPWM - 1 : ledPWM + 1;
  }
  //ledPWM = map(time.second,0,60,0,16);

  // if (button[0].status == RELEASE) preMillis = millis(), mode = 2;
  // if (button[1].status == RELEASE) preMillis = millis(), mode = 3;
  // if (button[2].status == RELEASE) preMillis = millis(), mode = 4;
  // if (button[0].status == HOLD && button[2].status == HOLD && button[0].holdTime >= 500 && button[2].holdTime >= 500)
  //   preMillis = millis(), mode = 5;
}

void Init2(void) {
}

void Loop2(void) {
  if (millis() >= preMillis + 1000) mode = 1;

  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print("btn1");
  oled.display();
}

void Init3(void) {
}

void Loop3(void) {
  if (millis() >= preMillis + 1000) mode = 1;
  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print("btn2");
  oled.display();
}

void Loop4(void) {
  if (millis() >= preMillis + 1000) mode = 1;
  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print("btn3");
  oled.display();
}

void Loop5(void) {
  if (millis() >= preMillis + 2000) mode = 1;
  oled.clearDisplay();
  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print("btn1 and btn3");
  oled.display();
}

void setup(void) {
  InitLED();
  InitBluetooth();
  InitButton();
  InitOLED();
  InitTime();
}

//0b1100110

void loop(void) {
  LoopLED();
  LoopBluetooth();
  LoopButton();
  LoopOLED();
  LoopTime();

  switch (mode) {
    case 0:
      static uint64_t preMillis = millis();
      if (millis() >= preMillis + 2000) mode = 1;
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

    case 4:
      Loop4();
      break;

    case 5:
      Loop5();
      break;

    default:
      break;
  }

  delay(1);
}
