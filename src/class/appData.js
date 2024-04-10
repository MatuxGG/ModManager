const Config = require("./config");
const path = require('path');
const appDataPath = process.env.APPDATA;
const Files = require("./files");
const configPath = path.join(appDataPath, 'ModManager7', 'config7.json');
const regionInfoPath = path.join(appDataPath, '..', 'LocalLow', 'Innersloth', 'Among Us', 'regionInfo.json');
const fs = require('fs');
const RegionInfo = require("./regionInfo");
const packageJson = require('../../package.json');
const { version } = require("os");

class AppData {
    constructor() {
        this.isLoaded = false;
    }
    async load() {
        console.log("Appdata load...")
        this.config = new Config(packageJson.version);
        await this.config.loadAmongUsPath();
        Files.loadOrCreate(configPath, this.config);
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'game'));
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'clients'));
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'mods'));
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'temp'));
        // this.regionInfo = new RegionInfo();
        // Files.loadOrCreate(regionInfoPath, this.regionInfo);
        this.githubToken = await Files.downloadString("https://goodloss.fr/api/github/token")
        this.modSources = [];
        let downloadPromises = this.config.sources.map(source => this.downloadSource(source));
        try {
            await Promise.all(downloadPromises);
        } catch (error) {
            console.error("Erreur lors du téléchargement des sources", error);
        }
        this.isLoaded = true;
        console.log("Appdata loaded")
    }

    async downloadSource(sourceUrl) {
        let sourceData = await Files.downloadString(sourceUrl);
        let newSource = new Object();
        Object.assign(newSource, JSON.parse(sourceData));
        this.modSources.push(newSource);

        let downloadPromises = this.modSources.flatMap(source => 
            source.mods
                .filter(mod => mod.type !== "allInOne" && mod.githubLink)
                .map(mod => this.downloadRelease(mod)));
        
        try {
            await Promise.all(downloadPromises);
        } catch (error) {
            console.error("Erreur lors du téléchargement des mods", error);
        }
    }

    async downloadRelease(mod) {
        mod.releases = await Files.getGithubReleases(mod.author, mod.github, this.githubToken);
        if (!mod.releases) return;
        mod.versions.forEach(version => {
            if (version.version === 'latest') {
                version.release = mod.releases[0];
                version.version = version.release.tag_name;
            } else {
                version.release = mod.releases.find(release => release.tag_name === version.version);
            }
            console.log(mod.name, version.version);
            if (version.release)
                console.log(mod.name, version.version, version.release.tag_name);
            else
                console.log(mod.name, version.version, "release missing");
        });
    }

    updateConfig(newConfig = null) {
        let configData;
        if (newConfig) {
            Object.assign(this.config, JSON.parse(newConfig));
            configData = JSON.stringify(this.config, null, 2);
        } else {
            configData = JSON.stringify(this.config);
        }
        fs.writeFileSync(configPath, configData);
    }

    // updateRegionInfo(newRegionInfo) {
    //     Object.assign(this.regionInfo, JSON.parse(newRegionInfo));
    //     const configData = JSON.stringify(this.regionInfo, null, 2);
    //     fs.writeFileSync(regionInfoPath, configData);
    // }
}

module.exports = AppData;