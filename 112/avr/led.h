#ifndef _LED_H_
#define _LED_H_

const uint8_t LATCH_P = 8;
const uint8_t CLOCK_P = 12;
const uint8_t DATA_P = 11;
const uint8_t LED_P = 9;

uint8_t led = 0x00;
uint8_t one = 0x00;

void InitLED(void) {
  pinMode(LATCH_P, OUTPUT);
  pinMode(CLOCK_P, OUTPUT);
  pinMode(DATA_P, OUTPUT);
  pinMode(LED_P, OUTPUT);
}

void LoopLED(void) {
  digitalWrite(LATCH_P, LOW);
  shiftOut(DATA_P, CLOCK_P, LSBFIRST, led);
  digitalWrite(LATCH_P, HIGH);

  digitalWrite(LED_P, one);
  // analogWrite(LED_P, one);
}

#endif