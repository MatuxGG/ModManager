const Config = require("./config");
const path = require('path');
const appDataPath = process.env.APPDATA;
const Files = require("./files");
const configPath = path.join(appDataPath, 'ModManager7', 'config7.json');
const regionInfoPath = path.join(appDataPath, '..', 'LocalLow', 'Innersloth', 'Among Us', 'regionInfo.json');
const fs = require('fs');
const RegionInfo = require("./regionInfo");

class AppData {
    constructor() {
        this.isLoaded = false;
    }
    async load() {
        console.log("Appdata load...")
        this.config = new Config();
        await this.config.loadAmongUsPath();
        Files.loadOrCreate(configPath, this.config);
        this.regionInfo = new RegionInfo();
        Files.loadOrCreate(regionInfoPath, this.regionInfo);
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

    updateConfig(newConfig) {
        Object.assign(this.config, JSON.parse(newConfig));
        const configData = JSON.stringify(this.config, null, 2);
        fs.writeFileSync(configPath, configData);
    }

    updateRegionInfo(newRegionInfo) {
        Object.assign(this.regionInfo, JSON.parse(newRegionInfo));
        const configData = JSON.stringify(this.regionInfo, null, 2);
        fs.writeFileSync(regionInfoPath, configData);
    }
}

module.exports = AppData;