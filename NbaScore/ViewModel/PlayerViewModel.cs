using NbaScore.Model.Entities;
using NbaScore.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaScore.ViewModel
{
    class PlayerViewModel : ViewModelBase
    {
        private readonly Player player;

        public PlayerViewModel(Player player)
        {
            this.player = player;
        }

        public string Name => $"{player.FirstName} {player.LastName}";
    }
}
