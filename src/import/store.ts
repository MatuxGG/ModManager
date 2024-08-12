import { createStore, Store } from 'vuex';

interface Mod {
    sid: string;
    type: string;
    name?: string;
    author?: string;
    category?: {
        sid: string;
        name: string;
        weight: number;
    };
    versions: Array<{
        version: string;
        gameVersion: string;
    }>;
}

interface AppState {
    appData: {
        config: {
            favoriteMods: InstalledMod[];
            installedMods: InstalledMod[];
        };
        modSources: Array<{
            mods: Mod[];
        }>;
        startedMod?: any;
    } | null;
}

interface ModVersion {
    version: string;
    release?: any;
}

interface InstalledMod {
    modId: string;
    version: string;
    releaseVersion: string;
}

export const store = createStore({
    state(): AppState {
        return {
            appData: null
        };
    },
    mutations: {
        setAppData(state: AppState, data: any) {
            state.appData = data;
        },
        setConfig(state: AppState, config: any) {
            if (state.appData) {
                state.appData.config = config;
            }
        }
    },
    actions: {
        loadAppData(context) {
            return new Promise((resolve) => {
                // @ts-ignore
                window.electronAPI.sendData('loadDataServer');
                // @ts-ignore
                window.electronAPI.receiveData('loadDataClient', (data: string) => {
                    context.commit('setAppData', JSON.parse(data));
                    resolve(context.rootState);
                });
                // @ts-ignore
                window.electronAPI.receiveData('updateConfig', (config: string) => {
                    context.commit('setConfig', JSON.parse(config));
                });
            });
        }
    },
    getters: {
        gameVersionOptions: (state: AppState) => {
            const versions = new Set<string>();
            if (state.appData && state.appData.modSources) {
                state.appData.modSources.forEach(source => {
                    source.mods.forEach(mod => {
                        if (mod.type !== "dependency") {
                            mod.versions.forEach(version => {
                                versions.add(version.gameVersion);
                            });
                        }
                    });
                });
            }
            return Array.from(versions).sort((a, b) => {
                let dateA = new Date(a.split('.').join('-'));
                let dateB = new Date(b.split('.').join('-'));
                return dateB.getTime() - dateA.getTime();
            });
        },
        gameVersionInstalledOptions: (state: AppState, getters: any) => {
            const versions = new Set<string>();
            if (state.appData && state.appData.modSources) {
                state.appData.modSources.forEach(source => {
                    source.mods.forEach(mod => {
                        if (mod.type !== "dependency") {
                            mod.versions.forEach(version => {
                                if (getters.isInstalledMod(mod.sid, version)) {
                                    versions.add(version.gameVersion);
                                }
                            });
                        }
                    });
                });
            }
            return Array.from(versions).sort((a, b) => {
                let dateA = new Date(a.split('.').join('-'));
                let dateB = new Date(b.split('.').join('-'));
                return dateB.getTime() - dateA.getTime();
            });
        },
        categoriesOptions: (state: AppState) => {
            const uniqueCategories: { [key: string]: { sid: string; name: string; weight: number } } = {};
            if (state.appData && state.appData.modSources) {
                state.appData.modSources.forEach(source => {
                    source.mods.forEach(mod => {
                        if (mod.type !== "dependency") {
                            const cat = mod.category;
                            if (cat && !uniqueCategories[cat.sid]) {
                                uniqueCategories[cat.sid] = cat;
                            }
                        }
                    });
                });
            }
            return Object.values(uniqueCategories).sort((a, b) => a.weight - b.weight);
        },
        categoriesInstalledOptions: (state: AppState, getters: any) => {
            const uniqueCategories: { [key: string]: { sid: string; name: string; weight: number } } = {};
            const favoriteCat = {
                sid: 'Favorites',
                name: 'Favorites',
                weight: 0,
            };
            if (getters.getFavoriteCount() > 0) {
                uniqueCategories["Favorites"] = favoriteCat;
            }
            if (state.appData && state.appData.modSources) {
                state.appData.modSources.forEach(source => {
                    source.mods.forEach(mod => {
                        if (mod.type !== "dependency") {
                            const cat = mod.category;
                            if (cat && !uniqueCategories[cat.sid] && getters.isInstalledMod(mod.sid, null)) {
                                uniqueCategories[cat.sid] = cat;
                            }
                        }
                    });
                });
            }
            return Object.values(uniqueCategories).sort((a, b) => a.weight - b.weight);
        },
        filteredMods: (state: AppState, getters: any) => (filterCategory: string, filterGameVersion: string, searchOption: string) => {
            if (!state.appData) return [];
            return state.appData.modSources.flatMap(source =>
                source.mods.filter(mod => {
                    let hasCategory = false;
                    let hasVersion = false;
                    let matchSearch = false;
                    if (mod.type === "dependency") return false;
                    if (mod.name && mod.name.toLowerCase().includes(searchOption.toLowerCase())) matchSearch = true;
                    if (mod.author && mod.author.toLowerCase().includes(searchOption.toLowerCase())) matchSearch = true;
                    mod.versions.forEach(version => {
                        if (version.version && version.version.toLowerCase().includes(searchOption.toLowerCase())) matchSearch = true;
                        if (version.gameVersion && version.gameVersion.toLowerCase().includes(searchOption.toLowerCase())) matchSearch = true;
                    });

                    if (filterCategory && filterCategory === "Favorites") {
                        hasVersion = true;
                        hasCategory = false;
                        if (mod.type === "allInOne" && getters.isFavoriteMod(mod.sid, null)) {
                            hasCategory = true;
                        } else {
                            mod.versions.forEach(version => {
                                if (getters.isFavoriteMod(mod.sid, version)) {
                                    hasCategory = true;
                                }
                            });
                        }
                    } else if (mod.type === "allInOne") {
                        hasVersion = true;
                        if (mod.category && filterCategory && mod.category.sid.toLowerCase().includes(filterCategory.toLowerCase())) {
                            hasCategory = true;
                        }
                    } else {
                        hasVersion = !filterGameVersion;
                        if (filterGameVersion) {
                            mod.versions.forEach(version => {
                                if (version.gameVersion && version.gameVersion.toLowerCase().includes(filterGameVersion.toLowerCase())) {
                                    hasVersion = true;
                                }
                            });
                        }

                        hasCategory = !filterCategory;
                        if (filterCategory) {
                            if (mod.category && mod.category.sid.toLowerCase().includes(filterCategory.toLowerCase())) {
                                hasCategory = true;
                            }
                        }
                    }

                    return hasVersion && hasCategory && matchSearch;
                })
            );
        },
        isInstalledMod: (state: AppState) => (modId: string, version: ModVersion | null) => {
            return state.appData?.config.installedMods.some(im => im.modId === modId && (version === null || im.version === version.version));
        },
        isFavoriteMod: (state: AppState) => (modId: string, version: ModVersion | null) => {
            return state.appData?.config.favoriteMods.some(fm => fm.modId === modId && (version === null || fm.version === version.version));
        },
        getFavoriteCount: (state: AppState, getters: any) => () => {
            let count = 0;
            state.appData?.config.installedMods.forEach(im => {
                let versions = state.appData?.modSources.flatMap(source => source.mods.find(m => m.sid === im.modId)?.versions);
                let favoriteVersions = versions?.filter(version => getters.isFavoriteMod(im.modId, version));
                count += favoriteVersions?.length || 0;
            });
            return count;
        },
        canBeUpdated: (state: AppState) => (modId: string, version: ModVersion | null) => {
            let installedMod: InstalledMod | undefined = state.appData?.config.installedMods.find(im => im.modId === modId && (version === null || im.version === version.version));
            if (installedMod === undefined) return false;
            if (version === null) return false;
            return installedMod.releaseVersion !== version.release.tag_name;
        },
        startedMod: (state: AppState) => () => {
            return state.appData?.startedMod;
        }
    }
});
