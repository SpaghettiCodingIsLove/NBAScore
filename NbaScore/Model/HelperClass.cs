using NbaScore.Model.Entities;
using NbaScore.View.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NbaScore.Model
{
    static class HelperClass
    {
        static HelperClass()
        {
            AllPlayers = new List<Player>();
            Initialized = false;
        }

        public static async Task Init()
        {      
            if (AllPlayers.Count == 0)
            {
                Players response = await ApiService.GetPlayersPage(100, 1);
                AllPlayers.AddRange(response.Data);

                while (response?.Meta?.NextPage != null)
                {
                    response = await ApiService.GetPlayersPage(100, response.Meta.NextPage.Value);
                    AllPlayers.AddRange(response.Data);
                }

                Initialized = true;
            }
        }

        public static Game Game { get; set; }
        public static Team Team { get; set; }
        public static Stats PlayerStats { get; set; }
        public static List<Player> AllPlayers { get; set; }
        public static bool Initialized { get; set; }
    }
}
