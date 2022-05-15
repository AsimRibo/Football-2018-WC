using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.APIHandler;
using Utilities.Enums;

namespace Utilities.DAL
{
    class UserFileRepository : ISettings
    {
        private const char DEL = '|';

        public void LoadSettings()
        {
            string data = File.ReadAllText($"{APIConstants.DefaultSettingsPath}\\userSettings.txt");
            string[] lines = data.Split(DEL);

            UserSettings.Selectedlanguage = lines[0];
            UserSettings.Sex = (Sex)Enum.Parse(typeof(Sex), lines[1]);
            UserSettings.ConnectionType = (ConnectionType)Enum.Parse(typeof(ConnectionType), lines[2]);
            UserSettings.BaseUrl = lines[3];
            UserSettings.DefaultFolder = lines[4];
            UserSettings.SelectedFootballTeam = lines[5];
            UserSettings.FifaCode = lines[6];
        }



        public void SaveSettings()
        {
            if (!Directory.Exists(APIConstants.DefaultSettingsPath))
            {
                Directory.CreateDirectory(APIConstants.DefaultSettingsPath);
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(UserSettings.Selectedlanguage)
                .Append(DEL)
                .Append(UserSettings.Sex)
                .Append(DEL)
                .Append(UserSettings.ConnectionType)
                .Append(DEL)
                .Append(UserSettings.BaseUrl)
                .Append(DEL)
                .Append(UserSettings.DefaultFolder)
                .Append(DEL)
                .Append(UserSettings.SelectedFootballTeam)
                .Append(DEL)
                .Append(UserSettings.FifaCode);

            File.WriteAllText($"{APIConstants.DefaultSettingsPath}\\userSettings.txt", sb.ToString());

        }

        public bool CheckDoSettingsExist()
        {
            return File.Exists($"{APIConstants.DefaultSettingsPath}\\userSettings.txt");
        }

        public void SaveFavoritePlayers(IList<string> players)
        {
            StringBuilder sb = new StringBuilder();
            players.ToList().ForEach(player => sb.Append(player).Append(DEL));
            sb.Remove(sb.Length - 1, 1);

            File.WriteAllText($"{APIConstants.DefaultSettingsPath}\\favoritePlayers.txt", sb.ToString());
        }

        public IList<string> LoadFavoritePlayers()
        {
            string content = File.ReadAllText($"{APIConstants.DefaultSettingsPath}\\favoritePlayers.txt");
            string[] data = content.Split(DEL);
            IList<string> players = new List<string>(data);

            return players;
        }

        public bool CheckDoFavoritePlayersExist()
        {
            return File.Exists($"{APIConstants.DefaultSettingsPath}\\favoritePlayers.txt");
        }

        public Sex GetSex()
        {
            string data = File.ReadAllText($"{APIConstants.DefaultSettingsPath}\\userSettings.txt");
            string[] lines = data.Split(DEL);

            return (Sex)Enum.Parse(typeof(Sex), lines[1]);
        }

        public string GetCountry()
        {
            string data = File.ReadAllText($"{APIConstants.DefaultSettingsPath}\\userSettings.txt");
            string[] lines = data.Split(DEL);

            return lines[5];
        }

        public void DeleteFavoritePlayers()
        {
            if (CheckDoFavoritePlayersExist())
            {
                File.Delete($"{APIConstants.DefaultSettingsPath}\\favoritePlayers.txt");
            }
        }

        public void DeleteUserSettings()
        {
            if (CheckDoSettingsExist())
            {
                File.Delete($"{APIConstants.DefaultSettingsPath}\\userSettings.txt");
            }
        }

        public void EmptyDirectory(DirectoryInfo directory)
        {
            foreach (var item in directory.GetFiles())
            { 
                item.Delete();
            }
        }

        public void SaveScreenSize()
        {
            File.WriteAllText($"{APIConstants.DefaultSettingsPath}\\screenSize.txt", UserSettings.ScreenSize.ToString());
        }

        public ScreenSize GetScreenSize()
        {
            string data = File.ReadAllText($"{APIConstants.DefaultSettingsPath}\\screenSize.txt");

            return (ScreenSize)Enum.Parse(typeof(ScreenSize), data);
        }

        public bool CheckDoesScreenSizeExist()
        {
            return File.Exists($"{APIConstants.DefaultSettingsPath}\\screenSize.txt");
        }

        public void DeleteScreenSize()
        {
            if (CheckDoesScreenSizeExist())
            {
                File.Delete($"{APIConstants.DefaultSettingsPath}\\screenSize.txt");
            }
        }

        public void LoadScreenSize()
        {
            string data = File.ReadAllText($"{APIConstants.DefaultSettingsPath}\\screenSize.txt");

            UserSettings.ScreenSize = (ScreenSize)Enum.Parse(typeof(ScreenSize), data);
        }
    }
}
