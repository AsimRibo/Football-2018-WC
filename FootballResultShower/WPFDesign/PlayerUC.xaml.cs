using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities.APIHandler;
using Utilities.Models;

namespace WPFDesign
{
    /// <summary>
    /// Interaction logic for PlayerUC.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        public Player Player { get; set; }
        public ImageSource PlayerImage { get; set; }
        public PlayerUC(Player player)
        {
            InitializeComponent();
            this.Player = player;
            Init();
        }

        private void Init()
        {
            string[] playerNameData = Player.Name.Split(' ');
            lbName.Content = playerNameData.Last();
            lbNumber.Content = Player.ShirtNumber;
        }

        public void SetPicture(string defaultPicturePath)
        {
            if (!PictureExists(Player.Name))
            {
                imgPlayer.Source = new BitmapImage(new Uri(defaultPicturePath));
                PlayerImage = imgPlayer.Source;
                return;
            }
            imgPlayer.Source = new BitmapImage(new Uri($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.CustomFolder}\\{Player.Name}.png"));
            PlayerImage = imgPlayer.Source;
        }

        private bool PictureExists(string playerName)
        {
            return File.Exists($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.CustomFolder}\\{playerName}.png");

        }
    }
}
