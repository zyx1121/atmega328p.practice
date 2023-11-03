#include <EEPROM.h>
#include <FastLED.h>
#include <SoftwareSerial.h>
#include <Wire.h>

volatile uint8_t eepromNum[4];

#include "bluetooth.h"
#include "button.h"
#include "display.h"

void mainLoop() {
  static uint8_t ledStatus = 0;
  static uint8_t ledOffset = 0;
  static uint8_t timeOffset = 0;

  uint8_t i;

  if (button.status[0] == press) {
    if (++ledStatus == 3) ledStatus = 0;
    display.led = 0b00000000;
    ledOffset = 0;
  }

  if (ledStatus != 0) {
    if (++timeOffset == 100) {
      timeOffset = 0;
      if (ledOffset < 8) {
        if (ledStatus == 1)
          display.led |= 0b00000001 << ledOffset;
        else
          display.led |= 0b10000000 >> ledOffset;
        ledOffset++;
      }
    }
  }

  if (button.status[1] == press) {
    display.led = 0b00000000;
    ledStatus = 0;
    for (i = 0; i < 4; i++) eepromNum[i] = EEPROM.read(i);
    display.led = (eepromNum[1] << 4) | (eepromNum[0] << 0);
  }

  for (i = 0; i < 8; i++) display.SetRGB(i, 0, button.vr[0], 255 - button.vr[0]);
  FastLED.show();
}

void setup() {
  bluetooth.Init();
  button.Init();
  display.Init();

  uint8_t i;

  for (i = 0; i < 4; i++) eepromNum[i] = EEPROM.read(i);

  for (i = 0; i < 8; i++) display.SetRGB(i, 0, 0, 0);
  FastLED.show();
}

void loop() {
  mainLoop();
  button.Loop();
  display.Loop();

  // each 20 ms to check bluetooth.
  static uint8_t btOffset = 0;
  if (++btOffset == 20) {
    btOffset = 0;
    bluetooth.Send();
    bluetooth.Receive();
  }

  delay(1);
}
