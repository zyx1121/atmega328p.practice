#ifndef _L7S_H_
#define _L7S_H_

const uint8_t LATCH_P  = 6;
const uint8_t CLOCK_P  = 7;
const uint8_t DATA_P   = 5;

const uint8_t SCAN_N   = 4;
const uint8_t SCAN_P[] = { 8, 9, 10, 11 };

const uint8_t L7S_TABLE[] = { 0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07, 0x7f, 0x6f, 0x77, 0x7c, 0x39, 0x5e, 0x79, 0x71 };

typedef struct l7s_s {
  uint8_t number;
  bool    dot;
} l7s_t;

l7s_t l7s[SCAN_N];

void InitL7S(void) {
  uint8_t i;

  pinMode(LATCH_P, OUTPUT);
  pinMode(CLOCK_P, OUTPUT);
  pinMode(DATA_P,  OUTPUT);

  for (i = 0; i < SCAN_N; i++) {
    pinMode(SCAN_P[i], OUTPUT);
    digitalWrite(SCAN_P[i], LOW);
  }

  for (i = 0; i < SCAN_N; i++) {
    l7s[i].number = 0;
    l7s[i].dot = false;
  }
}

void LoopL7S(void) {
  static uint8_t scan = 4;
  uint8_t i;

  digitalWrite(SCAN_P[scan], HIGH);

  scan = (scan + 1) % SCAN_N;

  digitalWrite(LATCH_P, LOW);
  shiftOut(DATA_P, CLOCK_P, MSBFIRST, L7S_TABLE[l7s[scan].number] | (l7s[scan].dot << 7));
  digitalWrite(LATCH_P, HIGH);

  digitalWrite(SCAN_P[scan], LOW);
}

#endif