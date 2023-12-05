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
    filteredMods: (state) => (filterName, filterAuthor, filterGameVersion) => {
      return state.appData.modSources.flatMap(source =>
        source.mods.filter(mod =>
          mod.name.toLowerCase().includes(filterName.toLowerCase()) &&
          mod.author.toLowerCase().includes(filterAuthor.toLowerCase()) &&
          mod.gameVersion.toLowerCase().includes(filterGameVersion.toLowerCase())
        )
      );
    }
  }
});