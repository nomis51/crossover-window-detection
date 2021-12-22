# crossover-window-detection
## Requirements
- An Electron app (Please take a look at the requirements of [electron-edge-js](https://www.npmjs.com/package/electron-edge-js) to know the exact version of Electron vs Node.js you need)
- Depending the version of Node.js you have, you might need to install [Windows Build Tools](https://www.npmjs.com/package/windows-build-tools) before you try to install this package

## Installation
Via [NPM](https://www.npmjs.com/package/@nomis51/crossover-window-detection)

`npm i @nomis51/crossover-window-detection`

## Usage

```js
const { getForegroundWindowInfos } = require('@nomis51/crossover-window-detection');

// Considering in this example that Google Chrome is the current foreground window
try {
  getForegroundWindowInfos(infos => {
    if (!infos) return;
    console.log(infos) // { "title": "Google Chrome", "processPath": "C:\Program Files\Google Chrome\bin\chrome.exe" }
  });
}
catch (e) {
  console.error(e)
}
```
