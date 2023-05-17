//
//  filename    : led.h
//  path        : practice-1/avr/led.h
//  description : led control
//  author      : Loki
//  last update : 2023/05/17 16:44
//

#ifndef _LED_H_
#define _LED_H_

const uint8_t LED_N = 8;
const uint8_t LED_P[] = { 10, 11, 12, 13, A0, A1, A2, A3 };

uint8_t led = 0x00;

void LEDInit(void) {
  for (uint8_t i = 0; i < LED_N; i++)
    pinMode(LED_P[i], OUTPUT);
}

void LEDLoop(void) {
  for (uint8_t i = 0; i < LED_N; i++)
    digitalWrite(LED_P[i], (led >> i) & 1);
}

#endif