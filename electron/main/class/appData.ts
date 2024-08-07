import Config from "./config";
import path from 'path';
import Files from "./files";
import fs from 'fs';
import { GL_API_URL, MM_CONFIG_PATH, getAppData } from "./appGlobals";
// @ts-ignore
import { app, BrowserWindow } from 'electron';
import {ModSource} from "./modSource";
import {Mod} from "./mod";
import {ModVersion} from "./modVersion";
import {logError, logToServ} from "./functions";

// const RegionInfo = require("./regionInfo");
// const { version } = require("os");


class AppData {
    private isLoaded: boolean;
    private isUpdating: boolean;
    private config: Config;
    private githubToken: string;
    private modSources: ModSource[];
    private startedMod: boolean;
    private subFolders = ['game', 'clients', 'mods', 'temp', 'data'];

    constructor() {
        this.isLoaded = false;
        this.isUpdating = false;
        this.startedMod = false;
    }

    async loadLocalConfig(): Promise<void> {
        console.log("Appdata load...");
        this.config = new Config(app.getVersion());
        this.githubToken = <string>await Files.downloadString(`${GL_API_URL}/github/token`);
        await Files.loadOrCreate(MM_CONFIG_PATH, this.config);
    }

    async load(): Promise<void> {
        await this.config.loadAmongUsPath();
        Files.createDirectoryIfNotExist(this.config.dataPath);
        // Delete Mod Manager 5 folder if exist
        let ModManager5Path = path.join(process.env.APPDATA, 'ModManager');
        Files.deleteDirectoryIfExist(ModManager5Path);
        this.subFolders.forEach(folder => Files.createDirectoryIfNotExist(path.join(this.config.dataPath, folder)));
        this.modSources = [];
        let downloadPromises = this.config.sources.map(source => this.downloadSource(source));
        try {
            await Promise.all(downloadPromises);
        } catch (error) {
            logError("Erreur lors du téléchargement des sources", error);
        }
        this.isLoaded = true;
        console.log("Appdata loaded");
    }

    async resetApp(): Promise<void> {
        Files.deleteDirectoryIfExist(this.config.dataPath);
        this.config = new Config(app.getVersion());
        this.updateConfig();
        app.quit()
        process.exit(0)
    }

    async changeDataFolder(newFolder: string): Promise<boolean> {
        if (Files.existsFolder(newFolder)) {
            this.subFolders.forEach(folder => Files.moveDirectory(path.join(this.config.dataPath, folder), path.join(newFolder, folder)));
            this.config.dataPath = newFolder;
            this.updateConfig();
            return true;
        }
        return false;
    }

    async downloadSource(sourceUrl: string): Promise<void> {
        let sourceData = await Files.downloadString(sourceUrl);
        let newSource: ModSource = JSON.parse(<string>sourceData);
        this.modSources.push(newSource);

        let downloadPromises = this.modSources.flatMap(source =>
            source.mods
                .filter(mod => mod.type !== "allInOne" && mod.githubLink)
                .map(mod => this.downloadRelease(mod))
        );

        try {
            await Promise.all(downloadPromises);
        } catch (error) {
            logError("Erreur lors du téléchargement des mods", error);
        }

        // Cleanup mods that have no releases
        this.modSources.forEach(source => {
            source.mods = source.mods.filter(mod => mod.type === 'allInOne' || !mod.githubLink || mod.versions.some(version => version.release));
        });
    }

    async downloadRelease(mod: Mod): Promise<void> {
        mod.releases = <any>await Files.getGithubReleases(mod.author, mod.github, this.githubToken);
        if (!mod.releases) return;

        mod.versions.forEach(version => {
            if (version.version === 'latest') {
                version.release = mod.releases[0];
            } else {
                version.release = mod.releases.find(release => release.tag_name === version.version);
            }
            // console.log(mod.name, version.version); LOG
            // if (version.release) {
            //     console.log(mod.name, version.version, version.release.tag_name);
            // } else {
            //     console.log(mod.name, version.version, "release missing");
            // }
        });
    }

    updateConfig(newConfig: string | null = null): void {
        let configData: string;
        if (newConfig) {
            Object.assign(this.config, JSON.parse(newConfig));
            configData = JSON.stringify(this.config, null, 2);
        } else {
            configData = JSON.stringify(this.config, null, 2);
        }
        fs.writeFileSync(MM_CONFIG_PATH, configData);
    }

    getModFromIdAndVersion(modId: string, modVersion: string | null = null): [Mod | null, ModVersion | null] {
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

    isInstalledModFromIdAndVersion(modId: string, modVersion: string | null = null): boolean {
        return this.config.installedMods.some(m => m.modId === modId && m.version === modVersion);
    }

    getInstalledModVersions(modId: string): { modId: string, version: string }[] {
        return this.config.installedMods.filter(m => m.modId === modId);
    }

    getModVersions(modId: string): ModVersion[] | null {
        for (const modSource of this.modSources) {
            const mod = modSource.mods.find(mod => mod.sid === modId);
            if (mod) {
                return mod.versions;
            }
        }
        return null;
    }

    getMod(modId: string): Mod | null {
        for (const modSource of this.modSources) {
            const mod = modSource.mods.find(mod => mod.sid === modId);
            if (mod) {
                return mod;
            }
        }
        return null;
    }

    hasInstalledVanilla(gameVersion: string): boolean {
        return this.config.installedVanilla.includes(gameVersion);
    }
}

export default AppData;