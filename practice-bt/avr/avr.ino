#include "led.h"
#include "button.h"
#include "bluetooth.h""

void setup(void) {
  InitButton();
  InitLED();
  InitBluetooth();
}

void loop(void) {
  LoopButton();
  LoopLED();
  LoopBluetooth();

  static uint8_t index = 0;

  if (button[0].status == PRESS)
    index = (index + 1) % 8;

  if (button[1].status == PRESS)
    led = led ^ (1 << index);

  delay(1);
}
