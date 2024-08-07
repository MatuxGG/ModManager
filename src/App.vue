<template>
  <div id="themeDiv" :class="currentTheme">
    <div v-if="isNotLoadingPage" class="bg-white dark:bg-gray-800 text-black dark:text-white text-xs flex items-center justify-center h-full w-full min-h-screen">
      <MenuLeft :miniIcons="miniIcons" :menus="menus" />
      <div class="min-h-screen max-h-screen h-full flex grow p-2 overflow-auto">
        <div class="w-full">
          <router-view></router-view>
        </div>
      </div>
      <div id="popinDiv" class="z-10 fixed bottom-0 right-0 p-2 flex flex-col gap-2">
          
      </div>
      <div id="templateFeedback" class='downloader-line bg-purple-700 w-64 flex flex-col items-center gap-1 hidden'>
        <p>How was you experience with <span class="modname"></span>?</p>
        <div class="flex items-center gap-1">
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 star">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z" />
          </svg>
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 star">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z" />
          </svg>
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 star">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z" />
          </svg>
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 star">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z" />
          </svg>
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 star">
            <path stroke-linecap="round" stroke-linejoin="round" d="M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z" />
          </svg>
        </div>
      </div>
    </div>
    <div v-else class="bg-white dark:bg-gray-800 text-black dark:text-white text-xs flex justify-center items-center h-full w-full min-h-screen">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import MenuLeft from './components/MenuLeft.vue';
import './compiled.css';
import $ from 'jquery';

import downloadImg from './assets/download.png';
import modsImg from './assets/mods.png';
import addImg from './assets/add.png';
import settingsImg from './assets/settings.png';
import creditsImg from './assets/credits.png';

import accountImg from './assets/account.png';
import discordImg from './assets/discord.png';
import githubImg from './assets/github.png';
import roadmapImg from './assets/roadmap.png';

export default {
  name: 'App',
  components: {
    MenuLeft,
  },
  data() {
    return {
      menus: [
        { href: '/store', img: downloadImg, title: 'Mods store' },
        { href: '/library', img: modsImg, title: 'Mods library' },
        // { href: '/servers', img: serversImg, title: 'Servers' }, // TODO: Servers
        // { href: '/addlocal', img: addImg, title: 'Add Mod' }, // TODO: Add local mod
        { href: '/settings', img: settingsImg, title: 'Settings' },
        { href: '/credits', img: creditsImg, title: 'Credits' },
      ],
      miniIcons: [
        { id: 'goodloss', src: accountImg, href: 'https://goodloss.fr/login' },
        { id: 'discord', src: discordImg, href: 'https://goodloss.fr/discord' },
        { id: 'github', src: githubImg, href: 'https://goodloss.fr/github' },
        { id: 'trello', src: roadmapImg, href: 'https://goodloss.fr/roadmap' },
      ]
    }
  },
  computed: {
    menusWithActiveState() {
      return this.menus.map(menu => ({
        ...menu,
        active: this.$route.path === menu.href
      }));
    },
    currentTheme() {
      if (!this.$store || !this.$store.state.appData || !this.$store.state.appData.config) {
        return "dark";
      }
      if (this.$store.state.appData.config.theme !== 'dark') {
        return "";
      }
      return "dark";
    },
    isNotLoadingPage() {
      return this.$route.path !== '/' && this.$route.path !== '/updating';
    }
  },
  watch: {
    '$route' () {
    }
  },
  methods: {
    updateAfterLoad() {
      const appData = this.$store.state.appData;
      document.getElementById("versionDiv").innerText = "Mod Manager Version " + appData.config.version;
      if (appData.config.theme === "dark") {
        document.getElementById("themeDiv").classList.remove("dark");
        document.getElementById("themeDiv").classList.add("dark");
      } else {
        document.getElementById("themeDiv").classList.remove("dark");
      }
    },
    openLink(url) {
      if (window.electronAPI && window.electronAPI.openExternal) {
        // Environnement Electron
        window.electronAPI.openExternal(url);
      } else {
        // Environnement web, ouvrir le lien dans un nouvel onglet
        window.open(url, '_blank').focus();
      }
    },
    // translateText(text) {
    //   // Regex pour trouver les expressions $t[]
    //   const regex = /\$t\[(.*?)\]/g;
    //   let matches;
    //   // Répéter la recherche et le remplacement jusqu'à ce qu'il n'y ait plus de correspondances
    //   while ((matches = regex.exec(text)) !== null) {
    //     const fullMatch = matches[0]; // $t[...]
    //     const innerContent = matches[1]; // Contenu entre les crochets
    //
    //     // Séparer la partie texte de la partie paramètres
    //     const [template, ...params] = innerContent.split(',');
    //
    //     // Appeler la fonction de traduction
    //     const translatedTemplate = this.$t(template.trim());
    //
    //     // Remplacer les paramètres % par leurs valeurs dans le texte traduit
    //     let translatedString = translatedTemplate;
    //     params.forEach(param => {
    //       translatedString = translatedString.replace('$', param.trim());
    //     });
    //
    //     // Remplacer l'expression $t[] dans le texte original
    //     text = text.replace(fullMatch, translatedString);
    //
    //     // Réinitialiser l'expression régulière pour recommencer la recherche depuis le début
    //     regex.lastIndex = 0;
    //   }
    //   return text;
    // }
  },
  provide() {
    return {
      openLink: this.openLink,
    };
  },
  mounted() {
    this.$store.dispatch('loadAppData').then(() => {
      this.$router.push('/library').then(() => {
        // Attendre que Vue mette à jour le DOM après le changement de route
        this.$nextTick(() => {
          this.updateAfterLoad();
        });
      });
    });
    window.electronAPI.receiveData('loadLanguage', (lg) => {
      this.$i18n.locale = lg;
      let trans = {};
      for (const lang in this.$translations) {
        let tab = {};
        const translations = this.$translations[lang];
        for (const key in translations) {
          tab[key] = translations[key];
        }
        trans[lang] = tab;
      }
      let transStr = JSON.stringify(trans);
      window.electronAPI.sendData('loadDataServer2', transStr);
    });
    window.electronAPI.receiveData('createPopin', (text, id, classes) => {
      let popinId = "popin-"+id;
      let parentDiv = document.getElementById("popinDiv");
      let popinDiv = document.getElementById(popinId);
      // text = this.translateText(text);
      if (!popinDiv) {
        popinDiv = document.createElement('div');
        popinDiv.id = popinId;
        popinDiv.classList.add('downloader-line', classes);
        popinDiv.style.opacity = '0'
        parentDiv.appendChild(popinDiv);
        $(popinDiv).animate({ opacity: 1 }, 500);
      }

      popinDiv.innerHTML = text;
    });

    window.electronAPI.receiveData('updatePopin', (text, id, classes) => {
      let popinId = "popin-" + id;
      let popinDiv = document.getElementById(popinId);
      // text = this.translateText(text);
      popinDiv.classList.remove();
      popinDiv.classList.add(classes);
      popinDiv.innerHTML = text;
    });

    window.electronAPI.receiveData('removePopin', (id) => {
      let popinId = "popin-"+id;
      let parentDiv = document.getElementById("popinDiv");
      let popinDiv = document.getElementById(popinId);
      setTimeout(() => {
        if (popinDiv && parentDiv.contains(popinDiv)) {
          $(popinDiv).animate({ opacity: 0 }, 500);
          setTimeout(() => {
            if (parentDiv && popinDiv) {
              parentDiv.removeChild(popinDiv);
            }
          }, 500);
        }
      }, 5000);
    });

    window.electronAPI.receiveData('createFeedback', (id, modStr, versionStr) => {
      let mod = JSON.parse(modStr);
      let popinId = "popin-"+id;
      let parentDiv = document.getElementById("popinDiv");
      let feedbackTemplate = document.getElementById("templateFeedback");
      let popinDiv = feedbackTemplate.cloneNode(true);
      popinDiv.id = popinId;
      popinDiv.classList.remove('hidden');
      popinDiv.style.opacity = '0';
      parentDiv.appendChild(popinDiv);
      $(popinDiv).animate({ opacity: 1 }, 500);
      let nameField = popinDiv.getElementsByClassName('modname')[0];
      nameField.innerText = mod.name;

      const stars = popinDiv.querySelectorAll('.star');
      let isRated = false;

      stars.forEach((star, index) => {
        star.addEventListener('mouseover', () => {
          if (!isRated) {
            fillStars(stars, index);
          }
        });

        star.addEventListener('mouseout', () => {
          if (!isRated) {
            clearHoveredStars(stars);
          }
        });

        star.addEventListener('click', () => {
          if (!isRated) {
            selectStars(stars, index);
            const rating = index + 1;
            window.electronAPI.sendData('rateMod', modStr, versionStr, rating);
            popinDiv.innerText = this.$t("Thanks for your feedback!");
            setTimeout(() => {
              if (popinDiv && parentDiv.contains(popinDiv)) {
                $(popinDiv).animate({ opacity: 0 }, 500);
                setTimeout(() => {
                  if (parentDiv && popinDiv) {
                    parentDiv.removeChild(popinDiv);
                  }
                }, 500);
              }
            }, 5000);
          }
        });
      });

      function fillStars(stars, index) {
        for (let i = 0; i <= index; i++) {
          stars[i].classList.add('hovered');
        }
        for (let i = index + 1; i < stars.length; i++) {
          stars[i].classList.remove('hovered');
        }
      }

      function clearHoveredStars(stars) {
        stars.forEach(star => {
          if (!star.classList.contains('selected')) {
            star.classList.remove('hovered');
          }
        });
      }

      function selectStars(stars, index) {
        for (let i = 0; i <= index; i++) {
          stars[i].classList.add('selected');
        }
        for (let i = index + 1; i < stars.length; i++) {
          stars[i].classList.remove('selected');
        }
      }
    });

    window.electronAPI.receiveData('handleArgs', (action, args) => {
      switch (action) {
        case "startmod":
          window.electronAPI.sendData('startMod', args[0], args[1]);
          break;
        case "startVanilla":
          window.electronAPI.sendData('startVanilla');
          break;
        case "stopCurrentMod":
          window.electronAPI.sendData('stopCurrentMod');
          break;
        default:
          break;
      }
    });

    window.electronAPI.receiveData('updateStartedMod', (startedMod) => {
      this.$store.state.appData.startedMod = startedMod;
    });

    window.electronAPI.receiveData('navigate', (route) => {
      this.$router.push(route);
    });
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.star {
  fill: none;
}

.star:hover, .star.hovered, .star.selected {
  fill: white;
}
</style>
