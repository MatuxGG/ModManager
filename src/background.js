'use strict'

import { app, protocol, BrowserWindow, ipcMain } from 'electron'
import { createProtocol } from 'vue-cli-plugin-electron-builder/lib'
import installExtension, { VUEJS3_DEVTOOLS } from 'electron-devtools-installer'
const isDevelopment = process.env.NODE_ENV !== 'production'
const path = require('path');
const AppData = require('./class/appData');
let appData = new AppData();

// Scheme must be registered before the app is ready
protocol.registerSchemesAsPrivileged([
  { scheme: 'app', privileges: { secure: true, standard: true } }
])

ipcMain.on('loadDataServer', async (event) => {
  console.log("Loading data server...");
  if (!appData || !appData.isLoaded) {
    await appData.load();
  }
  let sentData = JSON.stringify(appData);
  console.log("Data server loaded");
  event.reply('loadDataClient', sentData);
});

ipcMain.on('updateConfigServer', async (event, newConfig) => {
  console.log("Save config on server...");
  appData.updateConfig(newConfig);
  console.log("Config saved on server");
  let sentData = JSON.stringify(appData);
  event.reply('loadDataClient', sentData);
});

ipcMain.on('updateRegionInfoServer', async (event, newRegionInfo) => {
  console.log("Save regionInfo on server...");
  appData.updateConfig(newRegionInfo);
  console.log("regionInfo saved on server");
  let sentData = JSON.stringify(appData);
  event.reply('loadDataClient', sentData);
});

let preloadPath;
if (process.env.WEBPACK_DEV_SERVER_URL) {
  // En mode développement
  preloadPath = path.join(__dirname, '../public/preload.js');
} else {
  // En mode production
  preloadPath = path.join(__dirname, 'preload.js');
}

async function createWindow() {
  // Create the browser window.
  const win = new BrowserWindow({
    width: 1920,
    height: 1080,
    webPreferences: {
      
      // Use pluginOptions.nodeIntegration, leave this alone
      // See nklayman.github.io/vue-cli-plugin-electron-builder/guide/security.html#node-integration for more info
      nodeIntegration: process.env.ELECTRON_NODE_INTEGRATION,
      contextIsolation: !process.env.ELECTRON_NODE_INTEGRATION,
      preload: preloadPath,
    },
    autoHideMenuBar: true,
  })

  if (process.env.WEBPACK_DEV_SERVER_URL) {
    // Load the url of the dev server if in development mode
    await win.loadURL(process.env.WEBPACK_DEV_SERVER_URL)
    if (!process.env.IS_TEST) win.webContents.openDevTools()
  } else {
    createProtocol('app')
    // Load the index.html when not in development
    win.loadURL('app://./index.html')
  }
}

// Quit when all windows are closed.
app.on('window-all-closed', () => {
  // On macOS it is common for applications and their menu bar
  // to stay active until the user quits explicitly with Cmd + Q
  if (process.platform !== 'darwin') {
    app.quit()
  }
})

app.on('activate', () => {
  // On macOS it's common to re-create a window in the app when the
  // dock icon is clicked and there are no other windows open.
  if (BrowserWindow.getAllWindows().length === 0) createWindow()
})

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.on('ready', async () => {
  if (isDevelopment && !process.env.IS_TEST) {
    // Install Vue Devtools
    try {
      await installExtension(VUEJS3_DEVTOOLS)
    } catch (e) {
      console.error('Vue Devtools failed to install:', e.toString())
    }
  }
  createWindow()
})

// Exit cleanly on request from parent process in development mode.
if (isDevelopment) {
  if (process.platform === 'win32') {
    process.on('message', (data) => {
      if (data === 'graceful-exit') {
        app.quit()
      }
    })
  } else {
    process.on('SIGTERM', () => {
      app.quit()
    })
  }
}
