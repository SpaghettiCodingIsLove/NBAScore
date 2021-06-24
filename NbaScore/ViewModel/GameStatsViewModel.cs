using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.View;
using NbaScore.Model.Entities;
using NbaScore.Model;
using NbaScore.ViewModel.BaseClasses;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using NbaScore.View.Services;
using System.Windows.Input;

namespace NbaScore.ViewModel
{
    class GameStatsViewModel : ViewModelBase
    {
        private string title;

        public GameStatsViewModel()
        {
            game = HelperClass.Game;
            stats = ApiService.GetStatsFromGame(game.Id);
            Title = $"{game.HomeTeam.Name} vs {game.VisitorTeam.Name}";
            currentStats = new ObservableCollection<Stats>();
            AwayButton = new Command(Away);
            HomeButton = new Command(Home);
            GoToHome = new Command(GoToHomeTeam);
            GoToAway = new Command(GoToAwayTeam);
            SelectedFilter = "All";
        }

        private Game game;
        public Game Game
        {
            get => game;
            set => game = value;
        }

        private ObservableCollection<Stats> currentStats;

        public ObservableCollection<Stats> CurrentStats
        {
            get => currentStats;
            set => currentStats = value;
        }

        private StatsData stats;
        public StatsData Stats
        {
            get => stats;
            set => stats = value;
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
        public ICommand AwayButton { get; }
        public ICommand HomeButton { get; }
        public ICommand GoToAway { get; }
        public ICommand GoToHome { get; }

        private void Away()
        {
            currentStats.Clear();
            foreach (var s in stats.Data)
            {
                if (s.Team.Id == game.VisitorTeam.Id)
                {
                    currentStats.Add(s);
                }
            }

        }
        private void Home()
        {
            currentStats.Clear();
            foreach (var s in stats.Data)
            {
                if (s.Team.Id == game.HomeTeam.Id)
                {
                    currentStats.Add(s);
                }
            }
        }
        private void GoToHomeTeam()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new TeamPage(Game.HomeTeam));
        }
        private void GoToAwayTeam()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new TeamPage(Game.VisitorTeam));
        }
        public Stats PlayerStats
        {
            get => null;
            set
            {
                OnPropertyChanged(nameof(PlayerStats));

                if(value != null)
                {
                    HelperClass.PlayerStats = value;
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new PlayerGameStats());
                }
                
            }
        }

        public List<string> PlayerFilters
        {
            get
            {
                return new List<string>() { "All", "Home", "Visitors" };
            }
        }

        private string selectedFilter;
        public string SelectedFilter
        {
            get => selectedFilter;
            set
            {
                if (value != default)
                {
                    SetProperty(ref selectedFilter, value);

                    switch (selectedFilter)
                    {
                        case "All":
                            currentStats.Clear();
                            stats.Data.ForEach(x => currentStats.Add(x));
                            break;
                        case "Home":
                            currentStats.Clear();
                            foreach (var s in stats.Data)
                            {
                                if (s.Team.Id == game.HomeTeam.Id)
                                {
                                    currentStats.Add(s);
                                }
                            }
                            break;
                        case "Visitors":
                            currentStats.Clear();
                            foreach (var s in stats.Data)
                            {
                                if (s.Team.Id == game.VisitorTeam.Id)
                                {
                                    currentStats.Add(s);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
