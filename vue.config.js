const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  pluginOptions: {
    electronBuilder: {
      builderOptions: {
        productName: "Mod Manager",
        appId: 'modmanager7',
        win: {
          "target": [
            "nsis"
          ],
          icon: 'public/modmanager.png',
        },
        "nsis": {
          "installerIcon": "public/modmanager.ico",
          "uninstallerIcon": "public/modmanager.ico",
          "oneClick": false,
          "allowToChangeInstallationDirectory": true
        }
      },
    },
  }
})
