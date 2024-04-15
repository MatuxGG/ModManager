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

let mainWindow = null;
let appData = new AppData();
import {shell} from 'electron';
import ModWorker from './class/modWorker'
let currentDownloads = [];
let tray = null;
let autoLaunch = null;
let args = [];


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
    updateTray();
    updateLaunchOnStart();
    handleArgs();
  }
  let sentData = JSON.stringify(appData);
  console.log("Data server loaded");
  event.reply('loadDataClient', sentData);
  console.log("Mod Manager started");

});

function handleArgs() {
  if (args.length > 0) {
    console.log("Handle args: ", args);
    switch (args[0]) {
      case "startmod":
        {
          const [mod, version] = appData.getModFromIdAndVersion(args[1], args[2]);
          if (mod !== null && version !== null) {
            mainWindow.webContents.send('handleArgs', 'startmod', [JSON.stringify(mod), JSON.stringify(version)]);
          }
        }
        break;
      // case "startlocalmod":
      //   console.log("start local mod" + args[1]);
      //   break;
        // case "addsource":
        //   break;
      default:
        console.log('default;')
        break;
    }
  }
}

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

function isDownloadInProgress(type, mod, version) {
  return currentDownloads.some(([existingType, existingMod, existingVersion]) =>
      type === existingType && (mod === null || existingMod.sid === mod.sid) && (version === null || existingVersion.version === version.version));
}

async function downloadMod(event, mod, version, appData) {
  console.log("Downloading mod on server...");
  let downloadLines = [];
  if (mod.type === "mod") {
    if (!isDownloadInProgress("mod", mod, version) && !appData.isInstalledModFromIdAndVersion(mod.sid, version.version)) {
      downloadLines.push(["mod", mod, version]);
    }

    for (const dep of version.modDependencies) {
      let [depMod, depVersion] = appData.getModFromIdAndVersion(dep.modDependency, dep.modVersion);
      if (depMod && depVersion && !isDownloadInProgress("mod", depMod, depVersion) && !appData.isInstalledModFromIdAndVersion(depMod.sid, depVersion.version)) {
          downloadLines.push(["mod", depMod, depVersion]);
      }
    }

    if (!isDownloadInProgress("vanilla", version.gameVersion, null) && !appData.hasInstalledVanilla(version.gameVersion)) {
      downloadLines.push(["vanilla", null, version]);
    }
  } else {
    if (!isDownloadInProgress("mod", mod, version) && !appData.isInstalledModFromIdAndVersion(mod.sid, version.version)) {
      downloadLines.push(["allInOne", mod, version]);
    }
  }

  if (downloadLines.length === 0) {
    return;
  }

  let promises = [];
  for (const dl of downloadLines) {
    currentDownloads.push(dl);
    switch (dl[0]) {
      case "vanilla":
        promises.push(ModWorker.downloadClient(event, dl[2], appData));
        break;
      case "mod":
        promises.push(ModWorker.downloadMod(event, dl[1], dl[2], appData));
        break;
      case "allInOne":
        if (dl[1].sid === "BetterCrewlink") {
          promises.push(ModWorker.downloadBcl(event, dl[1], appData));
        } else if (dl[1].sid === "Challenger") {
          promises.push(ModWorker.downloadChall(event, dl[1], appData));
        }
        break;
    }
    promises.push(dl[3]);
  }

  await Promise.all(promises);

  for (const dl of downloadLines) {
    const index = currentDownloads.findIndex(([existingType, existingMod, existingVersion]) =>
        existingType === dl[0] && (dl[1] === null || existingMod.sid === dl[1].sid) && (dl[2] === null || existingVersion.version === dl[2].version));
    if (index !== -1) {
      currentDownloads.splice(index, 1);
    }
    if (dl[0] === "mod") {
      appData.config.addInstalledMod(dl[1], dl[2]);
    } else if (dl[0] === "vanilla") {
      appData.config.addInstalledVanilla(dl[2].gameVersion);
    }
  }

  appData.updateConfig();
  event.reply('updateConfig', JSON.stringify(appData.config));

  updateTray();

  console.log("Mod downloaded on server");
}

ipcMain.on('downloadMod', async (event, modStr, versionStr) => {

  let mod = JSON.parse(modStr);
  let version = JSON.parse(versionStr);

  await downloadMod(event, mod, version, appData);

});

ipcMain.on('uninstallMod', async (event, modStr, versionStr) => {
  console.log("Uninstalling mod on server...");
  let mod = JSON.parse(modStr);
  let version = JSON.parse(versionStr);

  if (!appData.config.installedMods.some(m => m.modId === mod.sid && (version === null || m.version === version.version))) return;

  if (mod.sid === "BetterCrewlink") {
    await ModWorker.uninstallBcl(event, mod, appData);
  } else if (mod.sid === "Challenger") {
    await ModWorker.uninstallChall(event, mod, appData);
  } else {
    await ModWorker.uninstallMod(event, mod, version, appData);
  }

  appData.config.removeInstalledMod(mod, version);
  appData.updateConfig();

  updateTray();

  event.reply('updateConfig', JSON.stringify(appData.config));

  console.log("Mod uninstalled on server");
});

ipcMain.on('startMod', async (event, modStr, versionStr) => {
  console.log("Starting mod on server...");
  let mod = JSON.parse(modStr);
  let version = JSON.parse(versionStr);

  const result = await downloadMod(event, mod, version, appData);
  if (result === false) {
    return;
  }

  if (mod.sid === "BetterCrewlink") {
    await ModWorker.startBcl(event, mod, appData);
  } else if (mod.sid === "Challenger") {
    await ModWorker.startChall(event, mod, appData);
  } else {
    await ModWorker.startMod(event, mod, version, appData);
  }

  console.log("Mod started on server");
});


ipcMain.on('addFavoriteMod', async (event, modStr, versionStr) => {
  let mod = JSON.parse(modStr);
  let version = JSON.parse(versionStr);

  appData.config.addFavoriteMod(mod, version);
  appData.updateConfig();
  event.reply('updateConfig', JSON.stringify(appData.config));
});


ipcMain.on('removeFavoriteMod', async (event, modStr, versionStr) => {
  let mod = JSON.parse(modStr);
  let version = JSON.parse(versionStr);

  appData.config.removeFavoriteMod(mod, version);
  appData.updateConfig();
  event.reply('updateConfig', JSON.stringify(appData.config));
});

let preloadPath = path.join(publicPath, 'preload.js');

function updateTray() {

  let modsLines = [
    {
      label: 'Mod Manager',
      click: function () {
        mainWindow.show();
      }
    },
    { type: 'separator' },
    {
      label: 'Library',
      click: function () {
        mainWindow.webContents.send('navigate', '/library');
        mainWindow.show();
      }
    },
    {
      label: 'Store',
      click: function () {
        mainWindow.webContents.send('navigate', '/store');
        mainWindow.show();
      }
    },
    {
      label: 'Settings',
      click: function () {
        mainWindow.webContents.send('navigate', '/settings');
        mainWindow.show();
      }
    },
  ];

  if (appData.isLoaded) {
    modsLines.push({ type: 'separator' });
    appData.config.installedMods.forEach(im => {
      let [mod, version] = appData.getModFromIdAndVersion(im.modId, im.version);
      if (mod && version && mod.type !== "dependency") {
        modsLines.push({
          label: mod.name + " " + version.version,
          click: function () {
            mainWindow.webContents.send('handleArgs', 'startmod', [JSON.stringify(mod), JSON.stringify(version)]);
          }
        })
      }
    });
  }

  modsLines.push({ type: 'separator' });
  modsLines.push({
    label: 'Exit',
    click: function () {
      app.isQuiting = true;
      app.quit();
    }
  });

  const contextMenu = Menu.buildFromTemplate(modsLines);

  tray.setToolTip('Mod Manager');
  tray.setContextMenu(contextMenu);

  tray.on('double-click', () => {
    if (!appData || !appData.isLoaded) return;
    if (appData.config.minimizeToTray) {
      mainWindow.isVisible() ? mainWindow.hide() : mainWindow.show();
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
  mainWindow = new BrowserWindow({
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
  mainWindow.webContents.openDevTools();

  tray = new Tray(path.join(publicPath, 'modmanager.ico'));

  mainWindow.on('close', function (event) {
    if (!app.isQuiting) {
      event.preventDefault();
      mainWindow.hide();
    }
    return false;
  });

  if (process.env.WEBPACK_DEV_SERVER_URL) {
    // Load the url of the dev server if in development mode
    await mainWindow.loadURL(process.env.WEBPACK_DEV_SERVER_URL)
  } else {
    createProtocol('app')
    // Load the index.html when not in development
    await mainWindow.loadURL('app://./index.html')
  }
}

const gotTheLock = app.requestSingleInstanceLock();

if (!gotTheLock) {
  app.quit();
}

app.on('second-instance', (event, commandLine) => {
  if (mainWindow) {
    if (mainWindow.isMinimized()) mainWindow.restore();
    mainWindow.focus();
  }

  args = commandLine.slice(5);

  handleArgs();
});

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
  args = process.argv.slice(2);
  if (isDevelopment && !process.env.IS_TEST) {
    // Install Vue Devtools
    // try {
    //   await installExtension(VUEJS3_DEVTOOLS)
    // } catch (e) {
    //   console.error('Vue Devtools failed to install:', e.toString())
    // }
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
