using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Models
{
    public class Player : IComparable<Player>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position PlayerPosition { get; set; }

        public int Goals { get; set; }

        public int YellowCards { get; set; }

        public int CompareTo(Player other) => Name.CompareTo(other.Name);

        public override bool Equals(object obj) => obj is Player other && Name == other.Name;

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public enum Position { Defender, Forward, Goalie, Midfield };
    }
}
