using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NbaScore.Model.Entities
{
    class TeamData
    {
        ObservableCollection<Team> data;
        Meta meta;

        public TeamData() { }
        public TeamData(ObservableCollection<Team> data, Meta meta)
        {
            this.data = data;
            this.meta = meta;
        }

        public ObservableCollection<Team> Data { get => data; private set { } }
        public Meta Meta { get => meta; private set { } }
    }
}
