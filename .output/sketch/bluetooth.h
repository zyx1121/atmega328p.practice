#line 1 "D:\\atmega328p.practice\\112\\avr\\bluetooth.h"
#ifndef _BLUETOOTH_H_
#define _BLUETOOTH_H_

bool isUpdate = false;

void BluetoothRead(void) {
  uint8_t buffer[7], cmd, data;

  Serial.readBytes(buffer, 7);

  cmd = buffer[0];
  data = buffer[1];

  switch (cmd) {
    case 'A':
      // led = data;
      break;

    case 'B':

      break;

    case 'C':

      break;

    case 'D':
      time.second = buffer[1];
      time.minute = buffer[2];
      time.hour = buffer[3];
      time.day = buffer[4];
      time.month = buffer[5];
      time.year = buffer[6];
      rtc.adjust((DateTime){ time.year, time.month, time.day, time.hour, time.minute, time.second });
      break;

    case 'Z':
      isUpdate = true;
      break;
  }
}

void BluetoothWrite(void){
  static uint8_t pre_led = led;
  static uint64_t preMillis = millis();

  uint8_t data[6] = {};

  if( preMillis+100 <= millis()){
    preMillis = millis();
    data[0]='B';
    data[1]=time.tempInt;
    data[2]=time.tempFloat;
    data[3]=1 * (button[0].status != IDLE ? 1 : 0) + 
            2 * (button[1].status != IDLE ? 1 : 0) +
            4 * (button[2].status != IDLE ? 1 : 0) +
            8 * (button[3].status != IDLE ? 1 : 0);
    data[4]=ledOne;
    // data[5]=led;
    Serial.write(data, 6);
  }

  // if (isUpdate || pre_led != led) {
  //   pre_led = led;

  //   data[0] = 'A';
  //   data[1] = led;

  //   Serial.write(data, 2);
  // }

  // isUpdate = false;
};

void InitBluetooth(void) {
  Serial.begin(9600);
}

void LoopBluetooth(void) {
  BluetoothWrite();

  if (Serial.available())
    BluetoothRead();
}

#endif