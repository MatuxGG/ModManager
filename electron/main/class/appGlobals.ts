import path from "path";
import {fileURLToPath} from "node:url";

let mainWindow = null;
let tray = null;
let appData = null;
let autoLaunch = null;
let currentDownloads = [];
let args = [];
let translations = {};
let MM_ICON_PATH = null;

// Convertir l'URL de fichier en chemin de fichier
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

export const GL_WEBSITE_URL = "https://goodloss.fr";
export const GL_FILES_URL = "https://goodloss.fr/files";
export const GL_API_URL = "https://goodloss.fr/api";
export const MM_CONFIG_PATH = path.join(process.env.APPDATA, 'ModManager7', 'config7.json');
export const MM_LOG_PATH = path.join(process.env.APPDATA, 'ModManager7', 'log.txt');
export const MM_INSTALLER_PATH = path.join(process.env.APPDATA, 'ModManager7', 'installer.exe');
export const AMONGUS_REGIONINFO_PATH = path.join(process.env.APPDATA, '..', 'LocalLow', 'Innersloth', 'Among Us', 'regionInfo.json');
export const AMONGUS_SETTINGS_PATH = path.join(process.env.APPDATA, '..', 'LocalLow', 'Innersloth', 'Among Us', 'settings.amogus');
export const AMONGUS_OLD_SETTINGS_PATH = path.join(process.env.APPDATA, '..', 'LocalLow', 'Innersloth', 'Among Us', 'settings.amogus.old');
export const AMONGUS_NEW_SETTINGS_PATH = path.join(process.env.APPDATA, '..', 'LocalLow', 'Innersloth', 'Among Us', 'settings.amogus.new');

export const AMONGUS_DOWNLOAD_LINK = GL_WEBSITE_URL + "/amonguspage";

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

export const setMMIconPath = (path) => {
    MM_ICON_PATH = path;
}

export const getMMIconPath = () => {
    return MM_ICON_PATH;
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

export const trans = (text: string, ...values: any[]) => {
    if (!getAppData() || !getAppData().config || !getAppData().config.lg) return text;
    const lg = getAppData().config.lg;
    let translatedValue = translations[lg] && translations[lg][text] ? translations[lg][text] : text;

    let index = 0;
    return translatedValue.replace(/\$/g, () => {
        return values[index++] || '$';
    });
}

export const setTranslations = (newTrans) => {
    translations = newTrans;
}