using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Models.Player;

namespace Utilities.Models
{
    public class Match
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("attendance")]
        public long Attendance { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("home_team")]
        public FootballTeam HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public FootballTeam AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }
    }

  
    public partial class TeamEvent
    {
        [JsonProperty("type_of_event")]
        public string TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        public int Goals { get; set; }

        public int YellowCards { get; set; }

    }

    //Country
    public partial class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; }
    }

}
