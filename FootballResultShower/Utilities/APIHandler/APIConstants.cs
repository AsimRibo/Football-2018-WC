using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.APIHandler
{
    public static class APIConstants
    {
        public const string MaleBaseUrl = "https://world-cup-json-2018.herokuapp.com";
        public const string FemaleBaseUrl = "http://worldcup.sfg.io";

        public const string Teams = "/teams";
        public const string TeamsResult = "/teams/results";

        public const string Matches = "/matches";

        public const string FifaCode = "/country?fifa_code=";

        public static string DefaultSettingsPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Settings");
        public const string PicturesFolder = "\\Pictures";
        public const string CustomFolder = "\\Custom";
        public const string DataFolder = "\\DownloadedData";
        public const string MenFolder = "\\men";
        public const string WomenFolder = "\\women";
        public const string DefaultShirt = "\\shirt.png";
        public const string TeamsFile = "\\teams.json";
        public const string ResultsFile = "\\results.json";
        public const string MatchesFile = "\\matches.json";
        public const string RedShirt = "\\redShirt.png";
        public const string BlueShirt = "\\blueShirt.png";
    }
}
