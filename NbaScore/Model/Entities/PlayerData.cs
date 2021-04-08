using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NbaScore.Model.Entities
{
    class PlayerData
    {
        ObservableCollection<Player> data;
        Meta meta;

        public PlayerData() { }
        public PlayerData(ObservableCollection<Player> data, Meta meta)
        {
            this.data = data;
            this.meta = meta;
        }

        public ObservableCollection<Player> Data { get => data; private set { } }
        public Meta Meta { get => meta; private set { } }
    }
}
