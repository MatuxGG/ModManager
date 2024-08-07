// @ts-ignore
import {app, BrowserWindow, Menu, shell} from "electron";
// @ts-ignore
import AutoLaunch from "auto-launch";
import ModWorker from "./modWorker";
import {
    getAppData,
    getArgs,
    getAutoLaunch,
    getCurrentDownloads,
    getMainWindow, getMMIconPath,
    getTray, GL_API_URL, isDownloadInProgress, MM_LOG_PATH, removeFinishedDownload,
    setAutoLaunch, trans
} from "./appGlobals";
import path from "path";
import fs from "fs";
// @ts-ignore
import axios from "axios";
import {isOnline} from "./onlineCheck";

export const handleArgs = () => {
    let args = getArgs();
    if (args.length > 0) {
        console.log("Handle args: ", args);
        switch (args[0]) {
            case "startvanilla":
            {
                getMainWindow().webContents.send('handleArgs', 'startVanilla');
            }
            case "startmod":
            {
                const [mod, version] = getAppData().getModFromIdAndVersion(args[1], args[2]);
                if (mod !== null && version !== null) {
                    getMainWindow().webContents.send('handleArgs', 'startmod', [JSON.stringify(mod), JSON.stringify(version)]);
                } else {
                    let mod = getAppData().getMod(args[1]);
                    let modVersions = getAppData().getModVersions(args[1]);
                    if (mod && modVersions) {
                        getMainWindow().webContents.send('handleArgs', 'startmod', [JSON.stringify(mod), JSON.stringify(modVersions[0])]);
                    }
                }
            }
                break;
            // case "startlocalmod":
            //   console.log("start local mod" + args[1]);
            //   break;
            // case "addsource":
            //   break;
            default:
                console.log('No arg')
                break;
        }
    }
}

export const downloadMod = async (event, mod, version) => {
    console.log("Downloading mod on server...");
    let downloadLines = [];
    if (mod.type !== "allInOne") {
        let installedVersions = getAppData().getInstalledModVersions(mod.sid);
        let versions = getAppData().getModVersions(mod.sid);
        for (const installedVersion of installedVersions) {
            if (!versions.some(v => v.version === installedVersion.version)) {
                let generatedMod = mod;
                generatedMod.version = installedVersion.version;
                let generatedVersion = {'version': installedVersion.version};
                downloadLines.push(["update", generatedMod, generatedVersion]);
            }
        }

        if (!isDownloadInProgress("mod", mod, version) && !getAppData().isInstalledModFromIdAndVersion(mod.sid, version.version)) {
            downloadLines.push(["mod", mod, version]);
        }

        for (const dep of version.modDependencies) {
            let [depMod, depVersion] = getAppData().getModFromIdAndVersion(dep.modDependency, dep.modVersion);
            if (depMod && depVersion && !isDownloadInProgress("mod", depMod, depVersion) && !getAppData().isInstalledModFromIdAndVersion(depMod.sid, depVersion.version)) {
                downloadLines.push(["mod", depMod, depVersion]);
            }
        }

        if (!isDownloadInProgress("vanilla", version.gameVersion, null) && !getAppData().hasInstalledVanilla(version.gameVersion)) {
            downloadLines.push(["vanilla", null, version]);
        }
    } else {
        if (!isDownloadInProgress("mod", mod, version) && !getAppData().isInstalledModFromIdAndVersion(mod.sid, null)) {
            downloadLines.push(["allInOne", mod, version]);
        }
    }


    if (downloadLines.length === 0) {
        return;
    }

    let promises = [];
    for (const dl of downloadLines) {
        getCurrentDownloads().push(dl);
        switch (dl[0]) {
            case "vanilla":
                promises.push(ModWorker.downloadClient(event, dl[2]));
                break;
            case "mod":
                promises.push(ModWorker.downloadMod(event, dl[1], dl[2]));
                break;
            case "allInOne":
                if (dl[1].sid === "BetterCrewlink") {
                    promises.push(ModWorker.downloadBcl(event, dl[1]));
                } else if (dl[1].sid === "Challenger") {
                    promises.push(ModWorker.downloadChall(event, dl[1]));
                }
                break;
            case "update":
                promises.push(ModWorker.uninstallMod(event, dl[1], dl[2]));
        }
        //promises.push(dl[3]);
    }

    await Promise.all(promises);

    for (const dl of downloadLines) {
        removeFinishedDownload(dl[0], dl[1], dl[2]);
        if (dl[0] === "mod") {
            getAppData().config.addInstalledMod(dl[1], dl[2]);
        } else if (dl[0] === "vanilla") {
            getAppData().config.addInstalledVanilla(dl[2].gameVersion);
        } else if (dl[0] === "update") {
            getAppData().config.removeInstalledMod(dl[1], dl[2]);
        } else if (dl[0] === "allInOne") {
            getAppData().config.addInstalledMod(dl[1], null);
        }
    }

    getAppData().updateConfig();
    event.reply('updateConfig', JSON.stringify(getAppData().config));

    updateTray();

    console.log("Mod downloaded on server");
}

export const uninstallMod = async (event, mod, version) => {
    console.log("Uninstalling mod on server...");
    if (!getAppData().isInstalledModFromIdAndVersion(mod.sid, version === null ? null : version.version)) return;

    if (mod.sid === "BetterCrewlink") {
        await ModWorker.uninstallBcl(event, mod);
    } else if (mod.sid === "Challenger") {
        await ModWorker.uninstallChall(event, mod);
    } else {
        await ModWorker.uninstallMod(event, mod, version);
    }

    getAppData().config.removeInstalledMod(mod, version);
    getAppData().updateConfig();

    updateTray();

    event.reply('updateConfig', JSON.stringify(getAppData().config));

    console.log("Mod uninstalled on server");
}

export const startMod = async (event, mod, version) => {
    console.log("Starting mod on server...");
    const result: any = await downloadMod(event, mod, version);
    if (result === false) {
        return;
    }

    if (mod.sid === "BetterCrewlink") {
        await ModWorker.startBcl(event, mod);
    } else if (mod.sid === "Challenger") {
        await ModWorker.startChall(event, mod);
    } else {
        await ModWorker.startMod(event, mod, version);
    }

    console.log("Mod started on server");
}

export const createShortcut = (mod, version) => {
    let appPath = app.getPath('exe');
    let desktopPath = path.join(app.getPath('home'), 'Desktop');
    let shortcutPath = path.join(desktopPath, mod.name + (version !== null ? (" " + version.version) : "") + '.lnk');

    let success = shell.writeShortcutLink(shortcutPath, 'create', {
        target: appPath+' startmod '+ (version !== null ? (" " + version.version) : ""),
        cwd: path.dirname(appPath),
        icon: appPath,
        iconIndex: 0,
        appUserModelId: 'modmanager7',
        description: 'Mod Manager'
    });

    if (success) {
        console.log('Shortcut created successfully');
    } else {
        console.log('Failed to create shortcut');
    }
}

export const updateTray = () => {
    let modsLines = [
        {
            label: 'Mod Manager',
            click: function () {
                getMainWindow().show();
            }
        },
        { type: 'separator' },
        {
            label: trans('Library'),
            click: function () {
                getMainWindow().webContents.send('navigate', '/library');
                getMainWindow().show();
            }
        },
        {
            label: trans('Store'),
            click: function () {
                getMainWindow().webContents.send('navigate', '/store');
                getMainWindow().show();
            }
        },
        {
            label: trans('Settings'),
            click: function () {
                getMainWindow().webContents.send('navigate', '/settings');
                getMainWindow().show();
            }
        },
    ];

    if (getAppData() || getAppData().isLoaded) {
        modsLines.push({ type: 'separator' });
        if (getAppData().startedMod === false) {
            modsLines.push({
                label: "Start Vanilla",
                click: function () {
                    getMainWindow().webContents.send('handleArgs', 'startVanilla');
                }
            });
        } else {
            modsLines.push({
                label: trans("Stop $", getAppData().startedMod[0].name+" "+getAppData().startedMod[1].release.tag_name),
                click: function () {
                    getMainWindow().webContents.send('handleArgs', 'stopCurrentMod');
                }
            });
        }
        modsLines.push({ type: 'separator' });
        getAppData().config.installedMods.forEach(im => {
            let [mod, version] = getAppData().getModFromIdAndVersion(im.modId, im.version);
            if (mod && version && mod.type !== "dependency") {
                modsLines.push({
                    label: mod.name + " " + im.releaseVersion,
                    click: function () {
                        getMainWindow().webContents.send('handleArgs', 'startmod', [JSON.stringify(mod), JSON.stringify(version)]);
                    }
                })
            }
        });
    }

    modsLines.push({ type: 'separator' });
    modsLines.push({
        label: trans('Exit'),
        click: function () {
            app.quit()
            process.exit(0)
        }
    });

    const contextMenu = Menu.buildFromTemplate(modsLines);

    getTray().setToolTip('Mod Manager');
    getTray().setContextMenu(contextMenu);

    getTray().on('double-click', () => {
        if (!getAppData() || !getAppData().isLoaded) return;
        getMainWindow().isVisible() ? getMainWindow().hide() : getMainWindow().show();
    });
}

export const enableAutoLaunch = () => {
    getAutoLaunch().isEnabled().then((isEnabled) => {
        if (!isEnabled) getAutoLaunch().enable();
    }).catch((err) => {
        logError(err);
    });
}

export const disableAutoLaunch = () => {
    getAutoLaunch().isEnabled().then((isEnabled) => {
        if (isEnabled) getAutoLaunch().disable();
    }).catch((err) => {
        logError(err);
    });
}

export const updateLaunchOnStart = () => {
    setAutoLaunch(new AutoLaunch({
        name: 'ModManager',
        icon: getMMIconPath(),
        path: app.getPath('exe'),
    }));

    if (getAppData().config.launchOnStartup) {
        enableAutoLaunch()
    } else {
        disableAutoLaunch()
    }
}

export const getFormattedLogMessage = (message: string) => {
    let supportId = getAppData()?.config?.supportId ?? '';
    return `[ModManager7][${supportId}] ${message}`;
}

export const logError = (firstError: string, ...errors: any[]) => {
    errors = errors.map((error) => {
        if (typeof error === 'string') {
            return error;
        } else {
            return JSON.stringify(error);
        }
    });
    let concatenatedErrors = errors.join(', ');
    concatenatedErrors = firstError + " " + concatenatedErrors;
    logToServ(concatenatedErrors);
    console.error(concatenatedErrors);
    fs.appendFile(MM_LOG_PATH, "[" + new Date().toISOString() + "] " + concatenatedErrors + "\n", (err) => {
        if (err) {
            logError('Failed to write to log file:', err);
        }
    });
}

export const logToServ = (message: string) => {
    if (!isOnline()) return;
    message = getFormattedLogMessage(message);
    axios.post(GL_API_URL+"/log", {
        text: message
    }, {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        }
    }).then(r => {
        // console.log(r.status);
    });
}