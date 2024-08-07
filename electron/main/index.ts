// @ts-ignore
import {app, BrowserWindow, shell, ipcMain, Menu, Tray} from 'electron'
import { createRequire } from 'node:module'
import { fileURLToPath } from 'node:url'
import path from 'node:path'
import os from 'node:os'
import {
  getMainWindow, getMMIconPath,
  setAppData,
  setArgs,
  setMainWindow, setMMIconPath,
  setTray
} from "./class/appGlobals";
import AppData from "./class/appData";
import {handleArgs, logError} from "./class/functions";
import setupIPCMainHandlers from "./class/ipcHandler";
import {initializeOnlineCheck} from "./class/onlineCheck";

const require = createRequire(import.meta.url)
const __dirname = path.dirname(fileURLToPath(import.meta.url))

// The built directory structure
//
// ├─┬ dist-electron
// │ ├─┬ main
// │ │ └── index.js    > Electron-Main
// │ └─┬ preload
// │   └── index.mjs   > Preload-Scripts
// ├─┬ dist
// │ └── index.html    > Electron-Renderer
//
process.env.APP_ROOT = path.join(__dirname, '../..')

export const MAIN_DIST = path.join(process.env.APP_ROOT, 'dist-electron')
export const RENDERER_DIST = path.join(process.env.APP_ROOT, 'dist')
export const VITE_DEV_SERVER_URL = process.env.VITE_DEV_SERVER_URL

process.env.VITE_PUBLIC = VITE_DEV_SERVER_URL
  ? path.join(process.env.APP_ROOT, 'public')
  : RENDERER_DIST

setMMIconPath(path.join(process.env.VITE_PUBLIC, 'modmanager.ico'));

setAppData(new AppData());

// Disable GPU Acceleration for Windows 7
if (os.release().startsWith('6.1')) app.disableHardwareAcceleration()

// Set application name for Windows 10+ notifications
if (process.platform === 'win32') app.setAppUserModelId(app.getName())

if (!app.requestSingleInstanceLock()) {
  app.quit()
  process.exit(0)
}

const preload = path.join(__dirname, '../preload/index.mjs')
const indexHtml = path.join(RENDERER_DIST, 'index.html')

async function createWindow() {
  setMainWindow(new BrowserWindow({
    title: 'Mod Manager',
    icon: path.join(process.env.VITE_PUBLIC, 'modmanager.ico'),
    show: false,
    autoHideMenuBar: true,
    webPreferences: {
      preload,
      // Warning: Enable nodeIntegration and disable contextIsolation is not secure in production
      // nodeIntegration: true,

      // Consider using contextBridge.exposeInMainWorld
      // Read more on https://www.electronjs.org/docs/latest/tutorial/context-isolation
      // contextIsolation: false,
    },
  }));

  if (VITE_DEV_SERVER_URL) { // #298
    getMainWindow().loadURL(VITE_DEV_SERVER_URL)
    // Open devTool if the app is not packaged
    getMainWindow().webContents.openDevTools()
  } else {
    getMainWindow().loadFile(indexHtml)
  }

  Menu.setApplicationMenu(null);

  getMainWindow().on('close', function (event) {
    event.preventDefault();
    getMainWindow().hide();
    return false;
  });

  // Test actively push message to the Electron-Renderer
  getMainWindow().webContents.on('did-finish-load', () => {
    getMainWindow().webContents.send('navigate', '/');
    // win?.webContents.send('main-process-message', new Date().toLocaleString())
  })

  // Make all links open with the browser, not with the application
  getMainWindow().webContents.setWindowOpenHandler(({ url }) => {
    if (url.startsWith('https:')) shell.openExternal(url)
    return { action: 'deny' }
  })

  // win.webContents.on('will-navigate', (event, url) => { }) #344
}


app.on('ready', async () => {
  initializeOnlineCheck();
  setArgs(process.argv.slice(2));
  let t = new Tray(getMMIconPath());
  setTray(t);
  await createWindow();
  setupIPCMainHandlers();
})

// app.whenReady().then(createWindow)

app.on('window-all-closed', () => {
  setMainWindow(null);
  if (process.platform !== 'darwin') app.quit()
})

app.on('second-instance', (event, commandLine) => {
  if (getMainWindow()) {
    // Focus on the main window if the user tried to open another
    if (getMainWindow().isMinimized()) getMainWindow().restore()
    getMainWindow().focus()
  }

  setArgs(commandLine.slice(5));

  handleArgs();
})

app.on('activate', () => {
  const allWindows = BrowserWindow.getAllWindows()
  if (allWindows.length) {
    allWindows[0].focus()
  } else {
    createWindow()
  }
})

// New window example arg: new windows url
ipcMain.handle('open-win', (_, arg) => {
  const childWindow = new BrowserWindow({
    webPreferences: {
      preload,
      nodeIntegration: true,
      contextIsolation: false,
    },
  })

  if (VITE_DEV_SERVER_URL) {
    childWindow.loadURL(`${VITE_DEV_SERVER_URL}#${arg}`)
  } else {
    childWindow.loadFile(indexHtml, { hash: arg })
  }
})

process.on('uncaughtException', (error) => {
  logError(error.stack || error.toString());
});

process.on('exit', (code) => {
  logError(`Process was stopped with code ${code}`);
});

process.on('unhandledRejection', (reason, promise) => {
  logError(`Unhandled Rejection at: ${promise} reason: ${reason}`);
});