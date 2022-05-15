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
using Utilities;

namespace WPFDesign
{
    /// <summary>
    /// Interaction logic for TeamInfoWindow.xaml
    /// </summary>
    public partial class TeamInfoWindow : Window
    {
        public TeamInfoWindow(FootballTeam team)
        {
            InitializeComponent();
            SetValues(team);
        }

        private void SetValues(FootballTeam team)
        {
            lbTeamName.Content = team.Country;
            lbFifaCode.Content = $"{Properties.Resources.fifaCodeString}: {team.FifaCode}";
            lbMatchNumber.Content = $"{Properties.Resources.matchesPlayedString}: {team.GamesPlayed}";
            lbWinsNumber.Content = $"{Properties.Resources.winsString}: {team.Wins}";
            lbLossesNumber.Content = $"{Properties.Resources.lossesString}: {team.Losses}";
            lbDrawsNumber.Content = $"{Properties.Resources.drawsString}: {team.Draws}";
            lbScoredGoalsNumber.Content = $"{Properties.Resources.scoredGoalsString}: {team.GoalsFor}";
            lbGoalsAgainstNumber.Content = $"{Properties.Resources.goalsAgainstString}: {team.GoalsAgainst}";
            lbGoalDifferentialNumber.Content = $"{Properties.Resources.goalDiffString}: {team.GoalDifferential}";
        }
    }
}
