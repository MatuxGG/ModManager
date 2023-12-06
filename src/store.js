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
    }
  },
  actions: {
    loadAppData(context) {
        window.electronAPI.sendData('loadDataServer');
        window.electronAPI.receiveData('loadDataClient', (data) => {
            context.commit('setAppData', JSON.parse(data));
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
    filteredMods: (state) => (filterCategory, filterGameVersion) => {
      console.log(state.appData.modSources)
      return state.appData.modSources.flatMap(source =>
        source.mods.filter(mod => {
          if (mod.type == "allInOne") return true;
          let hasVersion = filterGameVersion ? false : true;
          if (filterGameVersion) {
            mod.versions.forEach(version => {
              if (version.gameVersion && version.gameVersion.toLowerCase().includes(filterGameVersion.toLowerCase())) {
                hasVersion = true;
              }
            });
          }
    
          let hasCategory = filterCategory ? false : true;
          if (filterCategory) {
            if (mod.category && mod.category.sid.toLowerCase().includes(filterCategory.toLowerCase())) {
              hasCategory = true;
            }
          }
    
          return hasVersion && hasCategory;
        })
      );
    }
  }
});