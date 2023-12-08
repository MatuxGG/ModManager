const { ipcMain } = require('electron');
const axios = require('axios').default;
const fs = require('fs');
const path = require('path');

class ModWorker {
    static async downloadMod(event, mod, version, appData) {
        try {
            mod = JSON.parse(mod);
            version = JSON.parse(version);
            let finished = false;
            let downloadId = Date.now().toString();
            const response = await axios({
                method: 'get',
                // url: mod.downloadUrl,
                url: "https://github.com/MatuxGG/ModManager/releases/download/5.3.7/ModManagerInstaller.exe",
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

                let downloadData = {
                    downloadedSize: this.formatByteSize(progress),
                    totalSize: this.formatByteSize(totalLength),
                    percentCompleted: percentCompleted,
                    downloadSpeed: this.formatByteSize(speed) + "/s"
                };

                let downloadText = "<p>Downloading "+ mod.name + "</p>"
                    + "<p>Progress: " + percentCompleted + "%<p>"
                    +"<p>Speed: " + this.formatByteSize(speed) + "/s<p>"
                    +"<p>" + this.formatByteSize(progress) + " / " + this.formatByteSize(totalLength) + "<p>";
                
                event.sender.send('showPopin', downloadText, downloadId);

                if (!finished && percentCompleted == 100) {
                    event.sender.send('hidePopin', downloadId);
                    finished = true;
                }
            });
            const modPath = path.join(appData.config.dataPath, 'mods', mod.sid+'-'+version.version);
            const writer = fs.createWriteStream(modPath);
            response.data.pipe(writer);
    
            return new Promise((resolve, reject) => {
                writer.on('finish', resolve);
                writer.on('error', reject);
            });
        } catch (error) {
            console.error('Error downloading the mod:', error);
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