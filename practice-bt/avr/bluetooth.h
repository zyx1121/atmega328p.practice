//
//  filename    : bluetooth.h
//  path        : practice-bt/avr/bluetooth.h
//  description : bluetooth control
//  author      : Loki
//  last update : 2023/05/29 18:17
//

#ifndef _BLUETOOTH_H_
#define _BLUETOOTH_H_

char    buffer[3] ;

uint8_t change;
uint8_t pre_led;
uint8_t pre_button[BTNS_N];

// CMD0 CMD1 DATA
// [A]  [a]  01010101
void BluetoothRead(void) {
  Serial.readBytes(buffer, 3);

  uint8_t data = buffer[2];
  char    cmd0 = buffer[0];
  char    cmd1 = buffer[1];

  switch (cmd0) {
    case 'A' : {
      switch (cmd1) {
        case 'a' : led = led ^ data; break;
        case 'b' : led = 0b01010101; break;
        case 'c' : led = 0b10101010; break;
        case 'd' : led = 0b11110000; break;
        case 'e' : led = 0b00001111; break;
      }
      break;
    }
    case 'B' : {
      switch (cmd1) {
        case 'a' : button[0].mouseDown = data; break;
        case 'b' : button[1].mouseDown = data; break;
        case 'c' : button[2].mouseDown = data; break;
      }
      break;
    }
    case 'C' : {

      break;
    }
    case 'D' : {

      break;
    }
  }
}

// CMD0 DATA
// [A]  00000000
void BluetoothWrite(void) {
  uint8_t i, data = 0;

  if (change & 0b00000001) {
    Serial.write('A');
    Serial.write(led);
  }

  if (change & 0b00000010) {
    Serial.write('B');
    for (i = 0; i < BTNS_N; i++)
      data += (button[i].status & 1) << i;
    Serial.write(data);
  }
}

void BluetoothCheck(void) {
  uint8_t i;

  change = 0b00000000;

  // check led if change
  if (pre_led != led)
    pre_led = led,
    change += 0b00000001;

  // check button if change
  for (i = 0; i < BTNS_N; i++)
    if (pre_button[i] != button[i].status)
      pre_button[i] = button[i].status,
      change += (change & 0b00000010) ? 0b00000000 : 0b00000010;
}

void BluetoothInit(void) {
  Serial.begin(9600);

  pre_led = led;
  for (uint8_t i = 0; i < BTNS_N; i++)
    pre_button[i] = button[i].status;
}

void BluetoothLoop(void) {
  BluetoothCheck();

  if (Serial.available() > 0)
    BluetoothRead();

  if (change > 0)
    BluetoothWrite();
}

#endif