/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: [
    "./src/**/*.{vue,js,ts}"
  ],
  theme: {
    extend: {
      minWidth: {
        '64': '256px',
      }
    }
  },
  plugins: [],
}