using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.APIHandler;
using Utilities.Models;

namespace Utilities.DAL
{
    class APIFootballDataHandler : IDataHandling
    {
        public async Task<IList<FootballTeam>> GetTeamsAsync()
        {
            try
            {
                IRestResponse<IList<FootballTeam>> restResponse = await GetDataAsync<IList<FootballTeam>>($"{UserSettings.BaseUrl}{APIConstants.TeamsResult}");
                return DeserializeData<IList<FootballTeam>>(restResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISet<Player>> GetPlayersAsync(string fifaCode, string country)
        {
            try
            {
                IRestResponse<IList<Match>> restResponse = await GetDataAsync<IList<Match>>($"{UserSettings.BaseUrl}{APIConstants.Matches}{APIConstants.FifaCode}{fifaCode}");
                IList<Match> matches = DeserializeData<IList<Match>>(restResponse.Content);

                ISet<Player> players = new SortedSet<Player>();

                FillSetWithPlayers(matches, players, country);

                return players;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Match>> GetMatchesAsync(string fifaCode, string country)
        {
            try
            {
                IRestResponse<IList<Match>> restResponse = await GetDataAsync<IList<Match>>($"{UserSettings.BaseUrl}{APIConstants.Matches}{APIConstants.FifaCode}{fifaCode}");
                IList<Match> matches = DeserializeData<IList<Match>>(restResponse.Content);

                return matches;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void FillSetWithPlayers(IList<Match> matches, ISet<Player> players, string country)
        {
            if (matches[0].HomeTeam.Country ==  country)
            {
                matches[0].HomeTeamStatistics.StartingEleven.ToList().ForEach(player => players.Add(player));
                matches[0].HomeTeamStatistics.Substitutes.ToList().ForEach(player => players.Add(player));
                
            }
            else
            {
                matches[0].AwayTeamStatistics.StartingEleven.ToList().ForEach(player => players.Add(player));
                matches[0].AwayTeamStatistics.Substitutes.ToList().ForEach(player => players.Add(player));
            }
        }

        private static Task<IRestResponse<T>> GetDataAsync<T>(string url) => new RestClient(url).ExecuteAsync<T>(new RestRequest());

        private static T DeserializeData<T>(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
