const packageJson = require('../../package.json');
const Winreg = require('winreg');
const path = require('path');

const regKey = new Winreg({
    hive: Winreg.HKLM, // Hive du registre
    key:  '\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 945360' // Chemin de la clé
});

class Config {
    constructor(version = "", sources = ["https://goodloss.fr/api/mm"], installedMods = [], installedVanilla = [],
        amongUsPath = "", dataPath = "", lg = "EN", supportId = "", favoriteMods = []) {
        this.version = version;
        if (this.version == "") {
            this.version = packageJson.version;
        }
        this.sources = sources;
        this.installedMods = this.installedMods;
        this.installedVanilla = this.installedVanilla;
        this.amongUsPath = amongUsPath;
        this.dataPath = dataPath;
        if (dataPath == "") {
            this.dataPath = path.join(process.env.APPDATA, 'ModManager7');
        }
        this.lg = lg;
        this.favoriteMods = favoriteMods;
        this.supportId = supportId;
        if (this.supportId == "") {
            this.supportId = this.generateRandomTenDigitNumber();
        }
    }

    async loadAmongUsPath() {
        try {
            const location = await this.getSteamLocation();
            this.amongUsPath = location;
        } catch (err) {
            console.error(err);
        }
    }

    async getSteamLocation() {
        return new Promise((resolve, reject) => {
            regKey.get('InstallLocation', (err, item) => {
                if (err) {
                    console.error("Erreur lors de la lecture de la clé de registre:", err);
                    reject(err);
                } else if (item) {
                    resolve(item.value);
                } else {
                    reject(null);
                }
            });
        });
    }

    generateRandomTenDigitNumber() {
        // Générer un nombre aléatoire entre 0 (inclus) et 1 (exclus)
        let randomNum = Math.random();
        
        // Transformer en un nombre à 10 chiffres
        let tenDigitNum = Math.floor(randomNum * 1e10);
    
        // Si le nombre généré a moins de 10 chiffres, ajouter des zéros au début
        return String(tenDigitNum).padStart(10, '0');
    }

    loadData(data) {
        Object.assign(this, data);
    }
}

module.exports = Config;