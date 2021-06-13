using System.Collections.Generic;

namespace NbaScore.Model.Entities
{
    public class Teams
    {
        public IEnumerable<Team> Data { get; set; }
        public Meta Meta { get; set; }
    }
}
