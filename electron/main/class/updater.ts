import {app, Notification} from "electron";
import https from "https";
import {getAppData, getMainWindow, trans} from "./appGlobals";
import {logError, logToServ} from "./functions";

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

function processUpdate(installerAsset: any) {
    getAppData().isUpdating = true;
    console.log('Processing update');
    let installerUrl = installerAsset.browser_download_url;

    getMainWindow().webContents.send('navigate', '/updating');
    let notification = new Notification({title: trans('Mod Manager update available'), body: trans('The update will be downloaded in the background and installed immediately afterward.\nYou cannot use Mod Manager during this process!')});
    notification.show();
    console.log(installerUrl);
    // app.quit();
    // process.exit(0);
}

async function updateCheck() {
    // transform this function in async one
    var opt // TODO
    var options = {
        host: 'api.github.com',
        path: `/repos/MatuxGG/ModManager/releases`,
        method: 'GET',
        headers: {
            'user-agent': 'ModManager',
            'Authorization': 'token '+getAppData().githubToken
        }
    };

    const req = https.request(options, (res) => {
        let data = '';

        res.on('data', (chunk) => {
            data += chunk;
        });

        res.on('end', () => {
            if (res.statusCode === 200 || res.statusCode == 301) {
                try {
                    let releases = JSON.parse(data);
                    if (!releases) {
                        logError('No releases for updater');
                        return;
                    }
                    let latestRelease = releases[0];
                    if (!latestRelease) {
                        logError('No latest release for updater')
                        return;
                    }
                    let latestVersion = latestRelease.tag_name;
                    let currentVersion = app.getVersion();
                    let compareResult = compareDates(currentVersion, latestVersion);
                    if (compareResult < 0) { // TODO: Inverser signe
                        let installerAsset = latestRelease.assets.find(asset => asset.name === 'ModManagerInstaller.exe');
                        if (!installerAsset) {
                            logError('No installer asset for updater');
                            return;
                        }
                        // Need update
                        processUpdate(installerAsset)
                    }
                } catch (e) {
                    logError(`Error parsing response: ${e}`);
                }
            } else {
                logError(`Request failed with status code ${res.statusCode}`);
            }
        });
    });

    req.on('error', (e) => {
        logError(`Request error: ${e}`);
    });

    req.end();
}

export async function initializeUpdater() {
    await updateCheck();
    setInterval(function() {
        updateCheck();
    }, 60000);
}