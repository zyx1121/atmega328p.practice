# 工科賽電腦修護第二站

全國高級中等學校學生工業類技藝競賽 電腦修護 第二站

個人電腦 USB 介面卡製作及控制

## 環境安裝

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

### VSCode settings.json

```json
"arduino.path": "/opt/homebrew/Cellar/arduino-cli/0.xx.x/bin/",
"arduino.useArduinoCli": true,
"arduino.commandPath": "arduino-cli",
```
