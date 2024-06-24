export class InstalledMod {
    modId: string;
    version: string | null;

    constructor(modId: string, version: string | null) {
        this.modId = modId;
        this.version = version;
    }
}