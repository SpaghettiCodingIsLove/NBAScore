using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NbaScore.Model;
using NbaScore.Model.Entities;
using NbaScore.View;
using NbaScore.ViewModel.BaseClasses;
using NbaScore.View.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;

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

            RemoveTeam = new Command(deleteTeam);
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            if (month <= 9)
                year -= 1;

            Season = $"Season: {year}/{year + 1}";
            Thread thread = new Thread(() =>
            {
                Init();
            });

            thread.Start();
        }

        private async Task Init()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            if (month <= 9)
                year -= 1;

            Games response = ApiService.GetFavoriteTeamGames(year, Team.Id, 1);
            ObservableCollection<Game> tmpGames = response.Data;
            while (response.Meta.NextPage != null)
            {
                Games temp = ApiService.GetFavoriteTeamGames(year, Team.Id, (int)response.Meta.NextPage);
                foreach (var game in temp.Data)
                {
                    tmpGames.Add(game);
                }
            }

            for (int i = 0; i < tmpGames.Count; i++)
            {
                for (int j = 0; j < tmpGames.Count - 1; j++)
                {
                    if (tmpGames[j].Date > tmpGames[j + 1].Date)
                    {
                        Game g = tmpGames[j];
                        tmpGames[j] = tmpGames[j + 1];
                        tmpGames[j + 1] = g;
                    }
                }
            }

            TeamGames = tmpGames;
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
                int wins = 0;
                int loses = 0;

                foreach (Game game in teamGames)
                {
                    if (game.Postseason == false)
                    {
                        if (game.HomeTeamScore > game.VisitorTeamScore)
                            wins++;
                        else
                            loses++;
                    }
                }
                Record = "Record: Wins:" + wins + ", Loses:" + loses;
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

        public ICommand RemoveTeam { get; }

        private void deleteTeam()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Teams.Remove(team);
                context.SaveChangesAsync();
            }
            Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
