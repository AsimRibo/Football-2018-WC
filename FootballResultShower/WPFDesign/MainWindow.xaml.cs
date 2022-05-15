using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using Utilities;
using Utilities.APIHandler;
using Utilities.DAL;
using Utilities.Enums;
using Utilities.Models;
using static Utilities.Models.Player;

namespace WPFDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string EN = "en";

        private List<StackPanel> homeTeamPlaces;
        private List<StackPanel> awayTeamPlaces;

        private IDataHandling dataRepo;
        private ISettings settingsRepo;

        Match currentMatch;
        IList<FootballTeam> teams;

        public MainWindow()
        {
            CheckForSettings();
            SetCulture();
            InitializeComponent();
            SetScreenSize();
        }

        


        private void SetCulture()
        {
            CultureInfo culture = new CultureInfo(UserSettings.Selectedlanguage);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        private void CheckForSettings()
        {
            settingsRepo = RepositoryFactory.GetSettings();
            if (!(settingsRepo.CheckDoesScreenSizeExist() && settingsRepo.CheckDoSettingsExist()))
            {
                new Settings().ShowDialog();
                if (settingsRepo.CheckDoSettingsExist())
                {
                    settingsRepo.LoadSettings();
                }
            }
            else
            {
                settingsRepo.LoadSettings();
                settingsRepo.LoadScreenSize();
                SetScreenSize();
            }
        }

        private void Init()
        {
            dataRepo = RepositoryFactory.GetRepository(UserSettings.ConnectionType);
            FillStackPanels();
        }

        private void FillStackPanels()
        {
            homeTeamPlaces = new List<StackPanel>
            {
                homeGoalkeeperStackPanel,
                homeDefenderStackPanel,
                homeMidfielderStackPanel,
                homeAttackStackPanel
            };

            awayTeamPlaces = new List<StackPanel>
            {
                awayGoalkeeperStackPanel,
                awayDefenderStackPanel,
                awayMidfielderStackPanel,
                awayAttackStackPanel
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            FillComboBoxAsync();
        }

        private async void FillComboBoxAsync()
        {
            try
            {
                teams = await dataRepo.GetTeamsAsync();
                cmbFavoriteTeam.ItemsSource = teams;
                if (!string.IsNullOrEmpty(UserSettings.SelectedFootballTeam))
                {
                    FootballTeam favTeam = teams.Where(team => team.Country == UserSettings.SelectedFootballTeam).FirstOrDefault();
                    cmbFavoriteTeam.SelectedIndex = teams.IndexOf(favTeam);
                }
                else
                {
                    cmbFavoriteTeam.SelectedIndex = 0;
                    UserSettings.SelectedFootballTeam = ((FootballTeam)cmbFavoriteTeam.SelectedItem).Country;
                    UserSettings.FifaCode = ((FootballTeam)cmbFavoriteTeam.SelectedItem).FifaCode;
                }

                
                FillSecondComboBox();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.errorMsg, Properties.Resources.errorTitle);
            }
            
        }

        private async void FillSecondComboBox()
        {
            try
            {
                IList<FootballTeam> secondTeams = new List<FootballTeam>();
                IList<Match> matches = await dataRepo.GetMatchesAsync(UserSettings.FifaCode, UserSettings.SelectedFootballTeam);
                matches.ToList().ForEach(match =>
                {
                    if (match.HomeTeam.Country != UserSettings.SelectedFootballTeam)
                    {
                        secondTeams.Add(teams.First(team => team.Country == match.HomeTeam.Country));
                    }
                    else
                    {
                        secondTeams.Add(teams.First(team => team.Country == match.AwayTeam.Country));
                    }
                });

                cmbSecondTeam.ItemsSource = secondTeams;
                cmbSecondTeam.SelectedIndex = 0;

                SetCurrentMatch(matches);

                SetScoreAndPlayers();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.errorMsg, Properties.Resources.errorTitle);
            }



        }

        private void SetScoreAndPlayers()
        {
            if (currentMatch.HomeTeam.Country == ((FootballTeam)cmbFavoriteTeam.SelectedItem).Country)
            {
                lbFavTeamScore.Content = currentMatch.HomeTeam.Goals;
                lbSecondTeamScore.Content = currentMatch.AwayTeam.Goals;

                FillField(currentMatch.HomeTeamStatistics.StartingEleven, homeTeamPlaces);
                FillField(currentMatch.AwayTeamStatistics.StartingEleven, awayTeamPlaces);
            }
            else
            {
                lbFavTeamScore.Content = currentMatch.AwayTeam.Goals;
                lbSecondTeamScore.Content = currentMatch.HomeTeam.Goals;
                FillField(currentMatch.AwayTeamStatistics.StartingEleven, homeTeamPlaces);
                FillField(currentMatch.HomeTeamStatistics.StartingEleven, awayTeamPlaces);
            }
        }

        private void SetCurrentMatch(IList<Match> matches)
        {
            FootballTeam firstTeam = (FootballTeam)cmbFavoriteTeam.SelectedItem;
            FootballTeam secondTeam = (FootballTeam)cmbSecondTeam.SelectedItem;

            currentMatch = (matches.Where(match => (match.HomeTeam.Country == firstTeam.Country || match.AwayTeam.Country == firstTeam.Country) && (match.HomeTeam.Country == secondTeam.Country || match.AwayTeam.Country == secondTeam.Country))).First();
        }

        private void FillField(List<Player> startingEleven, List<StackPanel> places)
        {
            string picturePath;
            places.ForEach(place => place.Children.Clear());

            startingEleven.ForEach(player =>
            {
                PlayerUC playerUC = new PlayerUC(player);
                picturePath = GetDefaultPicturePath(places);
                playerUC.SetPicture(picturePath);
                playerUC.MouseLeftButtonDown += PlayerUC_MouseLeftButtonDown;
                switch (player.PlayerPosition)
                {
                    case Position.Defender:
                        places.ElementAt(1).Children.Add(playerUC);
                        break;
                    case Position.Forward:
                        places.ElementAt(3).Children.Add(playerUC);
                        break;
                    case Position.Goalie:
                        places.ElementAt(0).Children.Add(playerUC);
                        break;
                    case Position.Midfield:
                        places.ElementAt(2).Children.Add(playerUC);
                        break;
                }
            });
        }

        private string GetDefaultPicturePath(List<StackPanel> places)
        {
            if (places.ElementAt(0) == homeGoalkeeperStackPanel)
            {
                return $"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.RedShirt}";
            }
            return $"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.BlueShirt}";
        }

        private void PlayerUC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayerUC playerUC = sender as PlayerUC;
            if (currentMatch.HomeTeamStatistics.StartingEleven.Contains(playerUC.Player))
            {
                new PlayerInfoWindow(playerUC, currentMatch.HomeTeamEvents).ShowDialog();
            }
            else
            {
                new PlayerInfoWindow(playerUC, currentMatch.AwayTeamEvents).ShowDialog();
            }
        }

        private void cmbFavoriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserSettings.SelectedFootballTeam = ((FootballTeam)cmbFavoriteTeam.SelectedItem).Country;
            UserSettings.FifaCode = ((FootballTeam)cmbFavoriteTeam.SelectedItem).FifaCode;
            FillSecondComboBox();
        }

        private void btnHomeInfo_Click(object sender, RoutedEventArgs e)
        {
            new TeamInfoWindow((FootballTeam)cmbFavoriteTeam.SelectedItem).ShowDialog();
        }

        private void bntAwayInfo_Click(object sender, RoutedEventArgs e)
        {
            new TeamInfoWindow((FootballTeam)cmbSecondTeam.SelectedItem).ShowDialog();
        }

        private async void cmbSecondTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                IList<Match> matches = await dataRepo.GetMatchesAsync(UserSettings.FifaCode, UserSettings.SelectedFootballTeam);
                SetCurrentMatch(matches);

                SetScoreAndPlayers();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.errorMsg, Properties.Resources.errorTitle);
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            new Settings().ShowDialog();
            settingsRepo.SaveScreenSize();
            settingsRepo.SaveSettings();
            MainWindow mw = new MainWindow();
            UserSettings.EarlyExit = true;
            UserSettings.SelectedFootballTeam = null;
            this.Close();
            mw.Show();
        }


        private void SetScreenSize()
        {
            switch (UserSettings.ScreenSize)
            {
                case ScreenSize.S_Fullscreen:
                    WindowState = WindowState.Maximized;
                    break;
                case ScreenSize.S_550x800:
                    Width = 550;
                    Height = 800;
                    break;
                case ScreenSize.S_800x600:
                    Width = 800;
                    Height = 600;
                    break;
                case ScreenSize.S_1024x768:
                    Width = 1024;
                    Height = 768;
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (UserSettings.EarlyExit || MessageBox.Show(Properties.Resources.exitMsg, Properties.Resources.exitTitle, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                settingsRepo.DeleteScreenSize();
                settingsRepo.DeleteUserSettings();
                if (!string.IsNullOrEmpty(UserSettings.SelectedFootballTeam))
                {
                    settingsRepo.SaveSettings();
                    settingsRepo.SaveScreenSize();
                }
                UserSettings.EarlyExit = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }
    }
}