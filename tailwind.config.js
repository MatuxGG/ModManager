/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: [
    "./src/**/*.{vue,js,ts}",
    "./electron/**/*.{vue,js,ts}"
  ],
  theme: {
    extend: {
      minWidth: {
        '52': '13rem',
        '64': '256px',
      }
    }
  },
  plugins: [],
}