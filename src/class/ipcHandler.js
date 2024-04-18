import {ipcMain, shell} from "electron";
import {getAppData, getMainWindow, GL_API_URL} from "@/class/appGlobals";
import {
    createShortcut,
    downloadMod,
    handleArgs, logToServ,
    startMod,
    uninstallMod,
    updateLaunchOnStart,
    updateTray
} from "@/class/functions";
import axios from "axios";

const setupIPCMainHandlers = () => {

    ipcMain.on('openExternal', async (event, url) => {
        shell.openExternal(url)
    });

    ipcMain.on('loadDataServer', async (event) => {
        console.log("Loading data server...");
        if (!getAppData() || !getAppData().isLoaded) {
            await getAppData().loadLocalConfig();
            if (getAppData().config.minimizeToTray === false) {
                getMainWindow().show();
                getMainWindow().focus();
            }
            await getAppData().load();
            updateTray();
            updateLaunchOnStart();
            handleArgs();
        }
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
        event.sender.send('createPopin', "<div class='w-64'><p>Shortcut created for "+mod.name+(version !== null ? (" " + version.version) : "")+"</p></div>", downloadId, "bg-green-700");
        event.sender.send('removePopin', downloadId);
    });

    ipcMain.on('rateMod', async (event, modStr, versionStr, rating) => {
        let mod = JSON.parse(modStr);
        let version = JSON.parse(versionStr);

        logToServ("Rate of "+rating+"/5 for mod "+mod.sid+" "+version.version);
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