using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NbaScore.Model.Entities
{
    class StatsData
    {
        ObservableCollection<Stats> data;
        Meta meta;

        public StatsData() { }
        public StatsData(ObservableCollection<Stats> data, Meta meta)
        {
            this.data = data;
            this.meta = meta;
        }

        public ObservableCollection<Stats> Data { get => data; private set { } }
        public Meta Meta { get => meta; private set { } }
    }
}
