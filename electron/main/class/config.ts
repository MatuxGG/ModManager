// @ts-ignore
import Winreg from 'winreg';
import path from 'path';
import {GL_API_URL, getAppData, trans, AMONGUS_DOWNLOAD_LINK} from './appGlobals';
import Files from './files';
import { InstalledMod } from './installedMod';
import {ModVersion} from "./modVersion";
import {Mod} from "./mod";
import {logError} from "./functions";
import {app, dialog, Notification, shell} from "electron";

const regKey = new Winreg({
    hive: Winreg.HKLM, // Hive du registre
    key: '\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 945360' // Chemin de la clé
});

class Config {
    version: string;
    sources: string[];
    installedMods: InstalledMod[];
    installedVanilla: string[];
    amongUsPath: string;
    dataPath: string;
    lg: string;
    supportId: string;
    favoriteMods: InstalledMod[];
    minimizeToTray: boolean;
    launchOnStartup: boolean;
    theme: string;

    constructor(
        version = "",
        sources = [`${GL_API_URL}/mm`],
        installedMods: InstalledMod[] = [],
        installedVanilla: string[] = [],
        amongUsPath = "",
        dataPath = "",
        lg = "en",
        supportId = "",
        favoriteMods: InstalledMod[] = [],
        minimizeToTray = false,
        launchOnStartup = true,
        theme = "dark"
    ) {
        this.version = version;
        this.sources = sources;
        this.installedMods = installedMods;
        this.installedVanilla = installedVanilla;
        this.amongUsPath = amongUsPath;
        this.dataPath = dataPath || path.join(process.env.APPDATA || '', 'ModManager7', 'ModManager7Data');
        this.lg = lg;
        this.favoriteMods = favoriteMods;
        this.supportId = supportId || this.generateRandomTenDigitNumber();
        this.minimizeToTray = minimizeToTray;
        this.launchOnStartup = launchOnStartup;
        this.theme = theme;
    }

    async loadAmongUsPath(): Promise<void> {
        try {
            this.amongUsPath = await this.getSteamLocation();
        } catch (err) {
            let notification = new Notification({ title: trans('Among Us not found'), body: trans('Please uninstall and reinstall it to solve the issue.\nMod Manager will close!') });
            notification.show();
            shell.openExternal(AMONGUS_DOWNLOAD_LINK);
            app.quit()
            process.exit(0)
        }
    }

    async getSteamLocation(): Promise<string> {
        return new Promise((resolve, reject) => {
            regKey.get('InstallLocation', (err, item) => {
                if (err) {
                    logError("Erreur lors de la lecture de la clé de registre:", err);
                    reject(err);
                } else if (item) {
                    resolve(item.value);
                } else {
                    reject(new Error("Location not found"));
                }
            });
        });
    }

    generateRandomTenDigitNumber(): string {
        let randomNum = Math.random();
        let tenDigitNum = Math.floor(randomNum * 1e10);
        return String(tenDigitNum).padStart(10, '0');
    }

    loadData(data: Partial<Config>): void {
        Object.assign(this, data);
    }

    addInstalledVanilla(gameVersion: string): void {
        if (!this.installedVanilla.includes(gameVersion)) {
            this.installedVanilla.push(gameVersion);
        }
    }

    addInstalledMod(mod: Mod, version: ModVersion | null): void {
        let versionString = version === null ? null : version.version;
        let releasedVersion = version === null || version.release === null ? null : version.release.tag_name;
        if (!this.installedMods.some(m => m.modId === mod.sid && m.version === versionString && m.releaseVersion === releasedVersion)) {
            this.installedMods.push({ modId: mod.sid, version: versionString, releaseVersion: releasedVersion });
        }
    }

    removeInstalledMod(mod: { sid: string }, version: { version: string } | null): void {
        const index = this.installedMods.findIndex(installedMod =>
            installedMod.modId === mod.sid && (version === null || installedMod.version === version.version));
        if (index !== -1) {
            this.installedMods.splice(index, 1);
        }
    }

    addFavoriteMod(mod: Mod, version: ModVersion): void {
        if (!this.favoriteMods.some(m => m.modId === mod.sid && (version === null || m.version === version.version))) {
            this.favoriteMods.push({ modId: mod.sid, version: version === null ? null : version.version, releaseVersion: null });
        }
    }

    removeFavoriteMod(mod: { sid: string }, version: { version: string } | null): void {
        const index = this.favoriteMods.findIndex(favoriteMod =>
            favoriteMod.modId === mod.sid && (version === null || favoriteMod.version === version.version));
        if (index !== -1) {
            this.favoriteMods.splice(index, 1);
        }
    }
}

export default Config;