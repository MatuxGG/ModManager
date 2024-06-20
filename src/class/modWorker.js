import {BrowserWindow} from "electron";

const axios = require('axios').default;
const fs = require('fs');
const path = require('path');
const Files = require("@/class/files");
const decompress = require("decompress");
const { spawn, exec  } = require('child_process');
const os = require('os');
const Winreg = require("winreg");
import {
    getAppData, getMainWindow,
    GL_FILES_URL,
    GL_WEBSITE_URL, MM_ICON_PATH
} from "@/class/appGlobals";
let child = null;

class ModWorker {

    static async downloadClient(event, version) {
        try {
            let gameVersion = version.gameVersion;
            let finished = false;
            let downloadId = Date.now().toString();
            const url = GL_FILES_URL+'/client/'+gameVersion+'.zip';
            const tempPath = path.join(getAppData().config.dataPath, 'temp', 'client-'+gameVersion+'.zip');
            const clientPath = path.join(getAppData().config.dataPath, 'clients', gameVersion);

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

                    let downloadText = "<div class='w-64'><p>$t[Downloading client $," + gameVersion + "]</p>"
                        + "<p>$t[Progress: $%," + percentCompleted + "]<p>"
                        + "<p>$t[Speed: $/s," + this.formatByteSize(speed) + "]<p>"
                        + "<p>" + this.formatByteSize(progress) + " / " + this.formatByteSize(totalLength) + "<p></div>";

                    if (!finished) {
                        if (percentCompleted === 100) {
                            finished = true;
                        } else {
                            event.sender.send('createPopin', downloadText, downloadId, "bg-blue-700");
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
                    let downloadText = "<div class='w-64'><p>$t[Extracting client $...," + gameVersion + "]</p></div>";
                    let downloadTextEnd = "<div class='w-64'><p>$[Client $ installed!," + gameVersion + "]</p></div>";
                    this.extractZipFile(tempPath, clientPath, event, downloadText, downloadTextEnd, downloadId, "bg-green-700")
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

    static async downloadMod(event, mod, version) {
        try {
            let finished = false;
            let downloadId = Date.now().toString();
            let tempPath = path.join(getAppData().config.dataPath, 'temp', 'mod-'+mod.sid+'-'+version.version+'.zip');
            let tempWorker = path.join(getAppData().config.dataPath, 'temp', 'modWorker');
            let modPath = path.join(getAppData().config.dataPath, 'mods', mod.sid+'-'+version.version);

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
            if (installType === null) {
                version.release['assets'].forEach((asset) => {
                    if (asset['name'].endsWith('.dll')) {
                        installType = 'dll';
                        filename = asset['name'];
                        fileUrl = asset['browser_download_url'];
                        modPath = path.join(getAppData().config.dataPath, 'mods', mod.sid+'-'+version.version, 'BepInEx', 'plugins');
                        tempPath = path.join(getAppData().config.dataPath, 'temp', filename);
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
                    let downloadText = "<div class='w-64'><p>$t[Downloading $," + mod.name + "]</p>"
                    + "<p>$t[Progress: $%," + percentCompleted + "]<p>"
                    + "<p>$t[Speed: $/s," + this.formatByteSize(speed) + "]<p>"
                    + "<p>" + this.formatByteSize(progress) + " / " + this.formatByteSize(totalLength) + "<p></div>";

                    if (!finished) {
                        if (percentCompleted === 100) {
                            finished = true;
                        } else {
                            event.sender.send('createPopin', downloadText, downloadId, "bg-blue-700");
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
                    let downloadText = "<div class='w-64'><p>$t[Extracting $...," + mod.name + "]</p></div>";
                    let downloadTextEnd = "<div class='w-64'><p>$t[$ installed!," + mod.name + "]</p></div>";
                    if (installType === 'zip') {
                        Files.deleteDirectoryIfExist(tempWorker);
                        this.extractZipFile(tempPath, tempWorker, event, downloadText, downloadTextEnd, downloadId, "bg-green-700")
                            .then(() => {
                                let rootPath = Files.getBepInExInsideDir(tempWorker);
                                Files.moveDirectory(rootPath, modPath);
                                resolve();
                            })
                            .catch((error) => {
                                reject(error);
                            });
                    } else if (installType === 'dll') {
                        Files.createDirectoryIfNotExist(modPath);
                        fs.cpSync(tempPath, path.join(modPath, filename));
                        event.sender.send('updatePopin', downloadTextEnd, downloadId, "bg-green-700");
                        event.sender.send('removePopin', downloadId);
                        resolve();
                    }

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
        event.sender.send('createPopin', downloadText, downloadId, classes);
        Files.createDirectoryIfNotExist(outputFolderPath);
        try {
            await decompress(zipFilePath, outputFolderPath)
                .then(() => {
                    console.log('Extraction complète.');
                    event.sender.send('updatePopin', downloadTextEnd, downloadId, classes);
                    event.sender.send('removePopin', downloadId);
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

    static async uninstallMod(event, mod, version) {
        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Uninstalling $...,"+mod.name+"]</p></div>", downloadId, "bg-blue-700");
        const modPath = path.join(getAppData().config.dataPath, 'mods', mod.sid+'-'+version.version);
        Files.deleteDirectoryIfExist(modPath);
        event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ uninstalled!,"+mod.name+"]</p></div>", downloadId, "bg-red-700");
        event.sender.send('removePopin', downloadId);
    }

    static async startMod(event, mod, version) {
        const savePath = path.join(getAppData().config.dataPath, 'data', mod.sid+'-'+version.version);
        // let foldersToSave = ["BepInEx/config"]; // TODO
        const isRunning = await this.isProcessRunning('Among Us') || getAppData().startedMod !== false;
        if (isRunning) return;

        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Starting $...,"+mod.name+"]</p></div>", downloadId, "bg-blue-700");
        const gamePath = path.join(getAppData().config.dataPath, 'game');
        const clientPath = path.join(getAppData().config.dataPath, 'clients', version.gameVersion);
        const modPath = path.join(getAppData().config.dataPath, 'mods', mod.sid+'-'+version.version);
        Files.deleteDirectoryIfExist(gamePath);
        Files.createDirectoryIfNotExist(gamePath);
        let promises = [];
        promises.push(fs.promises.cp(clientPath, gamePath, {recursive: true}));
        promises.push(fs.promises.cp(modPath, gamePath, {recursive: true}));
        for (const dep of version.modDependencies) {
            let [depMod, depVersion] = getAppData().getModFromIdAndVersion(dep.modDependency, dep.modVersion);
            if (depMod && depVersion) {
                const depPath = path.join(getAppData().config.dataPath, 'mods', depMod.sid+'-'+depVersion.version);
                promises.push(fs.promises.cp(depPath, gamePath, {recursive: true}));
            }
        }

        await Promise.all(promises);

        const amongUsPath = path.join(gamePath, 'Among Us.exe');
        child = spawn(amongUsPath, {});

        if (child.pid) {
            getAppData().startedMod = [mod, version];
            event.sender.send('updateStartedMod', [mod, version]);
            event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ started!,"+mod.name+"]</p></div>", downloadId, "bg-green-700");
            event.sender.send('removePopin', downloadId);
        }

        child.on('close', () => {
            Files.createDirectoryIfNotExist(savePath);
            // await this.saveData(savePath, gamePath, foldersToSave); // TODO
            getAppData().startedMod = false;
            event.sender.send('updateStartedMod', false);
            downloadId = Date.now().toString();
            getMainWindow().show();
            getMainWindow().maximize();
            event.sender.send('createFeedback', downloadId, JSON.stringify(mod), JSON.stringify(version));

            console.log("Mod stopped");
        });
    }

    static async startVanilla(event) {
        const isRunning = await this.isProcessRunning('Among Us') || getAppData().startedMod !== false;
        if (isRunning) return;

        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Starting vanilla...]</p></div>", downloadId, "bg-blue-700");
        const amongUsPath = path.join(getAppData().config.amongUsPath, 'Among Us.exe');

        child = spawn(amongUsPath, {});

        if (child.pid) {
            getAppData().startedMod = ["Vanilla", null];
            event.sender.send('updateStartedMod', ["Vanilla", null]);
            event.sender.send('updatePopin', "<div class='w-64'><p>$t[Vanilla started!]</p></div>", downloadId, "bg-green-700");
            event.sender.send('removePopin', downloadId);
        }

        child.on('close', () => {
            getAppData().startedMod = false;
            event.sender.send('updateStartedMod', false);
            downloadId = Date.now().toString();
            getMainWindow().show();
            getMainWindow().maximize();

            console.log("Vanilla stopped");
        });
    }

    // static async saveData(savePath, rootPath, foldersToSave) {
    //     let promises = foldersToSave.map(folderToSave => {
    //         let sourcePath = path.join(rootPath, folderToSave);
    //         let targetPath = path.join(savePath, folderToSave);
    //         Files.createDirectoryIfNotExist(targetPath);
    //         return fs.renameSync(sourcePath, targetPath);
    //     });
    //
    //     await Promise.all(promises);
    // }

    static async downloadBcl(event, mod){
        try {
            let finished = false;
            let downloadId = Date.now().toString();
            let tempPath = path.join(getAppData().config.dataPath, 'temp', 'Better-CrewLink-Setup.exe');
            Files.deleteDirectoryIfExist(tempPath);

            const response = await axios({
                method: 'get',
                url: GL_WEBSITE_URL+'/bcl',
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
                    let downloadText = "<div class='w-64'><p>$t[Downloading $," + mod.name + "]</p>"
                        + "<p>$t[Progress: $%," + percentCompleted + "]<p>"
                        + "<p>$t[Speed: $/s," + this.formatByteSize(speed) + "]<p>"
                        + "<p>" + this.formatByteSize(progress) + " / " + this.formatByteSize(totalLength) + "<p></div>";

                    if (!finished) {
                        if (percentCompleted === 100) {
                            finished = true;
                        } else {
                            event.sender.send('createPopin', downloadText, downloadId, "bg-blue-700");
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
                    exec(tempPath, (error, stdout, stderr) => {
                        if (error) {
                            console.error(`Erreur d'exécution : ${error}`);
                            console.log(`Code de sortie : ${error.code}`);
                            return;
                        }
                        if (stderr) {
                            console.error(`Erreur : ${stderr}`);
                        } else {
                            event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ installed!,"+mod.name+"]</p></div>", downloadId, "bg-green-700");
                            event.sender.send('removePopin', downloadId);
                            resolve();
                        }
                    });
                });
                writer.on('error', reject);
            });
        } catch (error) {
            console.error('Error downloading the mod:', error);
            return false;
        }

    }


    static async startBcl(event, mod) {
        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Starting $...,"+mod.name+"]</p></div>", downloadId, "bg-blue-700");
        const regKey = new Winreg({
            hive: Winreg.HKCU, // Hive du registre
            key:  '\\SOFTWARE\\03ceac78-9166-585d-b33a-90982f435933' // Chemin de la clé
        });
        regKey.get('InstallLocation', (err, item) => {
            if (err) {
                console.error("Erreur lors de la lecture de la clé de registre:", err);
            } else if (item) {
                child = spawn(path.join(item.value, "Better-CrewLink.exe"), {});

                if (child.pid) {
                    getAppData().startedMod = [mod, null];
                    event.sender.send('updateStartedMod', [mod, null]);
                    event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ started!,"+mod.name+"]</p></div>", downloadId, "bg-green-700");
                    event.sender.send('removePopin', downloadId);
                }

                child.on('close', () => {
                    getAppData().startedMod = false;
                    event.sender.send('updateStartedMod', false);
                });
            } else {
                console.log(null);
            }
        });
    }

    static async uninstallBcl(event, mod) {
        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Uninstalling $...,"+mod.name+"]</p></div>", downloadId, "bg-blue-700");

        const regKey = new Winreg({
            hive: Winreg.HKCU,
            key:  '\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\03ceac78-9166-585d-b33a-90982f435933'
        });

        regKey.get('QuietUninstallString', function(err, item) {
            if (err) {
                console.log('Erreur lors de la lecture de la clé du registre:', err);
            } else {
                exec(`cmd /c ${item.value}`, { windowsHide: true }, async (error, stdout, stderr) => {
                    if (error) {
                        console.error(`Erreur d'exécution : ${error}`);
                        console.log(`Code de sortie : ${error.code}`);
                        return;
                    }
                    if (stderr) {
                        console.error(`Erreur : ${stderr}`);
                    } else {
                        event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ uninstalled!,"+mod.name+"]</p></div>", downloadId, "bg-red-700");
                        event.sender.send('removePopin', downloadId);
                    }
                });
            }
        });

        event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ uninstalled!,"+mod.name+"]</p></div>", downloadId, "bg-red-700");
        event.sender.send('removePopin', downloadId);
    }

    static async downloadChall(event, mod){
        try {
            let downloadId = Date.now().toString();
            event.sender.send('createPopin', "<div class='w-64'><p>$t[Installing $...,"+mod.name+"]</p></div>", downloadId, "bg-blue-700");
            exec(`start steam://run/2160150`, (error, stdout, stderr) => {
                if (error) {
                    console.error(`Erreur d'exécution : ${error}`);
                    console.log(`Code de sortie : ${error.code}`);
                    return;
                }
                if (stderr) {
                    console.error(`Erreur : ${stderr}`);
                } else {
                    event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ installed!,"+mod.name+"]</p></div>", downloadId, "bg-green-700");
                    event.sender.send('removePopin', downloadId);
                    return;
                }
            });
        } catch (error) {
            console.error('Error downloading the mod:', error);
            return false;
        }

    }


    static async startChall(event, mod) {
        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Starting $...,"+mod.name+"]</p></div>", downloadId, "bg-blue-700");

        child = spawn('start steam://rungameid/2160150', { shell: true });

        child.on('error', (error) => {
            console.error(`Error: ${error.message}`);
        });

        if (child.pid) {
            getAppData().startedMod = [mod, null];
            event.sender.send('updateStartedMod', [mod, null]);
            event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ started!,"+mod.name+"]</p></div>", downloadId, "bg-green-700");
            event.sender.send('removePopin', downloadId);
        }

        child.on('close', () => {
            getAppData().startedMod = false;
            event.sender.send('updateStartedMod', false);
        });
    }

    static async uninstallChall(event, mod) {
        let downloadId = Date.now().toString();
        event.sender.send('createPopin', "<div class='w-64'><p>$t[Uninstalling $...,"+mod.name+"]</p></div>", downloadId, "bg-blue-700");

        const regKey = new Winreg({
            hive: Winreg.HKLM,
            key:  '\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 2160150'
        });

        regKey.get('UninstallString', function(err, item) {
            if (err) {
                console.log('Erreur lors de la lecture de la clé du registre:', err);
            } else {
                exec(`cmd /c ${item.value}`, { windowsHide: true }, async (error, stdout, stderr) => {
                    if (error) {
                        console.error(`Erreur d'exécution : ${error}`);
                        console.log(`Code de sortie : ${error.code}`);
                        return;
                    }
                    if (stderr) {
                        console.error(`Erreur : ${stderr}`);
                    } else {
                        event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ uninstalled!,"+mod.name+"]</p></div>", downloadId, "bg-red-700");
                        event.sender.send('removePopin', downloadId);
                    }
                });
            }
        });

        event.sender.send('updatePopin', "<div class='w-64'><p>$t[$ uninstalled!,"+mod.name+"]</p></div>", downloadId, "bg-red-700");
        event.sender.send('removePopin', downloadId);
    }

    static formatByteSize(bytes) {
        const sizes = ["B", "KB", "MB", "GB", "TB"];
        if (bytes === 0) return '0 B';
        let i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)), 10);
        if (i === 0) return `${bytes} ${sizes[i]}`;
        return `${(bytes / (1024 ** i)).toFixed(2)} ${sizes[i]}`;
    }

    static isProcessRunning(processName) {
        return new Promise((resolve, reject) => {
            // Obtenez le système d'exploitation
            const platform = os.platform();

            // Construisez la commande en fonction du système d'exploitation
            let command;
            if (platform === "win32") { // Pour Windows
                command = `tasklist`;
            } else if (platform === "darwin" || platform === "linux") { // Pour macOS et Linux
                command = `ps aux`;
            } else {
                return reject(new Error(`Plateforme non supportée : ${platform}`));
            }

            // Exécutez la commande
            exec(command, (err, stdout, stderr) => {
                if (err) {
                    return reject(err);
                }
                if (stderr) {
                    return reject(new Error(stderr));
                }

                // Vérifiez si le nom du processus est dans la sortie
                const isRunning = stdout.toLowerCase().includes(processName.toLowerCase());
                resolve(isRunning);
            });
        });
    }

    static async stopChild() {
        if (child) {
            child.kill();
            child = null;
        }
    }
}

export default ModWorker;