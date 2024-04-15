import { createStore } from 'vuex';

export default createStore({
  state() {
    return {
      appData: null
    };
  },
  mutations: {
    setAppData(state, data) {
      state.appData = data;
    },
    setConfig(state, config) {
      state.appData.config = config;
    }
  },
  actions: {
    loadAppData(context) {
        return new Promise((resolve) => {
            window.electronAPI.sendData('loadDataServer');
            window.electronAPI.receiveData('loadDataClient', (data) => {
                context.commit('setAppData', JSON.parse(data));
                resolve(context.rootState);
            });
            window.electronAPI.receiveData('updateConfig', (config) => {
                context.commit('setConfig', JSON.parse(config));
            })
        });
    }
  },
  getters: {
    gameVersionOptions: (state) => {
      const versions = new Set();
      if (state.appData && state.appData.modSources) {
        state.appData.modSources.forEach(source => {
          source.mods.forEach(mod => {
            mod.versions.forEach(version => {
              versions.add(version.gameVersion);
            })
          });
        });
      }
      return Array.from(versions).sort((a, b) => {
        let dateA = new Date(a.split('.').join('-'));
        let dateB = new Date(b.split('.').join('-'));
        return dateB - dateA;
      });
    },
      gameVersionInstalledOptions: (state, getters) => {
          const versions = new Set();
          if (state.appData && state.appData.modSources) {
              state.appData.modSources.forEach(source => {
                  source.mods.forEach(mod => {
                      mod.versions.forEach(version => {
                          if (getters.isInstalledMod(mod.sid, version.version)) {
                              versions.add(version.gameVersion);
                          }
                      })
                  });
              });
          }
          return Array.from(versions).sort((a, b) => {
              let dateA = new Date(a.split('.').join('-'));
              let dateB = new Date(b.split('.').join('-'));
              return dateB - dateA;
          });
      },
    categoriesOptions: (state) => {
        const uniqueCategories = {};
        if (state.appData && state.appData.modSources) {
          state.appData.modSources.forEach(source => {
            source.mods.forEach(mod => {
              const cat = mod.category;
              if (cat && !uniqueCategories[cat.sid]) {
                uniqueCategories[cat.sid] = cat;
              }
            });
          });
        }
        return Object.values(uniqueCategories).sort((a, b) => a.weight - b.weight);
    },
      categoriesInstalledOptions: (state, getters) => {
          const uniqueCategories = {};
          const favoriteCat = {
              'sid': 'Favorites',
              'name': 'Favorites',
              'weight': '0',
          }
          if (state.appData && state.appData.modSources) {
              state.appData.modSources.forEach(source => {
                  source.mods.forEach(mod => {
                      const cat = mod.category;
                      if (cat && !uniqueCategories[cat.sid] && getters.isInstalledMod(mod.sid, null)) {
                          uniqueCategories[cat.sid] = cat;
                          if (!uniqueCategories["Favorites"]) {
                              if (state.appData.config.favoriteMods.some(m => m.modId === mod.sid)) {
                                  uniqueCategories["Favorites"] = favoriteCat;
                              }
                          }
                      }
                  });
              });
          }
          return Object.values(uniqueCategories).sort((a, b) => a.weight - b.weight);
      },
    filteredMods: (state, getters) => (filterCategory, filterGameVersion, searchOption) => {
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
                      if (getters.isFavoriteMod(mod.sid, version.version)) {
                          hasCategory = true;
                      }
                  })
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
      isInstalledMod: (state) => (modId, version) => {
        return state.appData.config.installedMods.some(mod => mod.modId === modId && (version === null || mod.version === version));
      },
      isFavoriteMod: (state) => (modId, version) => {
          return state.appData.config.favoriteMods.some(mod => mod.modId === modId && (version === null || mod.version === version));
      },
  }
});