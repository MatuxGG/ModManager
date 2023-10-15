using ModManager6.Classes;
using ModManager6.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Forms
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
            this.CenterToScreen();
            FeedbackPanel.BackColor = ThemeList.theme.AppBackgroundColor;
        }

        private string record;

        public void showFeedback(string text, string record)
        {
            FeedbackTitle.Text = Translator.get("Feedback");
            FeedbackText.Text = text;
            this.record = record;
            Star1.BackgroundImage = Resources.favorite;
            Star2.BackgroundImage = Resources.favorite;
            Star3.BackgroundImage = Resources.favorite;
            Star4.BackgroundImage = Resources.favorite;
            Star5.BackgroundImage = Resources.favorite;
            this.Show();
            this.Activate();
        }

        public void hideFeedBack()
        {
            this.Hide();
        }

        private void Star1_Hover(object sender, EventArgs e)
        {
            Star1.BackgroundImage = Resources.favoriteFilled;
            Star2.BackgroundImage = Resources.favorite;
            Star3.BackgroundImage = Resources.favorite;
            Star4.BackgroundImage = Resources.favorite;
            Star5.BackgroundImage = Resources.favorite;
        }

        private void Star2_Hover(object sender, EventArgs e)
        {
            Star1.BackgroundImage = Resources.favoriteFilled;
            Star2.BackgroundImage = Resources.favoriteFilled;
            Star3.BackgroundImage = Resources.favorite;
            Star4.BackgroundImage = Resources.favorite;
            Star5.BackgroundImage = Resources.favorite;
        }

        private void Star3_Hover(object sender, EventArgs e)
        {
            Star1.BackgroundImage = Resources.favoriteFilled;
            Star2.BackgroundImage = Resources.favoriteFilled;
            Star3.BackgroundImage = Resources.favoriteFilled;
            Star4.BackgroundImage = Resources.favorite;
            Star5.BackgroundImage = Resources.favorite;
        }

        private void Star4_Hover(object sender, EventArgs e)
        {
            Star1.BackgroundImage = Resources.favoriteFilled;
            Star2.BackgroundImage = Resources.favoriteFilled;
            Star3.BackgroundImage = Resources.favoriteFilled;
            Star4.BackgroundImage = Resources.favoriteFilled;
            Star5.BackgroundImage = Resources.favorite;
        }

        private void Star5_Hover(object sender, EventArgs e)
        {
            Star1.BackgroundImage = Resources.favoriteFilled;
            Star2.BackgroundImage = Resources.favoriteFilled;
            Star3.BackgroundImage = Resources.favoriteFilled;
            Star4.BackgroundImage = Resources.favoriteFilled;
            Star5.BackgroundImage = Resources.favoriteFilled;
        }

        private void Star1_Click(object sender, EventArgs e)
        {
            Log.logToServ("1/5 " + record);
            this.hideFeedBack();
        }
        private void Star2_Click(object sender, EventArgs e)
        {
            Log.logToServ("2/5 " + record);
            this.hideFeedBack();
        }

        private void Star3_Click(object sender, EventArgs e)
        {
            Log.logToServ("3/5 " + record);
            this.hideFeedBack();
        }
        private void Star4_Click(object sender, EventArgs e)
        {
            Log.logToServ("4/5 " + record);
            this.hideFeedBack();
        }

        private void Star5_Click(object sender, EventArgs e)
        {
            Log.logToServ("5/5 " + record);
            this.hideFeedBack();
        }
    }
}
