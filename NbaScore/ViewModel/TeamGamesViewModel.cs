using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NbaScore.Model;
using NbaScore.Model.Entities;
using NbaScore.View;
using NbaScore.ViewModel.BaseClasses;
using NbaScore.View.Services;

namespace NbaScore.ViewModel
{
    class TeamGamesViewModel : ViewModelBase
    {
        private Team team;
        private ObservableCollection<Game> teamGames = new ObservableCollection<Game>();
        private Game game;
        private string season;
        private string record;

        public TeamGamesViewModel()
        {
            Team = HelperClass.Team;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            if (month <= 9)
                year -= 1;

            Games response = ApiService.GetFavoriteTeamGames(year, Team.Id, 1);
            TeamGames = response.Data;
            while(response.Meta.NextPage != null)
            {
                Games temp = ApiService.GetFavoriteTeamGames(year, Team.Id, (int)response.Meta.NextPage);
                foreach(var game in temp.Data)
                {
                    TeamGames.Add(game);
                }
            }

            int wins = 0;
            int loses = 0;

            foreach(Game game in TeamGames)
            {
                if(game.Postseason == false)
                {
                    if (game.HomeTeamScore > game.VisitorTeamScore)
                        wins++;
                    else
                        loses++;
                }
            }

            Season = year + "/" + (year + 1);
            Record = $"Wins: {wins}, Loses: {loses}";
        }

        public Team Team
        {
            get => team;
            set
            {
                team = value;
                OnPropertyChanged(nameof(Team));
            }
        }

        public ObservableCollection<Game> TeamGames
        {
            get => teamGames;
            set
            {
                teamGames = value;
                OnPropertyChanged(nameof(TeamGames));
            }
        }

        public Game Game
        {
            get => game;
            set
            {
                game = value;
                if(value != null)
                {
                    HelperClass.Game = value;
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new GameStats());
                    Game = null;
                }
                OnPropertyChanged(nameof(Game));
            }
        }

        public string Season
        {
            get => season;
            set
            {
                season = value;
                OnPropertyChanged(Season);
            }
        }

        public string Record
        {
            get => record;
            set
            {
                record = value;
                OnPropertyChanged(Record);
            }
        }
    }
}
