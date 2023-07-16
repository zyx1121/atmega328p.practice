#ifndef _TIME_H_
#define _TIME_H_

typedef struct time_s {
  uint8_t hour;
  uint8_t minute;
  uint8_t second;
  uint16_t millisecond;

  bool half;
  bool quarter;
} time_t;

time_t time = {0, 0, 0, 0, false, false};

void InitTime(void) {
  time = (time_t){0, 0, 0, 0, false, false};
}

void LoopTime(void) {
  if (++time.millisecond >= 1000) {
    time.millisecond = 0;
    time.second++;
  }
  if (time.second >= 60) {
    time.second = 0;
    time.minute++;
  }
  if (time.minute >= 60) {
    time.minute = 0;
    time.hour++;
  }
  if (time.hour >= 24) {
    time.hour = 0;
  }

  time.half    = ((time.millisecond / 500) & 1) ? false : true;
  time.quarter = ((time.millisecond / 250) & 1) ? false : true;
}

#endif