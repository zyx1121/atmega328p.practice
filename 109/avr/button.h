#ifndef _BUTTON_H_
#define _BUTTON_H_

// Button
const uint8_t BTNS_P[] = {A2, A3};
const uint8_t BTNS_N = 2;

// VR
const uint8_t VR_P = A4;

enum status_e {
  idle,
  press,
  hold,
  release,
};

class CButton {
 public:
  void Init();
  void Loop();

  uint8_t status[BTNS_N];
  uint8_t time[BTNS_N];
  uint8_t buttonDown[BTNS_N];
  uint8_t mouseDown[BTNS_N];

  uint8_t vr[8];
} button;

void CButton::Init() {
  uint8_t i;

  // INPUT, INPUT_PULLUP
  for (i = 0; i < BTNS_N; i++) pinMode(BTNS_P[i], INPUT);
}

void CButton::Loop(void) {
  uint16_t vrRead;
  uint8_t btnRead;
  uint8_t i;

  vrRead = analogRead(VR_P);
  vr[0] = map(vrRead, 0, 1023, 0, 255);

  for (i = 0; i < BTNS_N; i++) {
    btnRead = digitalRead(BTNS_P[i]);
    switch (status[i]) {
      // IDLE
      case idle: {
        if (btnRead == 0 || mouseDown[i] == 1) {
          mouseDown[i] = 0;
          status[i] = press;
        }
        break;
      }
      // PRESS
      case press: {
        status[i] = hold;
        break;
      }
      // HOLD
      case hold: {
        if (btnRead == 1)
          status[i] = release;
        else if (time[i] < 5000)
          time[i]++;
        break;
      }
      // RELEASE
      case release: {
        status[i] = idle;
        time[i] = 0;
        break;
      }
    }
  }
}

#endif
