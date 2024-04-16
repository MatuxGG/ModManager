import {app, Menu} from "electron";
import AutoLaunch from "auto-launch";
import path from "path";
import ModWorker from "@/class/modWorker";
import {
    getAppData,
    getArgs,
    getAutoLaunch,
    getCurrentDownloads,
    getMainWindow, getPublicPath,
    getTray,
    setAutoLaunch
} from "@/class/appGlobals";


export const handleArgs = () => {
    if (getArgs().length > 0) {
        console.log("Handle args: ", getArgs());
        switch (getArgs()[0]) {
            case "startmod":
            {
                const [mod, version] = getAppData().getModFromIdAndVersion(getArgs()[1], getArgs()[2]);
                if (mod !== null && version !== null) {
                    getMainWindow().webContents.send('handleArgs', 'startmod', [JSON.stringify(mod), JSON.stringify(version)]);
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

export const isDownloadInProgress = (type, mod, version) => {
    return getCurrentDownloads().some(([existingType, existingMod, existingVersion]) =>
        type === existingType && (mod === null || existingMod.sid === mod.sid) && (version === null || existingVersion.version === version.version));
}

export const downloadMod = async (event, mod, version, appData) => {
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
        getCurrentDownloads().push(dl);
        switch (dl[0]) {
            case "vanilla":
                promises.push(ModWorker.downloadClient(event, dl[2], appData));
                break;
            case "mod":
                promises.push(ModWorker.downloadMod(event, dl[1], dl[2], appData));
                break;
            case "allInOne":
                if (dl[1].sid === "BetterCrewlink") {
                    promises.push(ModWorker.downloadBcl(event, dl[1]));
                } else if (dl[1].sid === "Challenger") {
                    promises.push(ModWorker.downloadChall(event, dl[1]));
                }
                break;
        }
        promises.push(dl[3]);
    }

    await Promise.all(promises);

    for (const dl of downloadLines) {
        const index = getCurrentDownloads().findIndex(([existingType, existingMod, existingVersion]) =>
            existingType === dl[0] && (dl[1] === null || existingMod.sid === dl[1].sid) && (dl[2] === null || existingVersion.version === dl[2].version));
        if (index !== -1) {
            getCurrentDownloads().splice(index, 1);
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
            label: 'Library',
            click: function () {
                getMainWindow().webContents.send('navigate', '/library');
                getMainWindow().show();
            }
        },
        {
            label: 'Store',
            click: function () {
                getMainWindow().webContents.send('navigate', '/store');
                getMainWindow().show();
            }
        },
        {
            label: 'Settings',
            click: function () {
                getMainWindow().webContents.send('navigate', '/settings');
                getMainWindow().show();
            }
        },
    ];

    if (getAppData().isLoaded) {
        modsLines.push({ type: 'separator' });
        getAppData().config.installedMods.forEach(im => {
            let [mod, version] = getAppData().getModFromIdAndVersion(im.modId, im.version);
            if (mod && version && mod.type !== "dependency") {
                modsLines.push({
                    label: mod.name + " " + version.version,
                    click: function () {
                        getMainWindow().webContents.send('handleArgs', 'startmod', [JSON.stringify(mod), JSON.stringify(version)]);
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

    getTray().setToolTip('Mod Manager');
    getTray().setContextMenu(contextMenu);

    getTray().on('double-click', () => {
        if (!getAppData() || !getAppData().isLoaded) return;
        if (getAppData().config.minimizeToTray) {
            getMainWindow().isVisible() ? getMainWindow().hide() : getMainWindow().show();
        } else {
            getTray().destroy();
            app.quit();
        }
    });
}

export const enableAutoLaunch = () => {
    getAutoLaunch().isEnabled().then((isEnabled) => {
        if (!isEnabled) getAutoLaunch().enable();
    }).catch((err) => {
        console.error(err);
    });
}

export const disableAutoLaunch = () => {
    getAutoLaunch().isEnabled().then((isEnabled) => {
        if (isEnabled) getAutoLaunch().disable();
    }).catch((err) => {
        console.error(err);
    });
}

export const updateLaunchOnStart = () => {
    setAutoLaunch(new AutoLaunch({
        name: 'ModManager',
        icon: path.join(getPublicPath(), 'modmanager.ico'),
        path: app.getPath('exe'),
    }));

    if (getAppData().config.launchOnStartup) {
        enableAutoLaunch()
    } else {
        disableAutoLaunch()
    }
}
