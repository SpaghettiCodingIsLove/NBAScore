using Newtonsoft.Json;
using System;

namespace NbaScore.Model.Entities
{
    public class Game
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "home_team_score")]
        public int HomeTeamScore { get; set; }
        [JsonProperty(PropertyName = "visitor_team_score")]
        public int VisitorTeamScore { get; set; }
        public int Season { get; set; }
        public int Period { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public bool Postseason { get; set; }
        [JsonProperty(PropertyName = "home_team")]
        public Team HomeTeam { get; set; }
        [JsonProperty(PropertyName = "visitor_team")]
        public Team VisitorTeam { get; set; }
    }
}
