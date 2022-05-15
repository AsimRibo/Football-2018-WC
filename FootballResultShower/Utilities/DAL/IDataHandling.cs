using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Models;

namespace Utilities.DAL
{
    public interface IDataHandling
    {
        Task<IList<FootballTeam>> GetTeamsAsync();

        Task<ISet<Player>> GetPlayersAsync(string fifaCode, string country);

        Task<IList<Match>> GetMatchesAsync(string fifaCode, string country);
    }
}
