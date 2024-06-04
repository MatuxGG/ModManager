const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('electronAPI', {
  openExternal: (url) => {
    ipcRenderer.send("openExternal", url);
  },
  openFolderDialog: (options) => ipcRenderer.invoke('openFolderDialog', options),
  sendData: (channel, ...data) => ipcRenderer.send(channel, ...data),
  receiveData: (channel, func) => {
      ipcRenderer.on(channel, (event, ...args) => func(...args));
  },
})