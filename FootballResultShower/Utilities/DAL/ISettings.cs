using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace Utilities.DAL
{
    public interface ISettings
    {
        void SaveSettings();

        void LoadSettings();

        Sex GetSex();

        string GetCountry();

        bool CheckDoSettingsExist();

        void SaveFavoritePlayers(IList<string> players);

        IList<string> LoadFavoritePlayers();

        bool CheckDoFavoritePlayersExist();

        void DeleteFavoritePlayers();

        void DeleteUserSettings();

        void EmptyDirectory(DirectoryInfo directory);

        void SaveScreenSize();

        ScreenSize GetScreenSize();

        bool CheckDoesScreenSizeExist();

        void DeleteScreenSize();

        void LoadScreenSize();
    }
}
