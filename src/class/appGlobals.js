let mainWindow = null;
let tray = null;
let appData = null;
let autoLaunch = null;
let publicPath = null;
let currentDownloads = [];
let args = [];
let devEnv = false;

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

export const setPublicPath = (path) => {
    publicPath = path;
}

export const getPublicPath = () => {
    return publicPath;
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