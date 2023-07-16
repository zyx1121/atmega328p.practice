#ifndef _RGB_H_
#define _RGB_H_

#include <FastLED.h>

const uint8_t RGB_P = 8;
const uint8_t RGB_N = 8;

uint8_t rgb[8][3];
CRGB    RGB_DATA[8];

void InitRGB(void) {
  FastLED.addLeds<WS2812, RGB_P, GRB>(RGB_DATA, RGB_N);
  FastLED.setBrightness(32);
}

void LoopRGB(void) {
  for (uint8_t i = 0; i < RGB_N; i++)
    RGB_DATA[i] = CRGB(rgb[i][0], rgb[i][1], rgb[i][2]);
}

#endif