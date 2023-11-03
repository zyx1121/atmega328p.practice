#ifndef _BLUETOOTH_H_
#define _BLUETOOTH_H_

String IntToHex(uint8_t n) {
  String s;

  switch (n) {
    case 10:
      s = "A";
      break;
    case 11:
      s = "B";
      break;
    case 12:
      s = "C";
      break;
    case 13:
      s = "D";
      break;
    case 14:
      s = "E";
      break;
    case 15:
      s = "F";
      break;
    default:
      s = n;
      break;
  }

  return s;
}

String GetRGB(uint8_t index) {
  String s;

  for (uint8_t i = index; i < index + 2; i++) {
    String ts = "";
    ts = ts + IntToHex(display.rgbData[i][0] / 16) + IntToHex(display.rgbData[i][0] % 16);
    ts = ts + IntToHex(display.rgbData[i][1] / 16) + IntToHex(display.rgbData[i][1] % 16);
    ts = ts + IntToHex(display.rgbData[i][2] / 16) + IntToHex(display.rgbData[i][2] % 16);
    s = s + ts;
  }

  return s;
}

class CBluetooth {
 public:
  void Init();
  void Send();
  void Receive();

  String data;
  uint16_t timeoffset = 0;
  // SoftwareSerial BT(10,11);
} bluetooth;

void CBluetooth::Init() {
  Serial.begin(9600);
  Serial.setTimeout(10);
}

void CBluetooth::Send() {
  static uint8_t index = 0;
  String d = "<";

  d += display.led;

  /*
  switch(index) {
    case 0:
      d += "a0" + mainIndex;
      break;
    case 1:
      d += "b0" + display.led;
      break;
    case 2:
      d += "c0" + 0;
      break;
    case 3:
      d = d + "d0" + GetRGB(0);
      break;
    case 4:
      d = d + "d1" + GetRGB(2);
      break;
    case 5:
      d = d + "d2" + GetRGB(4);
      break;
    case 6:
      d = d + "d3" + GetRGB(6);
      break;
  }
  if(++index == 3) index = 0;
  */

  d += ">";

  Serial.print(d);
}

void CBluetooth::Receive() {
  if (Serial.available()) {
    data = Serial.readString();

    uint8_t d[8];

    char c[99];
    strcpy(c, data.c_str());

    char *s = strtok(c, ",");
    uint8_t sCount = 0;

    while (s != NULL) {
      d[sCount++] = atoi(s);
      s = strtok(NULL, ",");
    }

    if (d[7] == 0) {
      switch (d[0]) {
        case 0: {
          switch (d[1]) {
            case 0:
              display.led = display.led ^ d[2];
              break;
            case 1:
              display.led = 0b00000000;
              break;
            case 2:
              display.led = 0b11111111;
              break;
          }
          break;
        }
        case 1: {
          EEPROM.write(0, d[1]);
          EEPROM.write(1, d[2]);
          EEPROM.write(2, d[3]);
          EEPROM.write(3, d[4]);
          break;
        }
        case 2: {
          // do something
          break;
        }
        case 3: {
          // do something
          break;
        }
      }
    }
  }
}

/*
void serialEvent() {
  //bluetooth.data = "";

  //bluetooth.Receive();
}
*/

#endif
