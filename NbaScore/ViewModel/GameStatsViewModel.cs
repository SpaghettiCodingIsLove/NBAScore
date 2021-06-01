using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.View;
using NbaScore.Model;
using NbaScore.ViewModel.BaseClasses;
using Xamarin.Forms;

namespace NbaScore.ViewModel
{
    class GameStatsViewModel : ViewModelBase
    {

        public GameStatsViewModel()
        {
            CurrentGame = HelperClass.game.HomeTeam.FullName + " " + HelperClass.game.VisitorTeam.FullName;
        }

        private string currentGame;
        public string CurrentGame
        {
            get => currentGame;
            set
            {
                currentGame = value;
                OnPropertyChanged(nameof(CurrentGame));
            }
        }
    }
}
