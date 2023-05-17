#ifndef _TIMER_H_
#define _TIMER_H_

struct timer_s {
  uint16_t millis;
  uint8_t  second;
  uint8_t  minute;
  uint8_t  hour;
  uint8_t  isHalf;
  uint8_t  isQuarter;
};

timer_s timer;

void TimerInit(void) {
  timer.millis = 0;
  timer.second = 0;
  timer.minute = 0;
  timer.hour   = 0;
}

void TimerLoop(void) {
  if (++timer.millis == 1000) {
    timer.millis = 0;
    if (++timer.second == 60) {
      timer.second = 0;
      if (++timer.minute == 60) {
        timer.minute = 0;
        if (++timer.hour == 24) {
          timer.hour = 0;
        }
      }
    }
  }
  timer.isHalf    = (timer.millis % 500 == 0) ? 1 : 0;
  timer.isQuarter = (timer.millis % 250 == 0) ? 1 : 0;
}

#endif