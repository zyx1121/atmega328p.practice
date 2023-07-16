#ifndef _VR_H_
#define _VR_H_

const uint8_t VR_P = A4;

uint8_t vr;

void InitVR(void) {
  pinMode(VR_P, INPUT);
}

void LoopVR(void) {
  vr = map(analogRead(VR_P), 0, 1023, 0, 255);
}

#endif