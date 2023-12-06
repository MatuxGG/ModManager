const { contextBridge, ipcRenderer, shell } = require('electron');

contextBridge.exposeInMainWorld('electronAPI', {
  openExternal: (url) => {
    shell.openExternal(url);
  },
  sendData: (channel, data) => ipcRenderer.send(channel, data),
  receiveData: (channel, func) => {
      ipcRenderer.on(channel, (event, ...args) => func(...args));
  }
})