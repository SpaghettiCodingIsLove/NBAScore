using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NbaScore.Model.Entities
{
    class SeasonAveragesData
    {
        ObservableCollection<SeasonAverages> data;
        Meta meta;

        public SeasonAveragesData() { }
        public SeasonAveragesData(ObservableCollection<SeasonAverages> data, Meta meta)
        {
            this.data = data;
            this.meta = meta;
        }

        public ObservableCollection<SeasonAverages> Data { get => data; private set { } }
        public Meta Meta { get => meta; private set { } }
    }
}
