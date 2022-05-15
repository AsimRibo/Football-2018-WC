using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.APIHandler;
using Utilities.Models;

namespace Utilities.DAL
{
    class FileFootballDataHandler : IDataHandling
    {
        public Task<IList<Match>> GetMatchesAsync(string fifaCode, string country)
        {
            try
            {
                return Task.Run(() =>
                {
                    using (StreamReader reader = new StreamReader($"{APIConstants.DefaultSettingsPath}{APIConstants.DataFolder}{UserSettings.DefaultFolder}{APIConstants.MatchesFile}"))
                    {
                        string content = reader.ReadToEnd();
                        IList<Match> matches = DeserializeData<IList<Match>>(content);

                        IList<Match> teamMatches = new List<Match>();
                        matches.ToList().ForEach(match =>
                        {
                            if (match.HomeTeam.Country == country || match.AwayTeam.Country == country)
                            {
                                teamMatches.Add(match);
                            }
                        });
                        return teamMatches;
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ISet<Player>> GetPlayersAsync(string fifaCode, string country)
        {
            try
            {
                return Task.Run(() =>
                {
                    using (StreamReader reader = new StreamReader($"{APIConstants.DefaultSettingsPath}{APIConstants.DataFolder}{UserSettings.DefaultFolder}{APIConstants.MatchesFile}"))
                    {
                        string content = reader.ReadToEnd();
                        IList<Match> matches = DeserializeData<IList<Match>>(content);

                        IList<Match> teamMatches = new List<Match>();
                        matches.ToList().ForEach(match =>
                        {
                            if (match.HomeTeam.Country == country || match.AwayTeam.Country == country)
                            {
                                teamMatches.Add(match);
                            }
                        });

                        ISet<Player> players = new HashSet<Player>();

                        FillSetWithPlayers(teamMatches, players, country);

                        return players;
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IList<FootballTeam>> GetTeamsAsync()
        {
            try
            {
                return Task.Run(() =>
                {
                    using (StreamReader reader = new StreamReader($"{APIConstants.DefaultSettingsPath}{APIConstants.DataFolder}{UserSettings.DefaultFolder}{APIConstants.ResultsFile}"))
                    {
                        string content = reader.ReadToEnd();
                        return DeserializeData<IList<FootballTeam>>(content);
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FillSetWithPlayers(IList<Match> matches, ISet<Player> players, string country)
        {
            if (matches[0].HomeTeam.Country == country)
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
