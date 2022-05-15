using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.APIHandler;

namespace WinFormsDesign.UserControls
{
    public partial class GamesUC : UserControl
    {
        public GamesUC()
        {
            InitializeComponent();
            PrepareUC();
        }

        private void PrepareUC()
        {
            SetPicture(pictureBoxHome, $"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.RedShirt}");
            SetPicture(pictureBoxAway, $"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.BlueShirt}");
        }

        private void SetPicture(PictureBox pictureBox, string picturePath)
        {
            pictureBox.Image = Image.FromFile(picturePath);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public string HomeTeam 
        {
            get => lbHomeTeam.Text;
            set => lbHomeTeam.Text = value;
        }

        public string HomeTeamScore
        {
            get => lbHomeScore.Text;
            set => lbHomeScore.Text = value;
        }

        public string AwayTeam
        {
            get => lbAwayTeam.Text;
            set => lbAwayTeam.Text = value;
        }

        public string AwayTeamScore
        {
            get => lbAwayScore.Text;
            set => lbAwayScore.Text = value;
        }

        public string GameLocation
        {
            get => lbLocation.Text;
            set => lbLocation.Text = value;
        }

        public long NumberOfFans
        {
            get
            {
                if (long.TryParse(lbNumberOfFans.Text.ToString(), out long result))
                {
                    return result;
                }
                return 0;
            }
            set => lbNumberOfFans.Text = value.ToString();
        }

        public Image GetHomeTeamImage() => pictureBoxHome.Image;
        public Image GetAwayTeamImage() => pictureBoxAway.Image;

    }
}
