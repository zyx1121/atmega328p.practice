# 工科賽電腦修護第二站

## 環境設定

---

### 安裝 Arduino CLI 並設置環境變數

**MacOS**

```bash
brew install arduino-cli
```

**Windows**

參考 [Arduino CLI 官方文件](https://arduino.github.io/arduino-cli/0.33/installation/) 下載 Latest release Windows 64 bit exe

解壓縮到 `C:\Source\arduino-cli\` 並設置環境變數

---

### 安裝 VSCode

**MacOS**

```bash
brew cask install visual-studio-code
```

**Windows**

參考 [VSCode 官方文件](https://code.visualstudio.com/docs/setup/windows) 下載並安裝

---

### 安裝 Arduino for VSCode 套件

下載 [Arduino for VSCode](https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.vscode-arduino)
在 VSCode 的 settings.json 中添加

**MacOS**

```json
"arduino.path": "/opt/homebrew/Cellar/arduino-cli/0.33.0/bin/",
"arduino.useArduinoCli": true,
"arduino.commandPath": "arduino-cli",
```

**Windows**

```json
"arduino.useArduinoCli": true,
```
