//
//  filename    : button.h
//  path        : practice-bt/avr/button.h
//  description : button control (mouseDown)
//  author      : Loki
//  last update : 2023/05/29 18:17
//

#ifndef _BUTTON_H_
#define _BUTTON_H_

const uint8_t BTNS_N   = 1 ;
const uint8_t BTNS_P[] = { 7 } ;

enum status_e { IDLE, PRESS, HOLD, RELEASE };

struct button_s { uint16_t holdTime; uint8_t  status; bool mouseDown; };

button_s button[BTNS_N];

void ButtonInit(void) {
  uint8_t i;
  for (i = 0; i < BTNS_N; i++) pinMode(BTNS_P[i], INPUT);
}

void ButtonLoop(void) {
  uint8_t i, buttonDown;

  for (i = 0; i < BTNS_N; i++) {
    buttonDown = !digitalRead(BTNS_P[i]);
    switch(button[i].status) {
      // IDLE
      case IDLE : {
        button[i].status = (buttonDown || button[i].mouseDown) ? PRESS : button[i].status;
        break;
      }
      // PRESS
      case PRESS: {
        button[i].status = HOLD;
        break;
      }
      // HOLD
      case HOLD: {
        button[i].status = (buttonDown || button[i].mouseDown) ? button[i].status : RELEASE;
        button[i].holdTime = (buttonDown || button[i].mouseDown) ? button[i].holdTime + 1 : 0;
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