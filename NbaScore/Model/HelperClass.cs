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
        }

        public static async Task Init()
        {
            while (init)
            {
                Thread.Sleep(1000);
            }
            
            if (AllPlayers.Count == 0)
            {
                init = true;
                Players response = await ApiService.GetPlayersPage(100, 1);
                AllPlayers.AddRange(response.Data);

                while (response?.Meta?.NextPage != null)
                {
                    response = await ApiService.GetPlayersPage(100, response.Meta.NextPage.Value);
                    AllPlayers.AddRange(response.Data);
                }

                init = false;
            }
        }

        public static Game Game { get; set; }
        public static Team Team { get; set; }
        public static List<Player> AllPlayers { get; set; }
        private static bool init = false;
    }
}
