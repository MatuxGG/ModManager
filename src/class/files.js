const fs = require('fs');
const path = require('path');
const https = require('https');

class Files {
    static loadOrCreate(dir, objet) {
        if (!fs.existsSync(dir)) {
            const json = JSON.stringify(objet, null, 2);

            const dossier = path.dirname(dir);
            if (!fs.existsSync(dossier)) {
                fs.mkdirSync(dossier, { recursive: true });
            }

            fs.writeFileSync(dir, json, 'utf8');
        } else {
            const data = fs.readFileSync(dir, 'utf8');
            const objetJson = JSON.parse(data);
            objet.loadData(objetJson);
        }
    }

    static createDirectoryIfNotExist(dir) {
        fs.mkdirSync(dir, { recursive: true });
    }

    static deleteDirectoryIfExist(dir) {
        if (!fs.existsSync(dir)) return;
        fs.rmSync(dir, { recursive: true });
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

    static async getGithubReleases(author, repo, token) {
        return new Promise((resolve, reject) => {
            var options = {
                host: 'api.github.com',
                path: `/repos/${author}/${repo}/releases`,
                method: 'GET',
                headers: {
                    'user-agent': 'ModManager',
                    'Authorization': 'token '+token
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