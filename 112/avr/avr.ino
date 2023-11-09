#include "bluetooth.h"
#include "button.h"
#include "oled.h"
#include "time.h"

volatile uint8_t mode = 0;

// oled display example
void Loop1(void) {
  char buffer[32];
  sprintf(buffer, "%02u:%02u:%02u", time.hour, time.minute, time.second);

  oled.setTextColor(WHITE);
  oled.setCursor(0, 0);
  oled.setTextSize(1);
  oled.print(buffer);
}

void Init2(void) {
}

void Loop2(void) {
}

void Init3(void) {
}

void Loop3(void) {
}

void setup(void) {
  InitBluetooth();
  InitButton();
  InitOLED();
  InitTime();
}

void loop(void) {
  LoopBluetooth();
  LoopButton();
  LoopOLED();
  LoopTime();

  // button control example
  if (button[0].status == HOLD && button[1].status == HOLD &&
      button[0].holdTime >= 1000 && button[1].holdTime >= 1000) {
    mode = ++mode % 4;
  }

  static uint64_t preMillis = millis();
  if (millis() - preMillis >= 10) {
    preMillis = millis();

    switch (mode) {
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
  }
}
