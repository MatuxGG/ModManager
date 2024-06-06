import path from "path";

let mainWindow = null;
let tray = null;
let appData = null;
let autoLaunch = null;
let currentDownloads = [];
let args = [];
let devEnv = false;
let translations = {};

export const APP_PATH = process.env.WEBPACK_DEV_SERVER_URL ? path.join(__dirname, '../public') : __dirname;

export const GL_WEBSITE_URL = "https://goodloss.fr";
export const GL_FILES_URL = "https://goodloss.fr/files";
export const GL_API_URL = "https://goodloss.fr/api";
export const MM_CONFIG_PATH = path.join(process.env.APPDATA, 'ModManager7', 'config7.json');
export const MM_LOG_PATH = path.join(process.env.APPDATA, 'ModManager7', 'log.txt');
export const MM_ICON_PATH = path.join(APP_PATH, 'modmanager.ico');
export const AMONGUS_REGIONINFO_PATH = path.join(process.env.APPDATA, '..', 'LocalLow', 'Innersloth', 'Among Us', 'regionInfo.json');

export const setMainWindow = (win) => {
    mainWindow = win;
}

export const getMainWindow = () => {
    return mainWindow;
}

export const setAppData = (ad) => {
    appData = ad;
}

export const getAppData = () => {
    return appData;
}

export const setTray = (t) => {
    tray = t;
}

export const getTray = () => {
    return tray;
}

export const setAutoLaunch = (al) => {
    autoLaunch = al;
}

export const getAutoLaunch = () => {
    return autoLaunch;
}

export const setArgs = (arg) => {
    args = arg;
}

export const getArgs = () => {
    return args;
}

export const setIsDev = (state) => {
    devEnv = state;
}

export const isDev = () => {
    return devEnv;
}

// Only get because you can only add or splice
export const getCurrentDownloads = () => {
    return currentDownloads;
}

export const isDownloadInProgress = (type, mod, version) => {
    return currentDownloads.some(([existingType, existingMod, existingVersion]) =>
        type === existingType && (mod === null || existingMod.sid === mod.sid) && (version === null || existingVersion.version === version.version));
}

export const removeFinishedDownload = (type, mod, version) => {
    const index = currentDownloads.findIndex(([existingType, existingMod, existingVersion]) =>
        existingType === type && (mod === null || existingMod.sid === mod.sid) && (version === null || existingVersion.version === version.version));
    if (index !== -1) {
        currentDownloads.splice(index, 1);
    }
}

export const trans = (text) => {
    const lg = getAppData().config.lg;
    return translations[lg] && translations[lg][text] ? translations[lg][text] : text;
}

export const setTranslations = (newTrans) => {
    translations = newTrans;
}