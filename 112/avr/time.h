#ifndef _TIME_H_
#define _TIME_H_

#include <Wire.h>

#include "RTClib.h"

typedef struct time_s {
  DateTime now;
  uint64_t millis;
  uint8_t second;
  uint8_t minute;
  uint8_t hour;
  uint8_t day;
  uint8_t month;
  uint16_t year;
  uint8_t tempInt;
  uint8_t tempFloat;
  bool half;
  bool quarter;
  bool eighth;
  bool deci;
} time_t;

RTC_DS3231 rtc;
time_t time = {{23, 11, 21, 0, 0, 0}, millis(), 0, 0, 0, 0, 0, 0, 0, 0, false, false, false, false};

void InitTime(void) {
  rtc.begin();
}

void LoopTime(void) {
  static uint64_t preMillis = millis();
  static uint8_t preSec = time.now.second();

  if (millis() - preMillis >= 100) {
    preMillis = millis();
    time.now = rtc.now();
    time.second = time.now.second();
    time.minute = time.now.minute();
    time.hour = time.now.hour();
    time.day = time.now.day();
    time.month = time.now.month();
    time.year = time.now.year();
    time.tempInt = rtc.getTemperature() / 1;
    time.tempFloat = ((uint8_t)((rtc.getTemperature() * 100) / 1)) % 100;
  }

  if (preSec != time.now.second()) {
    preSec = time.now.second();
    time.millis = millis();
  }

  time.half = ((millis() - time.millis) / 500) & 1 ? false : true;
  time.quarter = ((millis() - time.millis) / 250) & 1 ? false : true;
  time.eighth = ((millis() - time.millis) / 125) & 1 ? false : true;
  time.deci = ((millis() - time.millis) / 100) & 1 ? false : true;
}

#endif