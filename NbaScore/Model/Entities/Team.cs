using Newtonsoft.Json;

namespace NbaScore.Model.Entities
{
    public class Team
    {
        public long Id { get; set; }
        public string Abbreviation { get; set; }
        public string City { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }
        public string Name { get; set; }
    }
}
