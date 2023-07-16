#include "button.h"
#include "l7s.h"
#include "time.h"

uint8_t mode = 0;

void ModeClock(void) {
  static uint8_t isHM = 0;

  l7s[0].number = (isHM) ? time.minute % 10 : time.second % 10;
  l7s[1].number = (isHM) ? time.minute / 10 : time.second / 10;
  l7s[2].number = (isHM) ? time.hour   % 10 : time.minute % 10;
  l7s[3].number = (isHM) ? time.hour   / 10 : time.minute / 10;

  l7s[0].dot = false;
  l7s[1].dot = false;
  l7s[2].dot = time.half;
  l7s[3].dot = false;

  if (button[0].status == PRESS)
    isHM = !isHM;

  if (button[1].status == PRESS)
    mode = 1;

  if (button[1].status == HOLD && button[0].status == PRESS)
    mode = 2;
}

void ModeTimer(void) {
  static time_t  timer  = {0, 0, 0, 0, false, false};
  static uint8_t isStop = 1;

  l7s[0].number = timer.millisecond / 100;
  l7s[1].number = timer.second % 10;
  l7s[2].number = timer.second / 10;
  l7s[3].number = timer.minute % 10;

  l7s[0].dot = false;
  l7s[1].dot = (isStop) ? true : timer.quarter;
  l7s[2].dot = false;
  l7s[3].dot = (isStop) ? true : timer.quarter;

  if (!isStop) {
    if (++timer.millisecond >= 1000) {
      timer.millisecond = 0;
      timer.second++;
    }
    if (timer.second >= 60) {
      timer.second = 0;
      timer.minute++;
    }
    if (timer.minute >= 60) {
      timer.second = 0;
      timer.minute++;
    }
    timer.quarter = ((timer.millisecond / 250) & 1) ? false : true;
  }

  if (button[0].status == PRESS)
    isStop = !isStop;

  if (button[0].status == HOLD && button[0].holdTime >= 1000)
    timer = (time_t){0, 0, 0, 0, false, false};

  if (button[1].status == PRESS)
    mode = 0;

  if (button[1].status == HOLD && button[0].status == PRESS)
    mode = 2;
}

void ModeSetting(void) {
  static uint8_t select = 0;

  l7s[0].number = (select == 2) ? time.minute % 10 : time.second % 10;
  l7s[1].number = (select == 2) ? time.minute / 10 : time.second / 10;
  l7s[2].number = (select == 2) ? time.hour   % 10 : time.minute % 10;
  l7s[3].number = (select == 2) ? time.hour   / 10 : time.minute / 10;

  for (uint8_t i = 0; i < 4; i++)
    l7s[i].dot = (i == select) ? true : false;

  if (button[0].status == PRESS || (button[0].status == HOLD && button[0].holdTime >= 1000)) {
    if (button[0].status == HOLD)
      button[0].holdTime = 900;
    switch (select) {
      case 0 : time.second = (time.second + 1) % 60; break;
      case 1 : time.minute = (time.minute + 1) % 60; break;
      case 2 : time.hour   = (time.hour   + 1) % 24; break;
    }
  }

  if (button[1].status == PRESS) {
    select = (select + 1) % 3;
    if (select == 0) {
      time.millisecond = 0;
      mode = 0;
    }
  }
}

//
//  setup
//
void setup(void) {
  InitButton();
  InitL7S();
  InitTime();
}

//
//  loop
//
void loop(void) {
  LoopButton();
  LoopL7S();
  if (mode != 2) LoopTime();

  switch (mode) {
    case 0: ModeClock(); break;
    case 1: ModeTimer(); break;
    case 2: ModeSetting(); break;
  }

  delay(1);
}
