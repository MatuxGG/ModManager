const axios = require('axios').default;
const fs = require('fs');
const path = require('path');
const Files = require("@/class/files");
const decompress = require("decompress");
const { spawn } = require('child_process');

class ModWorker {

    static async downloadClient(event, version, appData) {
        try {
            let gameVersion = version.gameVersion;
            let finished = false;
            let downloadId = Date.now().toString();
            const url = 'https://goodloss.fr/files/client/'+gameVersion+'.zip';
            const tempPath = path.join(appData.config.dataPath, 'temp', 'client-'+gameVersion+'.zip');
            const clientPath = path.join(appData.config.dataPath, 'clients', gameVersion);

            const response = await axios({
                method: 'get',
                url: url,
                responseType: 'stream'
            });

            const totalLength = response.headers['content-length'];

            let progress = 0;
            let lastProgress = 0;
            let lastTime = Date.now();
            response.data.on('data', (chunk) => {
                progress += chunk.length;
                let currentTime = Date.now();
                let elapsedTime = currentTime - lastTime;
                let bytesDownloaded = progress - lastProgress;

                let percentCompleted = Math.round((progress / totalLength) * 100);

                let speed = elapsedTime > 0 ? (bytesDownloaded / (elapsedTime / 1000)) : 0;

                if (currentTime - lastTime > 100) {

                    let downloadText = "<div class='w-64'><p>Downloading client " + gameVersion + "</p>"
                        + "<p>Progress: " + percentCompleted + "%<p>"
                        + "<p>Speed: " + this.formatByteSize(speed) + "/s<p>"
                        + "<p>" + this.formatByteSize(progress) + " / " + this.formatByteSize(totalLength) + "<p></div>";

                    if (!finished) {
                        if (percentCompleted === 100) {
                            finished = true;
                        } else {
                            event.sender.send('showPopin', downloadText, downloadId, "bg-blue-700");
                        }
                    }
                    lastTime = currentTime;
                    lastProgress = progress;
                }
            });
            const writer = fs.createWriteStream(tempPath);
            response.data.pipe(writer);

            return new Promise((resolve, reject) => {
                writer.on('finish', () => {
                    let downloadText = "<div class='w-64'><p>Extracting client " + gameVersion + "...</p></div>";
                    let downloadTextEnd = "<div class='w-64'><p>Client " + gameVersion + " installed !</p></div>";
                    this.extractZipFile(tempPath, clientPath, event, downloadText, downloadTextEnd, downloadId, "bg-blue-700")
                        .then(() => {
                            resolve();
                        })
                        .catch((error) => {
                            reject(error);
                        });
                });
                writer.on('error', reject);
            });
        } catch (error) {
            console.error('Error downloading the mod:', error);
            return false;
        }
    }

    static async downloadMod(event, mod, version, appData) {
        try {
            let finished = false;
            let downloadId = Date.now().toString();
            const tempPath = path.join(appData.config.dataPath, 'temp', 'mod-'+mod.sid+'-'+version.version+'.zip');
            const modPath = path.join(appData.config.dataPath, 'mods', mod.sid+'-'+version.version);

            let installType = null;
            // eslint-disable-next-line no-unused-vars
            let filename = null;
            let fileUrl = null;
            version.release['assets'].forEach((asset) => {
                if (asset['name'].endsWith('.zip')) {
                    installType = 'zip';
                    filename = asset['name'];
                    fileUrl = asset['browser_download_url'];
                }
            })
            if (!installType) {
                version.release['assets'].forEach((asset) => {
                    if (asset['name'].endsWith('.dll')) {
                        installType = 'dll';
                        filename = asset['name'];
                        fileUrl = asset['browser_download_url'];
                    }
                })
            }
            const response = await axios({
                method: 'get',
                url: fileUrl,
                responseType: 'stream'
            });
    
            const totalLength = response.headers['content-length'];
    
            let progress = 0;
            let lastProgress = 0;
            let lastTime = Date.now();
            response.data.on('data', (chunk) => {
                progress += chunk.length;
                let currentTime = Date.now();
                let elapsedTime = currentTime - lastTime;
                let bytesDownloaded = progress - lastProgress;

                let percentCompleted = Math.round((progress / totalLength) * 100);

                let speed = elapsedTime > 0 ? (bytesDownloaded / (elapsedTime / 1000)) : 0;

                if (currentTime - lastTime > 100) {
                    let downloadText = "<div class='w-64'><p>Downloading " + mod.name + "</p>"
                    + "<p>Progress: " + percentCompleted + "%<p>"
                    + "<p>Speed: " + this.formatByteSize(speed) + "/s<p>"
                    + "<p>" + this.formatByteSize(progress) + " / " + this.formatByteSize(totalLength) + "<p></div>";

                    if (!finished) {
                        if (percentCompleted === 100) {
                            finished = true;
                        } else {
                            event.sender.send('showPopin', downloadText, downloadId, "bg-blue-700");
                        }
                    }

                    lastProgress = progress;
                    lastTime = currentTime;
                }

            });
            const writer = fs.createWriteStream(tempPath);
            response.data.pipe(writer);

            return new Promise((resolve, reject) => {
                writer.on('finish', () => {
                    let downloadText = "<div class='w-64'><p>Extracting " + mod.name + "...</p></div>";
                    let downloadTextEnd = "<div class='w-64'><p>" + mod.name + " installed !</p></div>";
                    this.extractZipFile(tempPath, modPath, event, downloadText, downloadTextEnd, downloadId, "bg-blue-700")
                        .then(() => {
                            resolve();
                        })
                        .catch((error) => {
                            reject(error);
                        });
                });
                writer.on('error', reject);
            });
        } catch (error) {
            console.error('Error downloading the mod:', error);
            return false;
        }
    }

    static async extractZipFile(zipFilePath, outputFolderPath, event, downloadText, downloadTextEnd, downloadId, classes) {
        console.log('Extracting...');
        event.sender.send('showPopin', downloadText, downloadId, classes);
        Files.createDirectoryIfNotExist(outputFolderPath);
        try {
            await decompress(zipFilePath, outputFolderPath)
                .then(() => {
                    console.log('Extraction complète.');
                    event.sender.send('hidePopin', downloadTextEnd, downloadId, classes);
                })
                .catch((error) => {
                    console.log('Extraction failed :' + error);
                });
            return true;
        } catch (err) {
            console.error('Erreur lors de l\'extraction:', err);
            return false;
        }
    }

    static async uninstallMod(event, mod, version, appData) {
        let downloadId = Date.now().toString();
        event.sender.send('showPopin', "<div class='w-64'><p>Uninstalling "+mod.name+"</p></div>", downloadId, "bg-blue-700");
        const modPath = path.join(appData.config.dataPath, 'mods', mod.sid+'-'+version.version);
        Files.deleteDirectoryIfExist(modPath);
        event.sender.send('hidePopin', "<div class='w-64'><p>"+mod.name+" uninstalled</p></div>", downloadId, "bg-blue-700");
    }

    static async startMod(event, mod, version, appData) {
        let downloadId = Date.now().toString();
        event.sender.send('showPopin', "<div class='w-64'><p>Starting "+mod.name+"...</p></div>", downloadId, "bg-blue-700");
        const gamePath = path.join(appData.config.dataPath, 'game');
        const clientPath = path.join(appData.config.dataPath, 'clients', version.gameVersion);
        const modPath = path.join(appData.config.dataPath, 'mods', mod.sid+'-'+version.version);
        Files.deleteDirectoryIfExist(gamePath);
        Files.createDirectoryIfNotExist(gamePath);
        fs.cpSync(clientPath, gamePath, {recursive: true});
        fs.cpSync(modPath, gamePath, {recursive: true});
        const amongUsPath = path.join(gamePath, 'Among Us.exe');

        const child = spawn(amongUsPath, {

        });

        if (child.pid) {
            console.log(`Le processus a démarré avec le PID ${child.pid}`);
        } else {
            console.error('Le processus n\'a pas pu démarrer.');
        }

        child.on('close', (code) => {
            console.log(`Le processus s'est terminé avec le code ${code}`);
        });

        event.sender.send('hidePopin', "<div class='w-64'><p>"+mod.name+" started</p></div>", downloadId, "bg-blue-700");
    }

    static formatByteSize(bytes) {
        const sizes = ["B", "KB", "MB", "GB", "TB"];
        if (bytes === 0) return '0 B';
        let i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)), 10);
        if (i === 0) return `${bytes} ${sizes[i]}`;
        return `${(bytes / (1024 ** i)).toFixed(2)} ${sizes[i]}`;
    }
}

module.exports = ModWorker;