import {dialog, ipcMain, shell} from "electron";
import {getAppData, getCurrentDownloads, getMainWindow, setTranslations, trans} from "@/class/appGlobals";
import {
    createShortcut,
    downloadMod,
    handleArgs,
    logToServ,
    startMod,
    uninstallMod,
    updateLaunchOnStart,
    updateTray
} from "@/class/functions";
import modWorker from "@/class/modWorker";

const setupIPCMainHandlers = () => {

    ipcMain.on('openExternal', async (event, url) => {
        shell.openExternal(url)
    });

    ipcMain.on('loadDataServer', async (event) => {
        console.log("Loading data server...");
        if (!getAppData() || !getAppData().isLoaded) {
            await getAppData().loadLocalConfig();
            getMainWindow().show();
            event.reply('loadLanguage', getAppData().config.lg);
        }
    });

    ipcMain.on('loadDataServer2', async (event, translations) => {
        setTranslations((JSON.parse(translations)));
        if (getAppData().config.minimizeToTray === false) {
            getMainWindow().show();
            getMainWindow().focus();
        }

        await getAppData().load();
        updateTray();
        updateLaunchOnStart();
        handleArgs();

        let sentData = JSON.stringify(getAppData());
        console.log("Data server loaded");
        event.reply('loadDataClient', sentData);
        console.log("Mod Manager started");
    });

    ipcMain.on('updateConfigServer', async (event, newConfig) => {
        console.log("Save config on server...");
        getAppData().updateConfig(newConfig);
        updateLaunchOnStart();
        console.log("Config saved on server");
        let sentData = JSON.stringify(getAppData());
        event.reply('loadDataClient', sentData);
    });

    ipcMain.on('updateTray', async () => {
        updateTray();
    });

    ipcMain.on('downloadMod', async (event, modStr, versionStr) => {

        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);

        await downloadMod(event, mod, version);

    });

    ipcMain.on('uninstallMod', async (event, modStr, versionStr) => {
        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);

        await uninstallMod(event, mod, version);
    });

    ipcMain.on('startMod', async (event, modStr, versionStr) => {
        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);

        await startMod(event, mod, version);
    });


    ipcMain.on('addFavoriteMod', async (event, modStr, versionStr) => {
        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);

        getAppData().config.addFavoriteMod(mod, version);
        getAppData().updateConfig();
        event.reply('updateConfig', JSON.stringify(getAppData().config));
    });


    ipcMain.on('removeFavoriteMod', async (event, modStr, versionStr) => {
        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);

        getAppData().config.removeFavoriteMod(mod, version);
        getAppData().updateConfig();
        event.reply('updateConfig', JSON.stringify(getAppData().config));
    });

    ipcMain.on('addShortcut', async (event, modStr, versionStr) => {
        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);
        createShortcut(mod, version);
        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Shortcut created for $,"+mod.name+(version !== null ? (" " + version.version) : "")+"]</p></div>", downloadId, "bg-green-700");
        event.sender.send('removePopin', downloadId);
    });

    ipcMain.on('rateMod', async (event, modStr, versionStr, rating) => {
        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);

        logToServ("Rate of "+rating+"/5 for mod "+mod.sid+" "+version.version);
    });

    ipcMain.on('stopCurrentMod', async () => {
        await modWorker.stopChild();
    });

    ipcMain.on('resetApp', async () => {
        await getAppData().resetApp();
    });

    ipcMain.handle('openFolderDialog', async (event, newPath = null) => {
        let worked = false;
        if (getCurrentDownloads().length === 0) {
            if (newPath === null) {
                const result = await dialog.showOpenDialog(getMainWindow(), {
                    properties: ['openDirectory']
                });
                worked = !result.canceled;
                newPath = result.filePaths[0];
            } else {
                worked = true;
            }

            let changeResult = await getAppData().changeDataFolder(newPath);
            if (worked) {
                let downloadId = Date.now().toString();
                if (changeResult) {
                    event.sender.send('updateConfig', JSON.stringify(getAppData().config));
                    event.sender.send('createPopin', "<div class='w-64'>$t[Path successfully updated!]</div>", downloadId, "bg-green-700");
                } else {
                    event.sender.send('createPopin', "<div class='w-64'>$t[Path doesn't exist!]</div>", downloadId, "bg-red-700");
                }
                event.sender.send('removePopin', downloadId);
            }
        }
        return getAppData().config.dataPath;
    });

    ipcMain.on('createPopin', async (event, text, downloadId, classes) => {
        event.sender.send('createPopin', text, downloadId, classes);
    });

    ipcMain.on('removePopin', async (event, downloadId) => {
        event.sender.send('removePopin', downloadId);
    });

    // ipcMain.on('updateRegionInfoServer', async (event, newRegionInfo) => {
    //   console.log("Save regionInfo on server...");
    //   appData.updateConfig(newRegionInfo);
    //   console.log("regionInfo saved on server");
    //   let sentData = JSON.stringify(appData);
    //   event.reply('loadDataClient', sentData);
    // });
};

export default setupIPCMainHandlers;