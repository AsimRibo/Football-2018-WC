using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Utilities.Models;

namespace WPFDesign
{
    /// <summary>
    /// Interaction logic for PlayerInfoWindow.xaml
    /// </summary>
    public partial class PlayerInfoWindow : Window
    {
        public PlayerInfoWindow(PlayerUC player, List<TeamEvent> matchStats)
        {
            InitializeComponent();
            SetValues(player.Player, matchStats);
            SetPicture(player);
        }

        private void SetValues(Player player, List<TeamEvent> matchStats)
        {
            lbPlayerName.Content = player.Name;
            lbShirtNumber.Content = $"{Properties.Resources.shirtNumberString}: {player.ShirtNumber}";
            lbPosition.Content = $"{Properties.Resources.positionString}: {player.PlayerPosition}";
            lbCaptain.Visibility = player.Captain ? Visibility.Visible : Visibility.Hidden;
            SetCardsNumber(player, matchStats);
            SetGoalsNumber(player, matchStats);
        }

        private void SetPicture(PlayerUC player)
        {
            imgPlayer.Source = player.PlayerImage;
        }

        private void SetCardsNumber(Player player, List<TeamEvent> matchStats)
        {
            lbCardsNumber.Content = $"{Properties.Resources.yellowCardsString}: {matchStats.Where(e => (e.TypeOfEvent == "yellow-card" || e.TypeOfEvent == "yellow-card-second") && e.Player == player.Name).Count()}";
        }

        private void SetGoalsNumber(Player player, List<TeamEvent> matchStats)
        {
            lbGoalsNumber.Content = $"{Properties.Resources.goalsString}: {matchStats.Where(e => (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty") && e.Player == player.Name).Count()}";
        }
    }
}
