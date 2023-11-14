#ifndef _BLUETOOTH_H_
#define _BLUETOOTH_H_

void BluetoothRead(void) {
  uint8_t buffer[7];

  Serial.readBytes(buffer, 7);

  switch (buffer[0]) {
    case 'A':

      break;

    case 'B':

      break;

    case 'C':

      break;

    case 'D':
      rtc.adjust((DateTime){buffer[6], buffer[5], buffer[4], buffer[3], buffer[2], buffer[1]});
      break;

    case 'Z':

      break;
  }
}

void BluetoothWrite(void) {
  static uint8_t pre_led = led;
  static uint64_t preMillis = millis();

  uint8_t data[6] = {};

  if (preMillis + 100 <= millis()) {
    preMillis = millis();
    data[0] = 'B';
    data[1] = time.tempInt;
    data[2] = time.tempFloat;
    data[3] = 1 * (button[0].status != IDLE ? 1 : 0) +
              2 * (button[1].status != IDLE ? 1 : 0) +
              4 * (button[2].status != IDLE ? 1 : 0) +
              8 * (button[3].status != IDLE ? 1 : 0);
    data[4] = one;
    data[5] = led;
    Serial.write(data, 6);
  }
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