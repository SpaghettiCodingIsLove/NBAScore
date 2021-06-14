using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.Model;
using NbaScore.Model.Entities;
using NbaScore.View;
using NbaScore.ViewModel.BaseClasses;

namespace NbaScore.ViewModel
{
    class PlayerGameStatsViewModel : ViewModelBase
    {
        private Stats stats;
        private Game game;
        private string title;
        private string height;

        public PlayerGameStatsViewModel()
        {
            Stats = HelperClass.PlayerStats;
            Game = HelperClass.Game;
            Title = Stats.Player.FullName;
            Height = $"{Stats.Player.HeightFeet}\'{Stats.Player.HeightInches}\'\'";
        }

        public Stats Stats
        {
            get => stats;
            set
            {
                stats = value;
                OnPropertyChanged(nameof(Stats));
            }
        }
        
        public Game Game
        {
            get => game;
            set
            {
                game = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }
    }
}
