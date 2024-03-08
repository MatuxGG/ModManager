const axios = require('axios').default;
const fs = require('fs');
const path = require('path');
const streamZip = require('node-stream-zip');

class ModWorker {
    static async downloadMod(event, mod, version, appData) {
        try {
            mod = JSON.parse(mod);
            version = JSON.parse(version);
            let finished = false;
            let downloadId = Date.now().toString();
            const tempPath = path.join(appData.config.dataPath, 'temp', 'mod-'+mod.sid+'-'+version.version+'.zip');
            const modPath = path.join(appData.config.dataPath, 'mods', mod.sid+'-'+version.version);

            let installType = null;
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
                lastProgress = progress;
                lastTime = currentTime;

                let downloadText = "<div class='w-64'><p>Downloading "+ mod.name + "</p>"
                    + "<p>Progress: " + percentCompleted + "%<p>"
                    +"<p>Speed: " + this.formatByteSize(speed) + "/s<p>"
                    +"<p>" + this.formatByteSize(progress) + " / " + this.formatByteSize(totalLength) + "<p></div>";
                

                if (!finished) {
                    if (percentCompleted === 100) {
                        event.sender.send('hidePopin', downloadText, downloadId, "bg-blue-700");
                        finished = true;
                        this.extractZipFile(tempPath, modPath);
                    } else {
                        event.sender.send('showPopin', downloadText, downloadId, "bg-blue-700");
                    }
                }


            });
            const writer = fs.createWriteStream(tempPath);
            response.data.pipe(writer);
    
            return new Promise((resolve, reject) => {
                writer.on('finish', resolve);
                writer.on('error', reject);
            });
        } catch (error) {
            console.error('Error downloading the mod:', error);
        }
    }

    static async extractZipFile(zipFilePath, outputFolderPath) {

        try {
            console.log(zipFilePath);
            const zip = new streamZip.async({ file: zipFilePath });
            console.log('test');
            // Obtenir les entrées (fichiers et dossiers) de l'archive
            const entries = await zip.entries();
            for (const entry of Object.values(entries)) {
                const fullPath = path.join(outputFolderPath, entry.name);
                if (entry.isDirectory) {
                    await fs.mkdir(fullPath, { recursive: true });
                } else {
                    await fs.mkdir(path.dirname(fullPath), { recursive: true });
                    await zip.extract(entry.name, fullPath);
                }
            }
            console.log('Extraction complète.');
        } catch (err) {
            console.error('Erreur lors de l\'extraction:', err);
        } finally {
            await zip.close();
        }
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