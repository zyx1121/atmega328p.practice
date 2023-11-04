#ifndef _BUTTON_H_
#define _BUTTON_H_

const uint8_t BTNS_N = 2;
const uint8_t BTNS_P[] = {2, 3};

enum status_e {
  IDLE,
  PRESS,
  HOLD,
  RELEASE
};

typedef struct button_s {
  uint8_t status;
  uint64_t holdStart;
  uint64_t holdTime;
} button_t;

button_t button[BTNS_N];

void InitButton(void) {
  uint8_t i;

  for (i = 0; i < BTNS_N; i++)
    pinMode(BTNS_P[i], INPUT);
}

void LoopButton(void) {
  uint8_t i, read;

  for (i = 0; i < BTNS_N; i++) {
    read = digitalRead(BTNS_P[i]);

    switch (button[i].status) {
      case IDLE:
        button[i].status = read ? button[i].status : PRESS;
        break;

      case PRESS:
        button[i].status = HOLD;
        button[i].holdStart = millis();
        break;

      case HOLD:
        button[i].status = read ? RELEASE : button[i].status;
        button[i].holdTime = millis() - button[i].holdStart;
        break;

      case RELEASE:
        button[i].status = IDLE;
        button[i].holdTime = 0;
        break;
    }
  }
}

#endif