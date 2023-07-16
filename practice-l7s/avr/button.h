#ifndef _BUTTON_H_
#define _BUTTON_H_

const uint8_t BTNS_N   = 2 ;
const uint8_t BTNS_P[] = { 12, 13 } ;

enum status_e { IDLE, PRESS, HOLD, RELEASE };

struct button_s { uint16_t holdTime; uint8_t  status; };

button_s button[BTNS_N];

void InitButton(void) {
  uint8_t i;
  for (i = 0; i < BTNS_N; i++) pinMode(BTNS_P[i], INPUT);
}

void LoopButton(void) {
  uint8_t i, btnRead;

  for (i = 0; i < BTNS_N; i++) {
    btnRead = digitalRead(BTNS_P[i]);
    switch(button[i].status) {
      // IDLE
      case IDLE : {
        button[i].status = btnRead ? button[i].status : PRESS ;
        break;
      }
      // PRESS
      case PRESS: {
        button[i].status = HOLD;
        break;
      }
      // HOLD
      case HOLD: {
        button[i].status = btnRead ? RELEASE : button[i].status;
        button[i].holdTime = btnRead ? 0 : button[i].holdTime + 1;
        break;
      }
      // RELEASE
      case RELEASE: {
        button[i].status = IDLE;
        break;
      }
    }
  }
}

#endif