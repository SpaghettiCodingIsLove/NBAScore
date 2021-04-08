using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NbaScore.Model.Entities
{
    class GameData
    {
        ObservableCollection<Game> data;
        Meta meta;

        public GameData() { }
        public GameData(ObservableCollection<Game> data, Meta meta) 
        {
            this.data = data;
            this.meta = meta;
        }

        public ObservableCollection<Game> Data { get => data; private set { } }
        public Meta Meta { get => meta; private set { } }
    }
}
