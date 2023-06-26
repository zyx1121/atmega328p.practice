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
//  description : LED and Button control
//  author      : Loki
//

#include "button.h"
#include "led.h"

void InitMain1(void);
void InitMain2(void);
void InitMain3(void);
void LoopMain1(void);
void LoopMain2(void);
void LoopMain3(void);

uint8_t select = 1;

//
//  practice 1
//
void InitMain1(void) {
  led = 0xf0;
}
void LoopMain1(void) {
  if (button[0].status == PRESS) {
    led = (led == 0x0f) ? 0xf0 : 0x0f;
  }
}

//
//  practice 1
//
void InitMain2(void) {
  led = 0x00;
}
void LoopMain2(void) {
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
//  practice 1
//
void InitMain3(void) {
  led = 0x01;
}
void LoopMain3(void) {
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
  InitButton();
  InitLED();

  InitMain1();
}

//
//  loop
//
void loop(void) {
  LoopButton();
  LoopLED();

  if (button[1].status == RELEASE) {
    select = (select == 3) ? 1 : select + 1;
    switch (select) {
      case 1: InitMain1(); break;
      case 2: InitMain2(); break;
      case 3: InitMain3(); break;
      default: break;
    }
  }

  switch (select) {
    case 1: LoopMain1(); break;
    case 2: LoopMain2(); break;
    case 3: LoopMain3(); break;
    default: break;
  }

  delay(1);
}
