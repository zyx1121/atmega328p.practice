#ifndef _DISPLAY_H_
#define _DISPLAY_H_

// 74HC595
const uint8_t LATCH_P = 6;
const uint8_t CLOCK_P = 7;
const uint8_t DATA_P = 5;

// RGB
const uint8_t RGB_P = 8;
const uint8_t RGB_N = 8;

class CDisplay {
 public:
  void Init();
  void Loop();
  void SetRGB(uint8_t i, uint8_t r, uint8_t g, uint8_t b);

  uint8_t led;
  uint8_t rgbData[8][3];
  CRGB rgb[8];
} display;

void CDisplay::SetRGB(uint8_t i, uint8_t r, uint8_t g, uint8_t b) {
  display.rgbData[i][0] = r;
  display.rgbData[i][1] = g;
  display.rgbData[i][2] = b;
  display.rgb[i] = CRGB(r, g, b);
}

void CDisplay::Init() {
  uint8_t i;

  pinMode(LATCH_P, 1);
  pinMode(CLOCK_P, 1);
  pinMode(DATA_P, 1);

  // RGB
  FastLED.addLeds<WS2812, RGB_P, GRB>(rgb, RGB_N);
  FastLED.setBrightness(32);
}

void CDisplay::Loop() {
  digitalWrite(LATCH_P, LOW);
  shiftOut(DATA_P, CLOCK_P, MSBFIRST, led);
  digitalWrite(LATCH_P, HIGH);
}

#endif
