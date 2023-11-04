#ifndef _BLUETOOTH_H_
#define _BLUETOOTH_H_

bool isUpdate = false;

void BluetoothRead(void) {
  uint8_t buffer[2], cmd, data;

  Serial.readBytes(buffer, 2);

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

      break;

    case 'Z':
      isUpdate = true;
      break;
  }
}

void BluetoothWrite(void){
    // static uint8_t pre_led = led;

    // uint8_t data[2] = {};

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