'use strict'

import { app, protocol, BrowserWindow, Tray } from 'electron'
import { createProtocol } from 'vue-cli-plugin-electron-builder/lib'
const path = require('path');
import {
  APP_PATH,
  getMainWindow,
  isDev, MM_ICON_PATH,
  setAppData,
  setArgs, setIsDev,
  setMainWindow,
  setTray
} from "@/class/appGlobals";
import {handleArgs, logError} from "@/class/functions";
import setupIPCMainHandlers from "@/class/ipcHandler";
import AppData from "@/class/appData";

// Setup globals
setIsDev(process.env.NODE_ENV !== 'production');
setAppData(new AppData());

protocol.registerSchemesAsPrivileged([
  { scheme: 'app', privileges: { secure: true, standard: true } }
])

let preloadPath = path.join(APP_PATH, 'preload.js');

async function createWindow() {
  // Create the browser window.
  setMainWindow(new BrowserWindow({
    width: 1920,
    height: 1080,
    icon: MM_ICON_PATH,
    show: false,
    webPreferences: {
      nodeIntegration: process.env.ELECTRON_NODE_INTEGRATION,
      contextIsolation: !process.env.ELECTRON_NODE_INTEGRATION,
      preload: preloadPath,
    },
    autoHideMenuBar: true,
  }));

  if (isDev()) getMainWindow().webContents.openDevTools();

  getMainWindow().on('close', function (event) {
    if (!app.isQuiting) {
      event.preventDefault();
      getMainWindow().hide();
    }
    return false;
  });

  if (process.env.WEBPACK_DEV_SERVER_URL) {
    await getMainWindow().loadURL(process.env.WEBPACK_DEV_SERVER_URL)
  } else {
    createProtocol('app')
    // Load the index.html when not in development
    await getMainWindow().loadURL('app://./index.html')
  }
}

// Lock for single instance only
const gotTheLock = app.requestSingleInstanceLock();
if (!gotTheLock) {
  app.quit();
}

app.on('second-instance', (event, commandLine) => {
  if (getMainWindow()) {
    if (getMainWindow().isMinimized()) getMainWindow().restore();
    getMainWindow().focus();
  }

  setArgs(commandLine.slice(5));

  handleArgs();
});

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit()
  }
})

app.on('activate', () => {
  // On macOS it's common to re-create a window in the app when the
  // dock icon is clicked and there are no other windows open.
  if (BrowserWindow.getAllWindows().length === 0) createWindow()
})

app.on('ready', async () => {
  setArgs(process.argv.slice(2));
  setTray(new Tray(MM_ICON_PATH));
  createWindow()
  setupIPCMainHandlers();
})

process.on('uncaughtException', (error) => {
  logError(error.stack || error.toString());
});

process.on('unhandledRejection', (reason, promise) => {
  logError(`Unhandled Rejection at: ${promise} reason: ${reason}`);
});

if (isDev()) {
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
