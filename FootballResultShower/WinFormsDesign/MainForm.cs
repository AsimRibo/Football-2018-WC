using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using Utilities.APIHandler;
using Utilities.DAL;
using Utilities.Models;
using WinFormsDesign.UserControls;

namespace WinFormsDesign
{
    public partial class MainForm : Form
    {
        private IDataHandling repository;

        private ISettings settingsRepo;

        private ISet<Player> allPlayers;

        private IList<string> favoritePlayers;

        private OpenFileDialog ofd;

        private int pagesPrinted = 0;

        private int skipNum = 0;

        private int numOfPlayers = 9;

        private int numOfGames = 4;


        public MainForm()
        {
            CheckForSettings();
            Init();
            SetCulture();
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        }

        private void Init()
        {
            repository = RepositoryFactory.GetRepository(UserSettings.ConnectionType);
            favoritePlayers = new List<string>();
            ofd = new OpenFileDialog();
            SetupOfd();
        }

        private void SetupOfd()
        {
            ofd.Multiselect = false;
            ofd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            ofd.Title = MessageRes.ofdTitle;
            ofd.Filter = "Pictures|*.png;*.jpg;*.jpeg;|All files|*.*";
        }

        private void CheckForSettings()
        {
            settingsRepo = RepositoryFactory.GetSettings();
            if (!settingsRepo.CheckDoSettingsExist())
            {
                new TypeOfConnectionForm().ShowDialog();
            }
            else
            {
                settingsRepo.LoadSettings();
            }



        }

        private async void PreparePlayersAsync()
        {
            try
            {
                allPlayers = await repository.GetPlayersAsync(UserSettings.FifaCode, UserSettings.SelectedFootballTeam);
                FillAllPlayersPanel();
            }
            catch (Exception)
            {
                MessageBox.Show(MessageRes.errorMsg, MessageRes.errorTitle);
            }
        }

        private void tabPlayers_Enter(object sender, EventArgs e)
        {
            PrepareFavoritePlayers();
            PreparePlayersAsync();
            DisplayCountryName(lbTeamNameTab1);
        }

        private void PrepareFavoritePlayers()
        {
            if (settingsRepo.CheckDoFavoritePlayersExist())
            {
                favoritePlayers = settingsRepo.LoadFavoritePlayers();
            }
        }

        private void FillAllPlayersPanel()
        {
            CleanPanel(flowPnlAllPlayers);
            CleanPanel(flowPnlFavoritePlayers);
            allPlayers.ToList().ForEach(player =>
            {
                PlayerUC pnl = new PlayerUC
                {
                    PlayerName = player.Name,
                    PlayerPosition = player.PlayerPosition,
                    PlayerNumber = player.ShirtNumber.ToString(),
                    PlayerCaptain = player.Captain ? MessageRes.captainString : ""
                };
                if (!PictureExists(pnl.PlayerName))
                {
                    pnl.SetPicture($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.DefaultShirt}");
                }
                else
                {
                    pnl.SetPicture($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.CustomFolder}\\{pnl.PlayerName}.png");
                }

                pnl.MouseDown += PlayerUserControl_MouseDown;
                pnl.ContextMenuStrip = cmsEditPlayer;
                if (favoritePlayers.Contains(pnl.PlayerName))
                {
                    flowPnlFavoritePlayers.Controls.Add(pnl);
                }
                else
                {
                    flowPnlAllPlayers.Controls.Add(pnl);
                }

            });
        }

        private bool PictureExists(string playerName)
        {
            return File.Exists($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.CustomFolder}\\{playerName}.png");

        }

        private void DisplayCountryName(Label label)
        {
            label.Text = UserSettings.SelectedFootballTeam;
        }

        private void tabRankedPlayers_Enter(object sender, EventArgs e)
        {
            CleanPanel(flowPnlGoals);
            CleanPanel(flowPnlCards);
            PreparePlayerStatsAsync();
            DisplayCountryName(lbTeamNameTab2);
        }

        private void PlayerUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PlayerUC chosenPnl = sender as PlayerUC;

                chosenPnl.DoDragDrop(chosenPnl, DragDropEffects.Move);
            }
        }

        private void CleanPanel(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
        }

        private async void PreparePlayerStatsAsync()
        {
            try
            {
                IList<Match> matches = await repository.GetMatchesAsync(UserSettings.FifaCode, UserSettings.SelectedFootballTeam);
                FillPlayersStats(matches);
                DisplayPlayersStats();
            }
            catch (Exception)
            {
                MessageBox.Show(MessageRes.errorMsg, MessageRes.errorTitle);
            }
        }

        private void DisplayPlayersStats()
        {
            DisplayPlayersByGoals();
            DisplayPlayersByCards();
        }

        private void DisplayPlayersByGoals()
        {
            List<Player> sortedPlayers = new List<Player>(allPlayers);
            sortedPlayers.Sort((x, y) => -x.Goals.CompareTo(y.Goals));


            sortedPlayers.ForEach(player =>
            {
                PlayerGoalsUC pnl = new PlayerGoalsUC()
                {
                    PlayerName = player.Name,
                    PlayerGoals = player.Goals.ToString()
                };

                if (!PictureExists(pnl.PlayerName))
                {
                    pnl.SetPicture($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.DefaultShirt}");
                }
                else
                {
                    pnl.SetPicture($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.CustomFolder}\\{pnl.PlayerName}.png");

                }

                flowPnlGoals.Controls.Add(pnl);
            });
        }

        private void DisplayPlayersByCards()
        {
            List<Player> sortedPlayers = new List<Player>(allPlayers);
            sortedPlayers.Sort((x, y) => -x.YellowCards.CompareTo(y.YellowCards));

            flowPnlCards.Controls.Clear();

            sortedPlayers.ForEach(player =>
            {
                PlayerCardsUC pnl = new PlayerCardsUC()
                {
                    PlayerName = player.Name,
                    PlayerCards = player.YellowCards.ToString()
                };



                if (!PictureExists(pnl.PlayerName))
                {
                    pnl.SetPicture($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.DefaultShirt}");
                }
                else
                {
                    pnl.SetPicture($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.CustomFolder}\\{pnl.PlayerName}.png");

                }

                flowPnlCards.Controls.Add(pnl);
            });
        }

        private void FillPlayersStats(IList<Match> matches)
        {
            allPlayers.ToList().ForEach(player =>
            {
                matches.ToList().ForEach(match =>
                {
                    CheckGoalStatistic(match, player);
                    CheckCardStatistic(match, player);
                });
            });
        }

        private void CheckCardStatistic(Match match, Player player)
        {
            if (UserSettings.SelectedFootballTeam == match.HomeTeamCountry)
            {
                player.YellowCards += match.HomeTeamEvents.Where(e => (e.TypeOfEvent == "yellow-card" || e.TypeOfEvent == "yellow-card-second") && e.Player == player.Name).Count();
                return;
            }

            player.YellowCards += match.AwayTeamEvents.Where(e => (e.TypeOfEvent == "yellow-card" || e.TypeOfEvent == "yellow-card-second") && e.Player == player.Name).Count();

        }

        private void CheckGoalStatistic(Match match, Player player)
        {
            if (UserSettings.SelectedFootballTeam == match.HomeTeamCountry)
            {
                player.Goals += match.HomeTeamEvents.Where(e => (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty") && e.Player == player.Name).Count();
                return;
            }

            player.Goals += match.AwayTeamEvents.Where(e => (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty") && e.Player == player.Name).Count();

        }

        private void tabPageRankedGames_Enter(object sender, EventArgs e)
        {
            CleanPanel(flowLayoutPnlGames);
            DisplayCountryName(lbTeamNameTab3);
            PrepareGamesStatsAsync();
        }

        private async void PrepareGamesStatsAsync()
        {
            try
            {
                List<Match> matches = (List<Match>)await repository.GetMatchesAsync(UserSettings.FifaCode, UserSettings.SelectedFootballTeam);
                matches.Sort((x, y) => -x.Attendance.CompareTo(y.Attendance));

                matches.ToList().ForEach(match =>
                {
                    GamesUC pnl = new GamesUC()
                    {
                        HomeTeam = match.HomeTeamCountry,
                        AwayTeam = match.AwayTeamCountry,
                        HomeTeamScore = match.HomeTeam.Goals.ToString(),
                        AwayTeamScore = match.AwayTeam.Goals.ToString(),
                        GameLocation = match.Location,
                        NumberOfFans = match.Attendance
                    };

                    flowLayoutPnlGames.Controls.Add(pnl);
                });
            }
            catch (Exception)
            {
                MessageBox.Show(MessageRes.errorMsg, MessageRes.errorTitle);
            }
        }

        private void flowPanels_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flowPnlFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayerUC puc = (PlayerUC)e.Data.GetData(typeof(PlayerUC));

            if (puc.Parent == flowPnlFavoritePlayers)
            {
                return;
            }

            if (flowPnlFavoritePlayers.Controls.Count < 3)
            {
                flowPnlFavoritePlayers.Controls.Add(puc);
                favoritePlayers.Add(puc.PlayerName);
                return;
            }
            MessageBox.Show(MessageRes.favoritePlayersFull);

        }

        private void flowPnlAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayerUC puc = (PlayerUC)e.Data.GetData(typeof(PlayerUC));

            if (puc.Parent == flowPnlAllPlayers)
            {
                return;
            }

            flowPnlAllPlayers.Controls.Add(puc);
            favoritePlayers.Remove(puc.PlayerName);
        }

        private void btnPrintGoals_Click(object sender, EventArgs e)
        {

            printPreviewDialogGoals.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            IEnumerable<PlayerGoalsUC> players = flowPnlGoals.Controls.Cast<PlayerGoalsUC>();
            IEnumerable<PlayerGoalsUC> playersGroup;

            switch (pagesPrinted)
            {
                case 0:
                    playersGroup = players.Take(numOfPlayers);
                    PrintPlayers(playersGroup, e, MessageRes.goalsTitle, MessageRes.goalsString);
                    skipNum += numOfPlayers;
                    pagesPrinted++;
                    e.HasMorePages = true;
                    break;
                case 1:
                    playersGroup = players.Skip(skipNum).Take(numOfPlayers);
                    PrintPlayers(playersGroup, e, MessageRes.goalsTitle, MessageRes.goalsString);
                    skipNum += numOfPlayers;
                    pagesPrinted++;
                    e.HasMorePages = true;
                    break;
                case 2:
                    playersGroup = players.Skip(skipNum).Take(numOfPlayers);
                    PrintPlayers(playersGroup, e, MessageRes.goalsTitle, MessageRes.goalsString);
                    pagesPrinted = 0;
                    skipNum = 0;
                    e.HasMorePages = false;
                    break;

            }

        }

        private void btnPrintCards_Click(object sender, EventArgs e)
        {
            printPreviewDialogCards.ShowDialog();
        }

        private void printDocumentCards_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        { 
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            IEnumerable<PlayerCardsUC> players = flowPnlCards.Controls.Cast<PlayerCardsUC>();
            IEnumerable<PlayerCardsUC> playersGroup;

            switch (pagesPrinted)
            {
                case 0:
                    playersGroup = players.Take(numOfPlayers);
                    PrintPlayers(playersGroup, e, MessageRes.cardsTitle, MessageRes.yellowCardsString);
                    skipNum += numOfPlayers;
                    pagesPrinted++;
                    e.HasMorePages = true;
                    break;
                case 1:
                    playersGroup = players.Skip(skipNum).Take(numOfPlayers);
                    PrintPlayers(playersGroup, e, MessageRes.cardsTitle, MessageRes.yellowCardsString);
                    skipNum += numOfPlayers;
                    pagesPrinted++;
                    e.HasMorePages = true;
                    break;
                case 2:
                    playersGroup = players.Skip(skipNum).Take(numOfPlayers);
                    PrintPlayers(playersGroup, e, MessageRes.cardsTitle, MessageRes.yellowCardsString);
                    pagesPrinted = 0;
                    skipNum = 0;
                    e.HasMorePages = false;
                    break;

            }
        }

        private void PrintPlayers(IEnumerable<PlayerCardsUC> playersGroup, PrintPageEventArgs e, string title, string desc)
        { 
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;

            if (pagesPrinted == 0)
            {
                e.Graphics.DrawString(title, new Font("Arial", 15), Brushes.Black, e.MarginBounds.Right/2 - 50, y);
                y += 40;
            }


            playersGroup.ToList().ForEach(p =>
            {
                e.Graphics.DrawImage(p.GetImage(), x, y, (p.GetImage().Width)/9, (p.GetImage().Height)/9);
                x += p.GetImage().Width/9 + 15;
                y += 20;
                e.Graphics.DrawString($"{p.PlayerName}   {desc}: {p.PlayerCards}", new Font("Arial", 12), Brushes.Black, x, y);
                x = e.MarginBounds.Left;
                y += p.GetImage().Height/9 + 10;
            });
        }

        private void PrintPlayers(IEnumerable<PlayerGoalsUC> playersGroup, PrintPageEventArgs e, string title, string desc)
        {
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;

            if (pagesPrinted == 0)
            {
                e.Graphics.DrawString(title, new Font("Arial", 15), Brushes.Black, e.MarginBounds.Right / 2 - 50, y);
                y += 40;
            }

            playersGroup.ToList().ForEach(p =>
            {
                e.Graphics.DrawImage(p.GetImage(), x, y, Size.Width / 8, Size.Height / 8);
                x += Size.Width / 9 + 25;
                y += 20;
                e.Graphics.DrawString($"{p.PlayerName}   {desc}: {p.PlayerGoals}", new Font("Arial", 12), Brushes.Black, x, y);
                x = e.MarginBounds.Left;
                y += Size.Height / 8 + 10;
            });
        }

        private void btnPrintGames_Click(object sender, EventArgs e)
        {
            printPreviewDialogGames.ShowDialog();
        }

        private void printDocumentGames_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            IEnumerable<GamesUC> games = flowLayoutPnlGames.Controls.Cast<GamesUC>();
            IEnumerable<GamesUC> gamesGroup;

            switch (pagesPrinted)
            {
                case 0:
                    gamesGroup = games.Take(numOfGames);
                    PrintGames(gamesGroup, e);
                    skipNum += numOfGames;
                    pagesPrinted++;
                    e.HasMorePages = true;
                    break;
                case 1:
                    gamesGroup = games.Skip(skipNum).Take(numOfGames);
                    PrintGames(gamesGroup, e);
                    skipNum = 0;
                    pagesPrinted = 0;
                    e.HasMorePages = false;
                    break;
            }
        }

        private void PrintGames(IEnumerable<GamesUC> gamesGroup, PrintPageEventArgs e)
        {
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;

            if (pagesPrinted == 0)
            {
                e.Graphics.DrawString(MessageRes.gamesTitle, new Font("Arial", 15), Brushes.Black, e.MarginBounds.Right / 2 - 50, y);
                y += 60;
            }

            gamesGroup.ToList().ForEach(game =>
            {
                e.Graphics.DrawString($"{game.HomeTeam}", new Font("Arial", 12), Brushes.Black, x + Size.Width / 7 + 15, y);

                e.Graphics.DrawString($"{game.AwayTeam}", new Font("Arial", 12), Brushes.Black, e.MarginBounds.Right - 135, y);

                y += 30;

                e.Graphics.DrawImage(game.GetHomeTeamImage(), x, y, Size.Width / 7, Size.Height / 7);

                e.Graphics.DrawImage(game.GetAwayTeamImage(), e.MarginBounds.Right - 50, y, Size.Width / 7, Size.Height / 7);

                e.Graphics.DrawString($"{MessageRes.locationString}: {game.GameLocation}", new Font("Arial", 12), Brushes.Black, e.MarginBounds.Right / 2, y);

                y += 50;

                e.Graphics.DrawString($"{game.HomeTeamScore}   :", new Font("Arial", 12), Brushes.Black, e.MarginBounds.Right / 2 + 60, y);

                e.Graphics.DrawString($"{game.AwayTeamScore}", new Font("Arial", 12), Brushes.Black, e.MarginBounds.Right / 2 + 97, y);

                y += 50;

                e.Graphics.DrawString($"{MessageRes.fansNumberString}: {game.NumberOfFans}", new Font("Arial", 12), Brushes.Black, e.MarginBounds.Right / 2 + 10, y);

                y += Size.Height / 7;
            });
        }

        private void changePlayerPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;

            var owner = item.Owner as ContextMenuStrip;
            PlayerUC puc = owner.SourceControl as PlayerUC;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                puc.SetPicture(ofd.FileName);
                SavePicture(ofd, puc);
                
            }
        }

        private void SavePicture(OpenFileDialog ofd, PlayerUC puc)
        {
            Image img = Image.FromFile(ofd.FileName);
            img.Save($"{APIConstants.DefaultSettingsPath}{APIConstants.PicturesFolder}{APIConstants.CustomFolder}\\{puc.PlayerName}.png");
        }

        private void changePanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;

            var owner = item.Owner as ContextMenuStrip;
            PlayerUC puc = owner.SourceControl as PlayerUC;

            if (puc.Parent == flowPnlAllPlayers)
            {
                if (flowPnlFavoritePlayers.Controls.Count < 3)
                {
                    flowPnlFavoritePlayers.Controls.Add(puc);
                    return;
                }
                else
                {
                    MessageBox.Show(MessageRes.favoritePlayersFull);
                }
                
            }

            flowPnlAllPlayers.Controls.Add(puc);
        }

        private void toolStripMenuItemContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MessageRes.contactMsg, MessageRes.contactTitle);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show(MessageRes.exitMsg, MessageRes.exitTitle, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(UserSettings.SelectedFootballTeam))
                {
                    settingsRepo.SaveSettings();
                    settingsRepo.DeleteFavoritePlayers();
                    if (favoritePlayers.Count > 0)
                    {
                        settingsRepo.SaveFavoritePlayers(favoritePlayers);
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }



        }

        private void toolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            new TypeOfConnectionForm().ShowDialog();
            CheckChangesAndDeleteFiles();
            repository = RepositoryFactory.GetRepository(UserSettings.ConnectionType);
            SetCulture();
            UpdateForm();
        }

        

        private void CheckChangesAndDeleteFiles()
        {
            if (settingsRepo.CheckDoSettingsExist())
            {
                if (UserSettings.Sex != settingsRepo.GetSex() || UserSettings.SelectedFootballTeam != settingsRepo.GetCountry())
                {
                    settingsRepo.DeleteFavoritePlayers();
                    settingsRepo.DeleteUserSettings();
                }

            }

        }

        private void UpdateForm()
        {
            this.Controls.Clear();
            InitializeComponent();
            this.tabPlayers_Enter(this, new EventArgs());
            tabMainForm.SelectedTab = tabPlayers;
        }

        private void SetCulture()
        {
            CultureInfo culture = new CultureInfo(UserSettings.Selectedlanguage);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            

        }

        private void tabMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
