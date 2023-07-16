#ifndef _LED_H_
#define _LED_H_

const uint8_t LED_N = 8;
const uint8_t LED_P[] = { 5, 6, 7, 8, 9, 10, 11, 12 };

uint8_t led = 0x00;

void InitLED(void) {
  for (uint8_t i = 0; i < LED_N; i++)
    pinMode(LED_P[i], OUTPUT);
}

void LoopLED(void) {
  for (uint8_t i = 0; i < LED_N; i++)
    digitalWrite(LED_P[i], (led >> i) & 1);
}

#endif