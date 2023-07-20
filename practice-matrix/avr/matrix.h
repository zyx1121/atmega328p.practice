// 74595
const uint8_t U595_DATA  = 5;
const uint8_t U595_LATCH = 6;
const uint8_t U595_CLOCK = 7;

// 74154
const uint8_t U154_DATA[4] = {9, 10, A1, A2};

uint16_t matrix[16] = {0xffff, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000,
                       0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000, 0x0000};

void InitMatrix(void) {
    pinMode(U595_DATA, OUTPUT);
    pinMode(U595_LATCH, OUTPUT);
    pinMode(U595_CLOCK, OUTPUT);

    for (uint8_t i = 0; i < 4; i++) pinMode(U154_DATA[i], OUTPUT);
}

void LoopMatrix(void) {
    static uint8_t scan = 0;

    for (uint8_t i = 0; i < 4; i++)
        digitalWrite(U154_DATA[i], (scan >> i) & 1);

    digitalWrite(U595_LATCH, LOW);
    shiftOut(U595_DATA, U595_CLOCK, MSBFIRST, matrix[0]);
    digitalWrite(U595_LATCH, HIGH);
}