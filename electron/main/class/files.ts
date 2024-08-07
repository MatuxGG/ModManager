import fs from 'fs';
import path from 'path';
import https from 'https';
import {logError} from "./functions";

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

    static existsFolder(dir) {
        return fs.existsSync(dir);
    }

    static deleteDirectoryIfExist(dir) {
        if (!fs.existsSync(dir)) return;
        fs.rmSync(dir, { recursive: true });
    }

    static moveDirectory(dirSource, dirDest) {
        if (!fs.existsSync(dirSource)) return;
        fs.renameSync(dirSource, dirDest);
    }

    static copyFile(source, target) {
        if (!fs.existsSync(source)) return;
        fs.copyFileSync(source, target);
    }

    static deleteFile(file) {
        if (!fs.existsSync(file)) return;
        fs.rmSync(file);
    }

    static getAllFiles(dir) {
        return this.getAllFilesWorker(dir, dir);
    }

    static getAllFilesWorker(dir, rootDir) {
        let returnedFiles = [];
        let files = fs.readdirSync(dir);
        for (const file of files) {
            let fullFilePath = path.join(dir, file);
            let fileStats = fs.statSync(fullFilePath);
            if (!fileStats.isDirectory()) {
                let relativePath = path.relative(rootDir, fullFilePath);
                returnedFiles.push(relativePath);
            } else {
                const result = this.getAllFilesWorker(fullFilePath, rootDir);
                for (const f of result) {
                    returnedFiles.push(f);
                }
            }
        }
        return returnedFiles;
    }

    static getAllDifferentFiles(dir, files) {
        return this.getAllDifferentFilesWorker(dir, dir, files);
    }

    static getAllDifferentFilesWorker(dir, rootDir, differentFiles) {
        let returnedFiles = [];
        let files = fs.readdirSync(dir);
        for (const file of files) {
            let fullFilePath = path.join(dir, file);
            let fileStats = fs.statSync(fullFilePath);
            if (!fileStats.isDirectory()) {
                let relativePath = path.relative(rootDir, fullFilePath);
                if (!differentFiles.includes(relativePath))
                    returnedFiles.push(relativePath);
            } else {
                const result = this.getAllFilesWorker(fullFilePath, rootDir);
                for (const f of result) {
                    returnedFiles.push(f);
                }
            }
        }
        return returnedFiles;
    }

    static moveFilesIntoDirectory(rootDir, files, targetDir) {
        files.forEach(file => {
            const oldPath = path.join(rootDir, file);
            const newPath = path.join(targetDir, file);

            fs.rename(oldPath, newPath, function(err) {
                if (err) throw err;
            });
        });
    }

    static copyDirectoryContent(sourceDir, targetDir) {
        const files = fs.readdirSync(sourceDir);
        files.forEach(file => {
            const oldPath = path.join(sourceDir, file);
            const newPath = path.join(targetDir, file);

            fs.copyFileSync(oldPath, newPath);
        });
    }

    static getBepInExInsideDir(nodePath) {
        const fullPath = path.resolve(nodePath, 'BepInEx');
        if (fs.existsSync(fullPath)) {
            return nodePath;
        }

        const dirs = fs.readdirSync(nodePath, { withFileTypes: true })
            .filter(dirent => dirent.isDirectory())
            .map(dirent => path.resolve(nodePath, dirent.name));

        for (let dir of dirs) {
            const result = this.getBepInExInsideDir(dir);
            if (result !== null) {
                return result;
            }
        }

        return null;
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
                logError(error);
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

export default Files;