#ifndef _LED_H_
#define _LED_H_

const uint8_t LATCH_P  = 8;
const uint8_t CLOCK_P  = 12;
const uint8_t DATA_P   = 11;

const uint8_t LED_P = 9;

uint8_t led = 0x00;

bool ledOne = false;
uint8_t ledPWM = 0x01;

void InitLED(void) {
  pinMode(LATCH_P, OUTPUT);
  pinMode(CLOCK_P, OUTPUT);  
  pinMode(DATA_P, OUTPUT);
  pinMode(LED_P, OUTPUT);
}


void LoopLED(void) {
  //for (uint8_t i = 0; i < LED_N; i++)
    //digitalWrite(LED_P[i], (led >> i) & 1);

  
  // digitalWrite(LATCH_P, LOW);
  // shiftOut(DATA_P, CLOCK_P, LSBFIRST, led + (256 * (led & 1)));
  // digitalWrite(LATCH_P, HIGH);

  digitalWrite(LATCH_P, LOW);
  shiftOut(DATA_P, CLOCK_P, LSBFIRST, led);
  digitalWrite(LATCH_P, HIGH);

  // digitalWrite(LED_P, ledOne);
  analogWrite(LED_P, ledPWM);
}

#endif
// 7654321