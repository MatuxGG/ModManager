const { defineConfig } = require('@vue/cli-service')
const webpack = require('webpack');
module.exports = defineConfig({
  configureWebpack: {
    plugins: [
      new webpack.DefinePlugin({
        __VUE_PROD_HYDRATION_MISMATCH_DETAILS__: 'false',
      })
    ],
  },
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
          "allowToChangeInstallationDirectory": true,
          include: "build/installer.nsh"
        }
      },
    },
  }
})
