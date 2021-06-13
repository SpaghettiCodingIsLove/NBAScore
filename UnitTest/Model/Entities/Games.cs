using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NbaScore.Model.Entities
{
    public class Games
    {
        public ObservableCollection<Game> Data { get; set; }
        public Meta Meta { get; set; }
    }
}
