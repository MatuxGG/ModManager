const Config = require("./config");
const path = require('path');
const Files = require("./files");
const fs= require('fs');
const packageJson = require('../../package.json');
const {GL_API_URL, MM_CONFIG_PATH} = require("@/class/appGlobals");
// const RegionInfo = require("./regionInfo");
// const { version } = require("os");

class AppData {
    constructor() {
        this.isLoaded = false;
    }

    async loadLocalConfig() {
        console.log("Appdata load...")
        this.config = new Config(packageJson.version);
        Files.loadOrCreate(MM_CONFIG_PATH, this.config);
    }

    async load() {
        await this.config.loadAmongUsPath();
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'game'));
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'clients'));
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'mods'));
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'temp'));
        Files.createDirectoryIfNotExist(path.join(this.config.dataPath, 'data'));
        // this.regionInfo = new RegionInfo();
        // Files.loadOrCreate(regionInfoPath, this.regionInfo);
        this.githubToken = await Files.downloadString(GL_API_URL+"/github/token")
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
        fs.writeFileSync(MM_CONFIG_PATH, configData);
    }

    getModFromIdAndVersion(modId, modVersion = null) {
        for (const modSource of this.modSources) {
            const mod = modSource.mods.find(mod => mod.sid === modId);
            if (mod) {
                const version = mod.versions.find(v => v.version === modVersion);
                if (version) {
                    return [mod, version];
                }
            }
        }
        return [null, null];
    }



    isInstalledModFromIdAndVersion(modId, modVersion = null) {
        return this.config.installedMods.some(m => m.modId === modId && m.version === modVersion);
    }


    hasInstalledVanilla(gameVersion) {
        return this.config.installedVanilla.includes(gameVersion);
    }

    // updateRegionInfo(newRegionInfo) {
    //     Object.assign(this.regionInfo, JSON.parse(newRegionInfo));
    //     const configData = JSON.stringify(this.regionInfo, null, 2);
    //     fs.writeFileSync(regionInfoPath, configData);
    // }
}

module.exports = AppData;