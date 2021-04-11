using System.Collections.ObjectModel;

namespace NbaScore.Model.Entities
{
    public class Teams
    {
        public ObservableCollection<Team> Data { get; set; }
        public Meta Meta { get; set; }
    }
}
