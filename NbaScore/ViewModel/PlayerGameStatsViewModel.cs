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
        private string fg3Pct;
        private string fgPct;
        private string ftPct;
        private string fg3;
        private string fg;
        private string ft;

        public PlayerGameStatsViewModel()
        {
            Stats = HelperClass.PlayerStats;
            Game = HelperClass.Game;
            Title = Stats.Player.FullName;
            Height = $"{Stats.Player.HeightFeet}\'{Stats.Player.HeightInches}\'\'";
            Fg = $"{Stats.Fgm}/{Stats.Fga}";
            Fg3 = $"{Stats.Fg3m}/{Stats.Fg3a}";
            Ft = $"{Stats.Ftm}/{Stats.Fta}";
            Fg3Pct = $"{Stats.Fg3Pct}%";
            FgPct = $"{Stats.FgPct}%";
            FtPct = $"{Stats.FtPct}%";
        }

        public string Fg3Pct
        {
            get => fg3Pct;
            set
            {
                fg3Pct = value;
                OnPropertyChanged(nameof(Fg3Pct));
            }
        }

        public string FgPct
        {
            get => fgPct;
            set
            {
                fgPct = value;
                OnPropertyChanged(nameof(FgPct));
            }
        }

        public string FtPct
        {
            get => ftPct;
            set
            {
                ftPct = value;
                OnPropertyChanged(nameof(FtPct));
            }
        }

        public string Fg3
        {
            get => fg3;
            set
            {
                fg3 = value;
                OnPropertyChanged(nameof(Fg3));
            }
        }

        public string Fg
        {
            get => fg;
            set
            {
                fg = value;
                OnPropertyChanged(nameof(Fg));
            }
        }

        public string Ft
        {
            get => ft;
            set
            {
                ft = value;
                OnPropertyChanged(nameof(Ft));
            }
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
