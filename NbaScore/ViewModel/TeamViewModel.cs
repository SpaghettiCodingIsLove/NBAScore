using NbaScore.Model;
using NbaScore.Model.Entities;
using NbaScore.View;
using NbaScore.View.Services;
using NbaScore.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NbaScore.ViewModel
{
    class TeamViewModel : ViewModelBase
    {
        private readonly Team team;
        public TeamViewModel(Team team)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                if (context.Teams.Any(x => x.Id == team.Id))
                {
                    color = Color.FromHex("#c9082a");
                    text = "Remove from favorites";
                }
                else
                {
                    color = Color.FromHex("#17408b");
                    text = "Add to fovorites";
                }
            }
            this.team = team;
            loading = true;
            initialized = false;
            Thread thread = new Thread(() =>
            {
                Init();
            });

            int year = DateTime.Now.Year;
            int wins = 0;
            int loses = 0;

            if (DateTime.Now.Month <= 9)
            {
                year -= 1;
            }

            Games response = ApiService.GetFavoriteTeamGames(year, team.Id, 1);
            foreach (Game game in response.Data)
            {
                if (!game.Postseason)
                {
                    if (game.HomeTeamScore > game.VisitorTeamScore)
                    {
                        wins++;
                    }
                    else
                    {
                        loses++;
                    }
                }
            }

            while (response.Meta.NextPage.HasValue)
            {
                response = ApiService.GetFavoriteTeamGames(year, team.Id, response.Meta.NextPage.Value);
                foreach (Game game in response.Data)
                {
                    if (!game.Postseason)
                    {
                        if (game.HomeTeamScore > game.VisitorTeamScore)
                        {
                            wins++;
                        }
                        else
                        {
                            loses++;
                        }
                    }
                }
            }

            Season = $"Season: {year}/{year + 1}";
            Record = $"Wins: {wins}   Loses: {loses}";
            thread.Start();
        }

        private async Task Init()
        {
            while (!HelperClass.Initialized)
            {
                Thread.Sleep(1000);
            }

            Players = HelperClass.AllPlayers.Where(x => x.Team.Id == team.Id).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            Loading = false;
            Initialized = true;
        }

        public string Name => team.FullName;

        private bool loading;
        public bool Loading
        {
            get => loading;
            set => SetProperty(ref loading, value);
        }

        private bool initialized;
        public bool Initialized
        {
            get => initialized;
            set => SetProperty(ref initialized, value);
        }

        public Player PlayerSelected
        {
            get => null;
            set
            {
                OnPropertyChanged(nameof(PlayerSelected));

                if (value != null)
                {
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new PlayerPage(value));
                }
            }
        }

        private IEnumerable<Player> players;
        public IEnumerable<Player> Players
        {
            get => players;
            set => SetProperty(ref players, value);
        }

        private Color color;
        public Color Color
        {
            get => color;
            set => SetProperty(ref color, value);
        }

        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Image => team.Abbreviation;

        public string Record { get; set; }
        public string Season { get; set; }

        private ICommand teamDb;
        public ICommand TeamDb
        {
            get
            {
                if (teamDb == null)
                {
                    teamDb = new RelayCommand(async () =>
                    {
                        using (DatabaseContext context = new DatabaseContext())
                        {
                            if (!context.Teams.Any(x => x.Id == team.Id))
                            {
                                context.Teams.Add(team);
                                Color = Color.FromHex("#c9082a");
                                Text = "Remove from favorites";
                            }
                            else
                            {
                                context.Teams.Remove(team);
                                Color = Color.FromHex("#17408b");
                                Text = "Add to fovorites";
                            }

                            await context.SaveChangesAsync();
                        }
                    });
                }

                return teamDb;
            }
        }
    }
}
