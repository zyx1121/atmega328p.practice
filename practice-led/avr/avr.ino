#include "button.h"
#include "led.h"

void InitMain1(void);
void InitMain2(void);
void InitMain3(void);
void LoopMain1(void);
void LoopMain2(void);
void LoopMain3(void);


void InitMain1(void) {
  led = 0xf0;
}
void LoopMain1(void) {
  if (button[0].status == PRESS) {
    led = (led == 0x0f) ? 0xf0 : 0x0f;
  }
}


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


void setup(void) {
  InitButton();
  InitLED();

  InitMain1();
}


void loop(void) {
  LoopButton();
  LoopLED();

  static uint8_t select = 1;

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
