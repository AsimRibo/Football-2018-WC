using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDesign.UserControls
{
    public partial class PlayerCardsUC : UserControl
    {
        public PlayerCardsUC()
        {
            InitializeComponent();
        }

        public string PlayerName
        {
            get => lbName.Text;
            set => lbName.Text = value;
        }

        public string PlayerCards
        {
            get => lbCards.Text;
            set => lbCards.Text = value;
        }



        public void SetPicture(string picturePath)
        {
            pictureBoxPlayer.Image = Image.FromFile(picturePath);
            pictureBoxPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Image GetImage() => pictureBoxPlayer.Image;
        

    }
}
