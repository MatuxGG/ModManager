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
          if (state.appData && state.appData.modSources) {
              state.appData.modSources.forEach(source => {
                  source.mods.forEach(mod => {
                      const cat = mod.category;
                      if (cat && !uniqueCategories[cat.sid] && getters.isInstalledMod(mod.sid, null)) {
                          uniqueCategories[cat.sid] = cat;
                      }
                  });
              });
          }
          return Object.values(uniqueCategories).sort((a, b) => a.weight - b.weight);
      },
    filteredMods: (state) => (filterCategory, filterGameVersion) => {
      return state.appData.modSources.flatMap(source =>
        source.mods.filter(mod => {
          if (mod.type === "allInOne") {
              return true;
          }
          let hasVersion = !filterGameVersion;
          if (filterGameVersion) {
            mod.versions.forEach(version => {
              if (version.gameVersion && version.gameVersion.toLowerCase().includes(filterGameVersion.toLowerCase())) {
                  hasVersion = true;
              }
            });
          }
    
          let hasCategory = !filterCategory;
          if (filterCategory) {
            if (mod.category && mod.category.sid.toLowerCase().includes(filterCategory.toLowerCase())) {
              hasCategory = true;
            }
          }

    
          return hasVersion && hasCategory;
        })
      );
    },
      isInstalledMod: (state) => (modId, version) => {
          return state.appData.config.installedMods.some(mod => mod.modId === modId && (version === null || mod.version === version));
      },
  }
});