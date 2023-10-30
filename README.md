### Install Arduino CLI

```bash
brew install arduino-cli
```

### Install Arduino Core

```bash
arduino-cli core install arduino:avr
```

### Install Arduino Library

```bash
arduino-cli lib install "Adafruit GFX Library"
arduino-cli lib install "Adafruit SSD1306"
arduino-cli lib install "..."
```

### Set VSCode settings.json

```json
"arduino.path": "/opt/homebrew/Cellar/arduino-cli/0.xx.x/bin/",
"arduino.useArduinoCli": true,
"arduino.commandPath": "arduino-cli",
```
