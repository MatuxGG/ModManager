'use strict'

import { app, protocol, BrowserWindow, ipcMain, Tray, Menu } from 'electron'
import { createProtocol } from 'vue-cli-plugin-electron-builder/lib'
import installExtension, { VUEJS3_DEVTOOLS } from 'electron-devtools-installer'
const isDevelopment = process.env.NODE_ENV !== 'production'
const path = require('path');
const AppData = require('./class/appData');
const AutoLaunch = require('auto-launch');

let publicPath = '';
if (process.env.WEBPACK_DEV_SERVER_URL) {
  // En mode développement
  publicPath = path.join(__dirname, '../public');
} else {
  // En mode production
  publicPath = __dirname;
}

let appData = new AppData();
import {shell} from 'electron';
import ModWorker from './class/modWorker'
let currentDownloads = [];
let tray = null;
let autoLaunch = null;


// Scheme must be registered before the app is ready
protocol.registerSchemesAsPrivileged([
  { scheme: 'app', privileges: { secure: true, standard: true } }
])

ipcMain.on('openExternal', async (event, url) => {
  shell.openExternal(url)
});

ipcMain.on('loadDataServer', async (event) => {
  console.log("Loading data server...");
  if (!appData || !appData.isLoaded) {
    await appData.load();
    updateLaunchOnStart();
  }
  let sentData = JSON.stringify(appData);
  console.log("Data server loaded");
  event.reply('loadDataClient', sentData);
  console.log("Mod Manager started");
});

ipcMain.on('updateConfigServer', async (event, newConfig) => {
  console.log("Save config on server...");
  appData.updateConfig(newConfig);
  updateLaunchOnStart();
  console.log("Config saved on server");
  let sentData = JSON.stringify(appData);
  event.reply('loadDataClient', sentData);
});

// ipcMain.on('updateRegionInfoServer', async (event, newRegionInfo) => {
//   console.log("Save regionInfo on server...");
//   appData.updateConfig(newRegionInfo);
//   console.log("regionInfo saved on server");
//   let sentData = JSON.stringify(appData);
//   event.reply('loadDataClient', sentData);
// });

function isDownloadInProgress(mod, version) {
  return currentDownloads.some(([existingMod, existingVersion]) => 
      existingMod.sid === mod.sid && existingVersion.version === version.version);
}

ipcMain.on('downloadMod', async (event, modStr, versionStr) => {
  console.log("Downloading mod on server...");
  let mod = JSON.parse(modStr);
  let version = JSON.parse(versionStr);
  if (isDownloadInProgress(mod, version)) return;
  currentDownloads.push([mod, version]);

  let downloadLines = [];

  if (appData.config.installedVanilla.includes(version.gameVersion)) {
    console.log("client already installed");
  } else {
    downloadLines.push(ModWorker.downloadClient(event, version, appData));
  }

  if (appData.config.installedMods.includes(mod.id)) {
    console.log("mod already installed");
  } else {
    downloadLines.push(ModWorker.downloadMod(event, mod, version, appData));
  }

  await Promise.all(downloadLines);

  const index = currentDownloads.findIndex(([existingMod, existingVersion]) => 
        existingMod.sid === mod.sid && existingVersion.version === version.version);
  if (index !== -1) {
      currentDownloads.splice(index, 1);
  }

  appData.config.addInstalledVanilla(version.gameVersion);
  appData.config.addInstalledMod(mod, version);
  appData.updateConfig();
  event.reply('updateConfig', JSON.stringify(appData.config));

  console.log("Mod downloaded on server");
});

ipcMain.on('uninstallMod', async (event, modStr, versionStr) => {
  console.log("Uninstalling mod on server...");
  let mod = JSON.parse(modStr);
  let version = JSON.parse(versionStr);

  if (!appData.config.installedMods.some(m => m.modId === mod.sid && m.version === version.version)) return;

  await ModWorker.uninstallMod(event, mod, version, appData);

  appData.config.removeInstalledMod(mod, version);
  appData.updateConfig();
  event.reply('updateConfig', JSON.stringify(appData.config));

  console.log("Mod uninstalled on server");
});

let preloadPath = path.join(publicPath, 'preload.js');

function createTray(win) {
  tray = new Tray(path.join(publicPath, 'modmanager.ico'));
  const contextMenu = Menu.buildFromTemplate([
    {
      label: 'Mod Manager',
      click: function () {
        win.show();
      }
    },
    {
      label: 'Exit',
      click: function () {
        app.isQuiting = true;
        app.quit();
      }
    }
  ]);

  tray.setToolTip('Mod Manager');
  tray.setContextMenu(contextMenu);

  tray.on('double-click', () => {
    if (!appData || !appData.isLoaded) return;
    if (appData.config.minimizeToTray) {
      win.isVisible() ? win.hide() : win.show();
    } else {
      tray.destroy();
      app.quit();
    }
  });
}

function enableAutoLaunch() {
  autoLaunch.isEnabled().then((isEnabled) => {
    if (!isEnabled) autoLaunch.enable();
  }).catch((err) => {
    console.error(err);
  });
}

function disableAutoLaunch() {
  autoLaunch.isEnabled().then((isEnabled) => {
    if (isEnabled) autoLaunch.disable();
  }).catch((err) => {
    console.error(err);
  });
}

function updateLaunchOnStart() {
  autoLaunch = new AutoLaunch({
    name: 'ModManager',
    icon: path.join(publicPath, 'modmanager.ico'),
    path: app.getPath('exe'),

  });

  if (appData.config.launchOnStartup) {
    enableAutoLaunch()
  } else {
    disableAutoLaunch()
  }
}

async function createWindow() {
  // Create the browser window.
  const win = new BrowserWindow({
    width: 1920,
    height: 1080,
    icon: path.join(publicPath, 'modmanager.ico'),
    webPreferences: {
      
      // Use pluginOptions.nodeIntegration, leave this alone
      // See nklayman.github.io/vue-cli-plugin-electron-builder/guide/security.html#node-integration for more info
      nodeIntegration: process.env.ELECTRON_NODE_INTEGRATION,
      contextIsolation: !process.env.ELECTRON_NODE_INTEGRATION,
      preload: preloadPath,
    },
    autoHideMenuBar: true,
  })
  win.webContents.openDevTools();

  createTray(win)

  win.on('close', function (event) {
    if (!app.isQuiting) {
      event.preventDefault();
      win.hide();
    }
    return false;
  });

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
