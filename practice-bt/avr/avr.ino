//  filename    : avr.ino
//  description : AVR practice BT
//  author      : Loki
//

#include "bluetooth.h"
#include "button.h"
#include "led.h"

//
//  practice select
//
const uint8_t select = 3;

void MainInit1(void);
void MainLoop1(void);
void MainInit2(void);
void MainLoop2(void);
void MainInit3(void);
void MainLoop3(void);
void setup(void);
void loop(void);

//
//  practice 1-1
//
void MainInit1(void) {
  led = 0x00;
}
void MainLoop1(void) {
  static uint16_t timeCounter = 0;
  static uint8_t  ledCounter = 5;

  if (button[0].status == PRESS) {
    led = 0xff;
    ledCounter = 0;
  }

  if (ledCounter < 5) {
    if (++timeCounter == 500) {
      led = ~led;
      timeCounter = 0;
      ledCounter++;
    }
  }
}

//
//  practice 1-2
//
void MainInit2(void) {
  led = 0xf0;
}
void MainLoop2(void) {
  if (button[0].status == PRESS) {
    led = (led == 0x0f) ? 0xf0 : 0x0f;
  }
}

//
//  practice 1-3
//
void MainInit3(void) {
  led = 0x01;
}
void MainLoop3(void) {
  static uint8_t timeCounter = 0;

  if (++timeCounter == 255) {
    if (button[0].status == IDLE) {
      led = (led == 0x80) ? 0x01 : led << 1;
    } else
    if (button[0].status == HOLD) {
      led = (led == 0x01) ? 0x80 : led >> 1;
    }
  }
}

//
//  setup
//
void setup(void) {
  BluetoothInit();
  ButtonInit();
  LEDInit();

  switch (select) {
    case 1: MainInit1(); break;
    case 2: MainInit2(); break;
    case 3: MainInit3(); break;
    default: break;
  }
}

//
//  loop
//
void loop(void) {
  BluetoothLoop();
  ButtonLoop();
  LEDLoop();

  switch (select) {
    case 1: MainLoop1(); break;
    case 2: MainLoop2(); break;
    case 3: MainLoop3(); break;
    default: break;
  }

  delay(1);
}
