using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class Theme
    {
        public string name;

        public string TitleFont;
        public string SubTitleFont;
        public string XLFont;
        public string MFont;

        public int TitleSize;
        public int SubTitleSize;
        public int XLSize;
        public int MSize;

        public Color MenuBackgroundColor;
        public Color MenuButtonsColor;
        public Color MenuSubButtonsColor;
        public Color StatusBarColor;
        public Color AppBackgroundColor;
        public Color AppOverlayColor;
        public Color ButtonsColor;
        public Color TextColor;
        public Color SelectionColor;

        public Theme(string name,
            string TitleFont, string SubTitleFont, string XLFont, string MFont,
            int TitleSize, int SubTitleSize, int XLSize, int MSize,
            Color MenuBackgroundColor, Color MenuButtonsColor, Color MenuSubButtonsColor, Color StatusBarColor,
            Color AppBackgroundColor, Color AppOverlayColor, Color ButtonsColor, Color TextColor, Color SelectionColor)
        {
            this.name = name;

            this.TitleFont = TitleFont;
            this.SubTitleFont = SubTitleFont;
            this.XLFont = XLFont;
            this.MFont = MFont;

            this.TitleSize = TitleSize;
            this.SubTitleSize = SubTitleSize;
            this.XLSize = XLSize;
            this.MSize = MSize;

            this.MenuBackgroundColor = MenuBackgroundColor;
            this.MenuButtonsColor = MenuButtonsColor;
            this.MenuSubButtonsColor = MenuSubButtonsColor;
            this.StatusBarColor = StatusBarColor;
            this.AppBackgroundColor = AppBackgroundColor;
            this.AppOverlayColor = AppOverlayColor;
            this.ButtonsColor = ButtonsColor;
            this.TextColor = TextColor;
            this.SelectionColor = SelectionColor;

        }
    }
}