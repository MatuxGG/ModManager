// @ts-ignore
import axios from 'axios';
import * as fs from 'fs';
import * as path from 'path';
import Files from "./files";
// @ts-ignore
import decompress from "decompress";
import { spawn, exec } from 'child_process';
import * as os from 'os';
// @ts-ignore
import Winreg from "winreg";
import {
    AMONGUS_NEW_SETTINGS_PATH, AMONGUS_OLD_SETTINGS_PATH, AMONGUS_SETTINGS_PATH,
    getAppData, getMainWindow,
    GL_FILES_URL,
    GL_WEBSITE_URL, trans
} from "./appGlobals";
import {Mod} from "./mod";
import {ModVersion} from "./modVersion";
import {logError, updateTray} from "./functions";

let child: any = null;

class ModWorker {

    static async downloadClient(event: any, version: any): Promise<boolean> {
        try {
            const gameVersion = version.gameVersion;
            let finished = false;
            const downloadId = Date.now().toString();
            const url = `${GL_FILES_URL}/client/${gameVersion}.zip`;
            const tempPath = path.join(getAppData().config.dataPath, 'temp', `client-${gameVersion}.zip`);
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

            response.data.on('data', (chunk: any) => {
                progress += chunk.length;
                const currentTime = Date.now();
                const elapsedTime = currentTime - lastTime;
                const bytesDownloaded = progress - lastProgress;

                const percentCompleted = Math.round((progress / totalLength) * 100);

                const speed = elapsedTime > 0 ? (bytesDownloaded / (elapsedTime / 1000)) : 0;

                if (currentTime - lastTime > 100) {
                    const downloadText = `<div class='w-64'><p>`+trans('Downloading client $', gameVersion)+`</p>`+this.formatPopinProgress(percentCompleted, speed, progress, totalLength)+`</div>`;

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
                    const downloadText = `<div class='w-64'><p>`+trans('Extracting client $...', gameVersion)+`</p></div>`;
                    const downloadTextEnd = `<div class='w-64'><p>`+trans('Client $ installed!', gameVersion)+`</p></div>`;
                    this.extractZipFile(tempPath, clientPath, event, downloadText, downloadTextEnd, downloadId, "bg-green-700")
                        .then(() => {
                            resolve(true);
                        })
                        .catch((error) => {
                            reject(error);
                        });
                });
                writer.on('error', reject);
            });
        } catch (error) {
            logError('Error downloading the mod:', error);
            return false;
        }
    }

    static async downloadMod(event: any, mod: any, version: any): Promise<boolean> {
        try {
            let finished = false;
            const downloadId = Date.now().toString();
            let tempPath = path.join(getAppData().config.dataPath, 'temp', `mod-${mod.sid}-${version.version}.zip`);
            const tempWorker = path.join(getAppData().config.dataPath, 'temp', 'modWorker');
            let modPath = path.join(getAppData().config.dataPath, 'mods', `${mod.sid}-${version.version}`);

            let installType: 'zip' | 'dll' | null = null;
            let filename: string | null = null;
            let fileUrl: string | null = null;

            version.release['assets'].forEach((asset: any) => {
                if (asset['name'].endsWith('.zip')) {
                    installType = 'zip';
                    filename = asset['name'];
                    fileUrl = asset['browser_download_url'];
                }
            });

            if (installType === null) {
                version.release['assets'].forEach((asset: any) => {
                    if (asset['name'].endswith('.dll')) {
                        installType = 'dll';
                        filename = asset['name'];
                        fileUrl = asset['browser_download_url'];
                        modPath = path.join(getAppData().config.dataPath, 'mods', `${mod.sid}-${version.version}`, 'BepInEx', 'plugins');
                        tempPath = path.join(getAppData().config.dataPath, 'temp', filename);
                    }
                });
            }

            const response = await axios({
                method: 'get',
                url: fileUrl!,
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
                    const downloadText = `<div class='w-64'><p>`+trans('Downloading $', mod.name)+`</p>`+this.formatPopinProgress(percentCompleted, speed, progress, totalLength)+`</div>`;

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
                    const downloadText = `<div class='w-64'><p>`+trans('Extracting $...', mod.name)+`</p></div>`;
                    const downloadTextEnd = `<div class='w-64'><p>`+trans('$ installed!', mod.name)+`</p></div>`;
                    if (installType === 'zip') {
                        Files.deleteDirectoryIfExist(tempWorker);
                        this.extractZipFile(tempPath, tempWorker, event, downloadText, downloadTextEnd, downloadId, "bg-green-700")
                            .then(() => {
                                const rootPath = Files.getBepInExInsideDir(tempWorker);
                                Files.moveDirectory(rootPath, modPath);
                                resolve(true);
                            })
                            .catch((error) => {
                                reject(error);
                            });
                    } else if (installType === 'dll') {
                        Files.createDirectoryIfNotExist(modPath);
                        fs.cpSync(tempPath, path.join(modPath, filename!));
                        event.sender.send('updatePopin', downloadTextEnd, downloadId, "bg-green-700");
                        event.sender.send('removePopin', downloadId);
                        resolve(true);
                    }

                });
                writer.on('error', reject);
            });
        } catch (error) {
            logError('Error downloading the mod:', error);
            return false;
        }
    }

    static async extractZipFile(zipFilePath: string, outputFolderPath: string, event: any, downloadText: string, downloadTextEnd: string, downloadId: string, classes: string): Promise<boolean> {
        console.log('Extracting...');
        event.sender.send('createPopin', downloadText, downloadId, classes);
        Files.createDirectoryIfNotExist(outputFolderPath);
        try {
            await decompress(zipFilePath, outputFolderPath)
                .then(() => {
                    console.log('Extraction complete.');
                    event.sender.send('updatePopin', downloadTextEnd, downloadId, classes);
                    event.sender.send('removePopin', downloadId);
                })
                .catch((error: any) => {
                    if (error.code === 'EISDIR') {
                        console.log('Le chemin est un dossier, non un fichier. Erreur: ' + error.message);
                    } else {
                        console.log('Extraction failed : ' + error);
                    }
                });
            return true;
        } catch (err) {
            logError('Erreur lors de l\'extraction:', err);
            return false;
        }
    }

    static async uninstallMod(event: any, mod: any, version: any): Promise<void> {
        const downloadId = Date.now().toString();
        event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Uninstalling $...', mod.name)+`</p></div>`, downloadId, "bg-blue-700");
        const modPath = path.join(getAppData().config.dataPath, 'mods', `${mod.sid}-${version.version}`);
        Files.deleteDirectoryIfExist(modPath);
        event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ uninstalled!', mod.name)+`</p></div>`, downloadId, "bg-red-700");
        event.sender.send('removePopin', downloadId);
    }

    static async startMod(event: any, mod: any, version: any): Promise<void> {
        const isRunning = await this.isProcessRunning('Among Us') || getAppData().startedMod !== false;
        if (isRunning) return;

        let downloadId = Date.now().toString();
        event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Starting $...', mod.name)+`</p></div>`, downloadId, "bg-blue-700");
        const gamePath = path.join(getAppData().config.dataPath, 'game');
        const clientPath = path.join(getAppData().config.dataPath, 'clients', version.gameVersion);
        const modPath = path.join(getAppData().config.dataPath, 'mods', `${mod.sid}-${version.version}`);
        Files.deleteDirectoryIfExist(gamePath);
        Files.createDirectoryIfNotExist(gamePath);
        const promises = [
            fs.promises.cp(clientPath, gamePath, { recursive: true }),
            fs.promises.cp(modPath, gamePath, { recursive: true })
        ];
        for (const dep of version.modDependencies) {
            const [depMod, depVersion] = getAppData().getModFromIdAndVersion(dep.modDependency, dep.modVersion);
            if (depMod && depVersion) {
                const depPath = path.join(getAppData().config.dataPath, 'mods', `${depMod.sid}-${depVersion.version}`);
                promises.push(fs.promises.cp(depPath, gamePath, { recursive: true }));
            }
        }

        await Promise.all(promises);

        const amongUsPath = path.join(gamePath, 'Among Us.exe');
        this.loadGameSettings(version.version);
        this.loadData(mod, version);
        child = spawn(amongUsPath, {});

        if (child.pid) {
            getAppData().startedMod = [mod, version];
            event.sender.send('updateStartedMod', [mod, version]);
            updateTray();
            event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ started!', mod.name)+`</p></div>`, downloadId, "bg-green-700");
            event.sender.send('removePopin', downloadId);
        }

        child.on('close', () => {
            this.saveData(mod, version);
            this.saveGameSettings(version.version);
            getAppData().startedMod = false;
            event.sender.send('updateStartedMod', false);
            updateTray();
            downloadId = Date.now().toString();
            getMainWindow().show();
            getMainWindow().maximize();
            event.sender.send('createFeedback', downloadId, JSON.stringify(mod), JSON.stringify(version));

            console.log("Mod stopped");
        });
    }

    static loadData(m: Mod, v: ModVersion): void {
        let sourcePath = path.join(getAppData().config.dataPath, 'data', `${m.sid}-${v.version}`);
        if (!Files.existsFolder(sourcePath)) return;

        let targetPath = path.join(getAppData().config.dataPath, 'game', 'BepInEx', 'config');
        Files.copyDirectoryContent(sourcePath, targetPath);
    }

    static saveData(m: Mod, v: ModVersion): void {
        let sourcePath = path.join(getAppData().config.dataPath, 'game', 'BepInEx', 'config');
        let targetPath = path.join(getAppData().config.dataPath, 'data', `${m.sid}-${v.version}`);
        if (!Files.existsFolder(sourcePath)) return;

        Files.deleteDirectoryIfExist(targetPath);
        Files.createDirectoryIfNotExist(targetPath);
        Files.copyDirectoryContent(sourcePath, targetPath);
    }

    // Backward compatibility system for version 2024.3.5 and older
    static loadGameSettings(version: string): void {
        const versionParts = version.split('.');
        const versionInt = parseInt(versionParts[0], 10);

        if (versionInt <= 2023 || version === '2024.3.5') {
            if (Files.existsFolder(AMONGUS_OLD_SETTINGS_PATH)) {
                Files.copyFile(AMONGUS_OLD_SETTINGS_PATH, AMONGUS_SETTINGS_PATH);
            } else {
                Files.deleteFile(AMONGUS_SETTINGS_PATH);
            }
        } else {
            if (Files.existsFolder(AMONGUS_NEW_SETTINGS_PATH)) {
                Files.copyFile(AMONGUS_NEW_SETTINGS_PATH, AMONGUS_SETTINGS_PATH);
            } else {
                Files.deleteFile(AMONGUS_SETTINGS_PATH);
            }
        }
    }

    static saveGameSettings(version: string): void {
        const versionParts = version.split('.');
        const versionInt = parseInt(versionParts[0], 10);

        if (versionInt <= 2023 || version === '2024.3.5') {
            Files.copyFile(AMONGUS_SETTINGS_PATH, AMONGUS_OLD_SETTINGS_PATH);
        } else {
            Files.copyFile(AMONGUS_SETTINGS_PATH, AMONGUS_NEW_SETTINGS_PATH);
        }
    }

    static async startVanilla(event: any): Promise<void> {
        const isRunning = await this.isProcessRunning('Among Us') || getAppData().startedMod !== false;
        if (isRunning) return;

        const downloadId = Date.now().toString();
        event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Starting vanilla...')+`</p></div>`, downloadId, "bg-blue-700");
        const amongUsPath = path.join(getAppData().config.amongUsPath, 'Among Us.exe');

        child = spawn(amongUsPath, {});

        if (child.pid) {
            getAppData().startedMod = ["Vanilla", null];
            event.sender.send('updateStartedMod', ["Vanilla", null]);
            updateTray();
            event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('Vanilla started!')+`</p></div>`, downloadId, "bg-green-700");
            event.sender.send('removePopin', downloadId);
        }

        child.on('close', () => {
            getAppData().startedMod = false;
            event.sender.send('updateStartedMod', false);
            updateTray();
            getMainWindow().show();
            getMainWindow().maximize();

            console.log("Vanilla stopped");
        });
    }

    static async downloadBcl(event: any, mod: any): Promise<boolean> {
        try {
            let finished = false;
            const downloadId = Date.now().toString();
            const tempPath = path.join(getAppData().config.dataPath, 'temp', 'Better-CrewLink-Setup.exe');
            Files.deleteDirectoryIfExist(tempPath);

            const response = await axios({
                method: 'get',
                url: `${GL_WEBSITE_URL}/bcl`,
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
                    const downloadText = `<div class='w-64'><p>`+trans('Downloading $', mod.name)+`</p>`+this.formatPopinProgress(percentCompleted, speed, progress, totalLength)+`</div>`;

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
                            logError(`Erreur d'exécution : ${error}`);
                            console.log(`Code de sortie : ${error.code}`);
                            return;
                        }
                        if (stderr) {
                            logError(`Erreur : ${stderr}`);
                        } else {
                            event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ installed!', mod.name)+`</p></div>`, downloadId, "bg-green-700");
                            event.sender.send('removePopin', downloadId);
                            resolve(true);
                        }
                    });
                });
                writer.on('error', reject);
            });
        } catch (error) {
            logError('Error downloading the mod:', error);
            return false;
        }
    }

    static async startBcl(event: any, mod: any): Promise<void> {
        const downloadId = Date.now().toString();
        event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Starting $...', mod.name)+`</p></div>`, downloadId, "bg-blue-700");
        const regKey = new Winreg({
            hive: Winreg.HKCU,
            key: '\\SOFTWARE\\03ceac78-9166-585d-b33a-90982f435933'
        });
        regKey.get('InstallLocation', (err: any, item: any) => {
            if (err) {
                logError("Erreur lors de la lecture de la clé de registre:", err);
            } else if (item) {
                child = spawn(path.join(item.value, "Better-CrewLink.exe"), {});

                if (child.pid) {
                    getAppData().startedMod = [mod, null];
                    event.sender.send('updateStartedMod', [mod, null]);
                    updateTray();
                    event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ started!', mod.name)+`</p></div>`, downloadId, "bg-green-700");
                    event.sender.send('removePopin', downloadId);
                }

                child.on('close', () => {
                    getAppData().startedMod = false;
                    event.sender.send('updateStartedMod', false);
                    updateTray();
                });
            } else {
                console.log(null);
            }
        });
    }

    static async uninstallBcl(event: any, mod: any): Promise<void> {
        const downloadId = Date.now().toString();
        event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Uninstalling $...', mod.name)+`</p></div>`, downloadId, "bg-blue-700");

        const regKey = new Winreg({
            hive: Winreg.HKCU,
            key: '\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\03ceac78-9166-585d-b33a-90982f435933'
        });

        regKey.get('QuietUninstallString', (err: any, item: any) => {
            if (err) {
                console.log('Erreur lors de la lecture de la clé du registre:', err);
            } else {
                exec(`cmd /c ${item.value}`, { windowsHide: true }, async (error, stdout, stderr) => {
                    if (error) {
                        logError(`Erreur d'exécution : ${error}`);
                        console.log(`Code de sortie : ${error.code}`);
                        return;
                    }
                    if (stderr) {
                        logError(`Erreur : ${stderr}`);
                    } else {
                        event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ uninstalled!', mod.name)+`</p></div>`, downloadId, "bg-red-700");
                        event.sender.send('removePopin', downloadId);
                    }
                });
            }
        });

        event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ uninstalled!', mod.name)+`</p></div>`, downloadId, "bg-red-700");
        event.sender.send('removePopin', downloadId);
    }

    static async downloadChall(event: any, mod: any): Promise<boolean> {
        try {
            const downloadId = Date.now().toString();
            event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Installing $...', mod.name)+`</p></div>`, downloadId, "bg-blue-700");
            exec(`start steam://run/2160150`, (error, stdout, stderr) => {
                if (error) {
                    logError(`Erreur d'exécution : ${error}`);
                    console.log(`Code de sortie : ${error.code}`);
                    return;
                }
                if (stderr) {
                    logError(`Erreur : ${stderr}`);
                } else {
                    event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ installed!', mod.name)+`</p></div>`, downloadId, "bg-green-700");
                    event.sender.send('removePopin', downloadId);
                    return;
                }
            });
        } catch (error) {
            logError('Error downloading the mod:', error);
            return false;
        }
    }

    static async startChall(event: any, mod: any): Promise<void> {
        const downloadId = Date.now().toString();
        event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Starting $...', mod.name)+`</p></div>`, downloadId, "bg-blue-700");

        child = spawn('start steam://rungameid/2160150', { shell: true });

        child.on('error', (error: any) => {
            logError(`Error: ${error.message}`);
        });

        if (child.pid) {
            getAppData().startedMod = [mod, null];
            event.sender.send('updateStartedMod', [mod, null]);
            updateTray();
            event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ started!', mod.name)+`</p></div>`, downloadId, "bg-green-700");
            event.sender.send('removePopin', downloadId);
        }

        child.on('close', () => {
            getAppData().startedMod = false;
            event.sender.send('updateStartedMod', false);
            updateTray();
        });
    }

    static async uninstallChall(event: any, mod: any): Promise<void> {
        const downloadId = Date.now().toString();
        event.sender.send('createPopin', `<div class='w-64'><p>`+trans('Uninstalling $...', mod.name)+`</p></div>`, downloadId, "bg-blue-700");

        const regKey = new Winreg({
            hive: Winreg.HKLM,
            key: '\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 2160150'
        });

        regKey.get('UninstallString', (err: any, item: any) => {
            if (err) {
                console.log('Erreur lors de la lecture de la clé du registre:', err);
            } else {
                exec(`cmd /c ${item.value}`, { windowsHide: true }, async (error, stdout, stderr) => {
                    if (error) {
                        logError(`Erreur d'exécution : ${error}`);
                        console.log(`Code de sortie : ${error.code}`);
                        return;
                    }
                    if (stderr) {
                        logError(`Erreur : ${stderr}`);
                    } else {
                        event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ uninstalled!', mod.name)+`</p></div>`, downloadId, "bg-red-700");
                        event.sender.send('removePopin', downloadId);
                    }
                });
            }
        });

        event.sender.send('updatePopin', `<div class='w-64'><p>`+trans('$ uninstalled!', mod.name)+`</p></div>`, downloadId, "bg-red-700");
        event.sender.send('removePopin', downloadId);
    }

    static formatByteSize(bytes: number): string {
        const sizes = ["B", "KB", "MB", "GB", "TB"];
        if (bytes === 0) return '0 B';
        const i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)).toString(), 10);
        if (i === 0) return `${bytes} ${sizes[i]}`;
        return `${(bytes / (1024 ** i)).toFixed(2)} ${sizes[i]}`;
    }

    static formatPopinProgress(percentCompleted: any, speed: any, progress: any, totalLength: any): string {
        return `<p>`+trans('Progress: $%', percentCompleted)+`<p>
            <p>`+trans('Speed: $/s', this.formatByteSize(speed))+`<p>
            <p>${this.formatByteSize(progress)} / ${this.formatByteSize(totalLength)}<p>`;
    }

    static isProcessRunning(processName: string): Promise<boolean> {
        return new Promise((resolve, reject) => {
            const platform = os.platform();
            let command: string;

            if (platform === "win32") {
                command = `tasklist`;
            } else if (platform === "darwin" || platform === "linux") {
                command = `ps aux`;
            } else {
                return reject(new Error(`Plateforme non supportée : ${platform}`));
            }

            exec(command, (err, stdout, stderr) => {
                if (err) {
                    return reject(err);
                }
                if (stderr) {
                    return reject(new Error(stderr));
                }

                const isRunning = stdout.toLowerCase().includes(processName.toLowerCase());
                resolve(isRunning);
            });
        });
    }

    static async stopChild(): Promise<void> {
        if (child) {
            child.kill();
            child = null;
        }
    }
}

export default ModWorker;
