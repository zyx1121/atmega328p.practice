#include "rgb.h"
#include "vr.h"


void setup(void) {
  InitRGB();
  InitVR();
}


void loop(void) {
  LoopVR();

  for (uint8_t i = 0; i < 8; i++)
    rgb[i][0] = vr,
    rgb[i][1] = 0,
    rgb[i][2] = 255 - vr;

  LoopRGB();

  FastLED.show();

  delay(1);
}
