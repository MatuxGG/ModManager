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

    static async getGithubReleases(author, repo) {
        return new Promise((resolve, reject) => {
            var options = {
                host: 'api.github.com',
                path: `/repos/${author}/${repo}/releases`,
                method: 'GET',
                headers: {
                    'user-agent': 'ModManager',
                    'Authorization': 'token ghp...'
                }
            };
    
            const req = https.request(options, (res) => {
                let data = '';
    
                res.on('data', (chunk) => {
                    data += chunk;
                });
    
                res.on('end', () => {
                    if (res.statusCode === 200 || res.statusCode == 301) {
                        try {
                            let parsedData = JSON.parse(data);
                            resolve(parsedData);
                            console.log("Loaded releases for mod: "+author+"/"+repo);
                        } catch (e) {
                            reject(`Error parsing response: ${e}`);
                        }
                    } else {
                        reject(`Request failed with status code ${res.statusCode}`);
                    }
                });
            });
    
            req.on('error', (e) => {
                reject(`Request error: ${e}`);
            });
    
            req.end();
        });
    }
}

module.exports = Files;