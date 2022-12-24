const { exec } = require('child_process')

exec('php -S localhost:8232 -t app/public', (error, stdout, stderr) => {
  if (error) {
    console.error(`exec error: ${error}`)
    return
  }
  console.log(`stdout: ${stdout}`)
  console.error(`stderr: ${stderr}`)
})

const { app, BrowserWindow } = require('electron')

function createWindow () {
  // Créez la fenêtre du navigateur.
  const win = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
      nodeIntegration: true
    }
  })

  // et charge le fichier index.html de votre projet.
  win.loadURL('http://localhost:8232')
}

app.whenReady().then(createWindow)

app.on('window-all-closed', () => {
  // Sur macOS, il est commun pour une application et leur barre de menu
  // de rester active tant que l'utilisateur ne quitte pas explicitement avec Cmd + Q
  if (process.platform !== 'darwin') {
    app.quit()
  }
})

app.on('activate', () => {
  // Sur macOS, il est commun de re-créer une fenêtre de l'application quand
  // l'icône du dock est cliquée et qu'il n'y a pas d'autres fenêtres d'ouvertes.
  if (BrowserWindow.getAllWindows().length === 0) {
    createWindow()
  }
})