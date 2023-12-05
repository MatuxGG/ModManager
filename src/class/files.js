const fs = require('fs');
const path = require('path');
const https = require('https');

class Files {
    static loadOrCreate(dir, objet) {
        if (!fs.existsSync(dir)) {
            const json = JSON.stringify(objet, null, 2); // Le "2" est pour un formatage plus lisible
        
            // Créez le dossier si nécessaire
            const dossier = path.dirname(dir);
            if (!fs.existsSync(dossier)) {
                fs.mkdirSync(dossier, { recursive: true });
            }
        
            // Écrivez le JSON dans un nouveau fichier
            fs.writeFile(dir, json, 'utf8', (err) => {
                if (err) {
                    console.log(err);
                    return;
                }
            });
        } else {
            fs.readFile(dir, 'utf8', (err, data) => {
                if (err) {
                    console.log(err);
                    return;
                }
                
                // Parser le JSON
                const objetJson = JSON.parse(data);
            
                // Transformer en instance de MaClasse
                objet.loadData(objetJson);
            });
        }
    }

    static async downloadString(url) {
        return new Promise((resolve, reject) => {
            const req = https.get(url, { rejectUnauthorized: false }, (res) => {
                let data = '';

                res.on('data', (chunk) => {
                    data += chunk;
                });

                res.on('end', () => {
                    resolve(data);
                });
            });

            req.on('error', (error) => {
                console.error(error);
                reject(error);
            });

            req.end();
        });
    }
}

module.exports = Files;