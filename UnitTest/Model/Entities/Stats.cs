using Newtonsoft.Json;

namespace NbaScore.Model.Entities
{
    public class Stats
    {
        public long Id { get; set; }
        public string Min { get; set; }
        public int Fgm { get; set; }
        public int Fga { get; set; }
        public int Fg3m { get; set; }
        public int Fg3a { get; set; }
        public int Ftm { get; set; }
        public int Fta { get; set; }
        public int Oreb { get; set; }
        public int Dreb { get; set; }
        public int Reb { get; set; }
        public int Ast { get; set; }
        public int Stl { get; set; }
        public int Blk { get; set; }
        public int Turnover { get; set; }
        public int Pf { get; set; }
        public int Pts { get; set; }
        [JsonProperty(PropertyName = "fg_pct")]
        public double FgPct { get; set; }
        [JsonProperty(PropertyName = "fg3_pct")]
        public double Fg3Pct { get; set; }
        [JsonProperty(PropertyName = "ft_pct")]
        public double FtPct { get; set; }
        public Game Game { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}
