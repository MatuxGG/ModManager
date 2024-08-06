export class InstalledMod {
    modId: string;
    version: string | null;
    releaseVersion: string | null;

    constructor(modId: string, version: string | null, releaseVersion: string | null) {
        this.modId = modId;
        this.version = version;
        this.releaseVersion = releaseVersion;
    }
}