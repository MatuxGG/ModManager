import {app, Notification} from "electron";
import https from "https";
import {getAppData, getMainWindow, MM_INSTALLER_PATH, trans} from "./appGlobals";
import {logError, logToServ, updateTray} from "./functions";
import axios from "axios";
import fs from "fs";
import path from "path";
import {spawn} from "child_process";

function compareDates(date1, date2) {
    function convertToDate(dateString) {
        const [year, month, day] = dateString.split('.').map(Number);
        return new Date(year, month - 1, day);
    }

    const d1 = convertToDate(date1);
    const d2 = convertToDate(date2);

    if (d1 < d2) {
        return 1; // D1 < D2
    } else if (d1 > d2) {
        return -1; // D1 > D2
    } else {
        return 0; // D1 = D2
    }
}

async function processUpdate(installerAsset: any) {
    getAppData().isUpdating = true;
    console.log('Processing update');
    let installerUrl = installerAsset.browser_download_url;

    getMainWindow().webContents.send('navigate', '/updating');
    let notification = new Notification({title: trans('Mod Manager update available'), body: trans('The update will be downloaded in the background and installed immediately afterward.\nYou cannot use Mod Manager during this process!')});
    notification.show();

    const response = await axios({
        method: 'get',
        url: installerUrl,
        responseType: 'stream'
    });

    const totalLength = response.headers['content-length'];
    let progress = 0;
    let lastProgress = 0;
    let lastTime = Date.now();

    response.data.on('data', (chunk: any) => {
        progress += chunk.length;
        const currentTime = Date.now();
        const elapsedTime = currentTime - lastTime;
        const bytesDownloaded = progress - lastProgress;

        const percentCompleted = Math.round((progress / totalLength) * 100);

        const speed = elapsedTime > 0 ? (bytesDownloaded / (elapsedTime / 1000)) : 0;

        if (currentTime - lastTime > 100) {
            lastTime = currentTime;
            lastProgress = progress;
        }
    });

    const writer = fs.createWriteStream(MM_INSTALLER_PATH);
    response.data.pipe(writer);

    return new Promise((resolve, reject) => {
        writer.on('finish', () => {
            console.log('updater downloaded');

            setTimeout(() => {
                let child = spawn(MM_INSTALLER_PATH, {
                    detached: true,
                    stdio: 'ignore'
                });

                if (child.pid) {
                    console.log('Process started with PID:', child.pid);
                    app.quit();
                    process.exit(0);
                }

                child.on('close', () => {
                    app.quit();
                    process.exit(0);
                });
                resolve(true);
            }, 100); // 100 ms delay
        });
        writer.on('error', reject);
    });

}

async function updateCheck() {
    var options = {
        host: 'api.github.com',
        path: `/repos/MatuxGG/ModManager/releases`,
        method: 'GET',
        headers: {
            'user-agent': 'ModManager',
            'Authorization': 'token '+getAppData().githubToken
        }
    };


    return new Promise((resolve, reject) => {
        const req = https.request(options, (res) => {
            let data = '';

            res.on('data', (chunk) => {
                data += chunk;
            });

            res.on('end', async () => {
                if (res.statusCode === 200 || res.statusCode === 301) {
                    try {
                        let releases = JSON.parse(data);
                        if (!releases) {
                            logError('No releases for updater');
                            return reject('No releases for updater');
                        }
                        let latestRelease = releases[0];
                        if (!latestRelease) {
                            logError('No latest release for updater');
                            return reject('No latest release for updater');
                        }
                        let latestVersion = latestRelease.tag_name;
                        let currentVersion = app.getVersion();
                        let compareResult = compareDates(currentVersion, latestVersion);
                        if (compareResult > 0) {
                            const platform = process.platform;
                            let installerName = 'ModManager7-Windows-Installer.exe';
                            if (platform === 'darwin') {
                                installerName = 'ModManager7-Mac-Installer.dmg';
                            } else if (platform === 'linux') {
                                installerName = 'ModManager7-Linux-Installer.AppImage';
                            }
                            let installerAsset = latestRelease.assets.find(asset => asset.name === installerName);
                            if (!installerAsset) {
                                logError('No installer asset for updater');
                                return reject('No installer asset for updater');
                            }
                            // Need update
                            await processUpdate(installerAsset);
                            resolve('Update required');
                        } else {
                            resolve('No update required');
                        }
                    } catch (e) {
                        logError(`Error parsing response: ${e}`);
                        reject(`Error parsing response: ${e}`);
                    }
                } else {
                    logError(`Request failed with status code ${res.statusCode}`);
                    reject(`Request failed with status code ${res.statusCode}`);
                }
            });
        });

        req.on('error', (e) => {
            logError(`Request error: ${e}`);
            reject(`Request error: ${e}`);
        });

        req.end();
    });
}

export async function initializeUpdater() {
    const result = await updateCheck();
    setInterval(function() {
        updateCheck();
    }, 60000);
}