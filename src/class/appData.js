const Config = require("./config");
const path = require('path');
const appDataPath = process.env.APPDATA;
const Files = require("./files");

class AppData {
    constructor() {
        this.isLoaded = false;
    }
    async load() {
        console.log("Appdata load...")
        this.config = new Config();
        const configPath = path.join(appDataPath, 'ModManager7', 'config7.json');
        await this.config.loadAmongUsPath();
        Files.loadOrCreate(configPath, this.config);
        this.modSources = [];
        for (let i = 0; i < this.config.sources.length; i++) {
            const source = this.config.sources[i];
            await this.downloadSource(source);
        }
        this.isLoaded = true;
        console.log("Appdata loaded")
    }

    async downloadSource(sourceUrl) {
        let sourceData = await Files.downloadString(sourceUrl);
        let newSource = new Object();
        Object.assign(newSource, JSON.parse(sourceData));
        this.modSources.push(newSource);
    }
}

module.exports = AppData;