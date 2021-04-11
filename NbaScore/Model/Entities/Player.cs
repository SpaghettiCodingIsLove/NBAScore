using Newtonsoft.Json;

namespace NbaScore.Model.Entities
{
    public class Player
    {
        public long Id { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string LasrName { get; set; }
        [JsonProperty(PropertyName = "height_feet")]
        public int? HeightFeet { get; set; }
        [JsonProperty(PropertyName = "height_inches")]
        public int? HeightInches { get; set; }
        [JsonProperty(PropertyName = "weight_pounds")]
        public int? WeightPounds { get; set; }
        public Team Team { get; set; }
    }
}
