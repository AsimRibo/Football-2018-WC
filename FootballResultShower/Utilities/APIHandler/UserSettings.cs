using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace Utilities.APIHandler
{
    public static class UserSettings
    {
        public static string Selectedlanguage;
        public static Sex Sex;
        public static ConnectionType ConnectionType;
        public static string BaseUrl;
        public static string DefaultFolder;
        public static string SelectedFootballTeam;
        public static string FifaCode;
        public static ScreenSize ScreenSize;
        public static bool EarlyExit = false;
    }
}
