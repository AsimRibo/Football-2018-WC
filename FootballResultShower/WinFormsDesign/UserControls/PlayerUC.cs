using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utilities.Models.Player;

namespace WinFormsDesign.UserControls
{
    public partial class PlayerUC : UserControl
    {
        public PlayerUC()
        {
            InitializeComponent();
        }

        public string PlayerName 
        {
            get => lbName.Text;
            set => lbName.Text = value;
        }

        public Position PlayerPosition
        {
            get => (Position)Enum.Parse(typeof(Position), lbPosition.Text);
            set => lbPosition.Text = value.ToString();
        }

        public string PlayerNumber
        {
            get => lbShirtNumber.Text;
            set => lbShirtNumber.Text = value;
        }

        public string PlayerCaptain
        {
            get => lbCaptain.Text;
            set => lbCaptain.Text = value;
        }

        public void SetPicture(string picturePath)
        {
            pictureBoxPlayer.Image = Image.FromFile(picturePath);
            pictureBoxPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        
    }
}
