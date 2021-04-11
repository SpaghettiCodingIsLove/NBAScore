using Newtonsoft.Json;

namespace NbaScore.Model.Entities
{
    public class SeasonAverages
    {
        [JsonProperty(PropertyName = "games_played")]
        public int GamesPlayed { get; set; }
        [JsonProperty(PropertyName = "player_id")]
        public long PlayerId { get; set; }
        public int Season { get; set; }
        public string Min { get; set; }
        public double Fgm { get; set; }
        public double Fga { get; set; }
        public double Fg3m { get; set; }
        public double Fg3a { get; set; }
        public double Ftm { get; set; }
        public double Fta { get; set; }
        public double Oreb { get; set; }
        public double Dreb { get; set; }
        public double Reb { get; set; }
        public double Ast { get; set; }
        public double Stl { get; set; }
        public double Blk { get; set; }
        public double Turnover { get; set; }
        public double Pf { get; set; }
        public double Pts { get; set; }
        [JsonProperty(PropertyName = "fg_pct")]
        public double FgPct { get; set; }
        [JsonProperty(PropertyName = "fg3_pct")]
        public double Fg3Pct { get; set; }
        [JsonProperty(PropertyName = "ft_pct")]
        public double FtPct { get; set; }
    }
}
