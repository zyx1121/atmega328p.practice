//  ┌────────────────────────────────────────────┐
//  │  ATMega328P                                │
//  │                 ┌────────┐                 │
//  │           [RST] │01    28│ A5              │
//  │           [RXD] │02    27│ A4              │
//  │           [TXD] │03    26│ A3    (LED7)    │
//  │               2 │04    25│ A2    (LED6)    │
//  │              ~3 │05    24│ A1    (LED5)    │
//  │               4 │06    23│ A0    (LED4)    │
//  │           [VCC] │07    22│ [GND]           │
//  │           [GND] │08    21│ [AREF]          │
//  │          [XTAL] │09    20│ [VCC]           │
//  │          [XTAL] │10    19│ 13    (LED3)    │
//  │              ~5 │11    18│ 12    (LED2)    │
//  │              ~6 │12    17│ 11~   (LED1)    │
//  │    (BTN0)     7 │13    16│ 10~   (LED0)    │
//  │               8 │14    15│ 9~              │
//  │                 └────────┘                 │
//  └────────────────────────────────────────────┘
//
//  filename    : avr.ino
//  path        : practice-1/avr/avr.ino
//  description : LED and Button control
//  author      : Loki
//  last update : 2023/06/26 11:42
//

#include "button.h"
#include "led.h"

void MainInit1(void);
void MainInit2(void);
void MainInit3(void);
void MainLoop1(void);
void MainLoop2(void);
void MainLoop3(void);

uint8_t select = 1;

//
//  practice 1-1
//
void MainInit1(void) {
  led = 0xf0;
}
void MainLoop1(void) {
  if (button[0].status == PRESS) {
    led = (led == 0x0f) ? 0xf0 : 0x0f;
  }
}

//
//  practice 1-2
//
void MainInit2(void) {
  led = 0x00;
}
void MainLoop2(void) {
  static uint16_t timeCounter = 0;

  if (button[0].status == HOLD) {
    led = 0xff;
    timeCounter = 0;
  }

  if (++timeCounter >= 500) {
    led = ~led;
    timeCounter = 0;
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
  ButtonInit();
  LEDInit();

  MainInit1();
}

//
//  loop
//
void loop(void) {
  ButtonLoop();
  LEDLoop();

  if (button[1].status == RELEASE) {
    select = (select == 3) ? 1 : select + 1;
    switch (select) {
      case 1: MainInit1(); break;
      case 2: MainInit2(); break;
      case 3: MainInit3(); break;
      default: break;
    }
  }

  switch (select) {
    case 1: MainLoop1(); break;
    case 2: MainLoop2(); break;
    case 3: MainLoop3(); break;
    default: break;
  }

  delay(1);
}
