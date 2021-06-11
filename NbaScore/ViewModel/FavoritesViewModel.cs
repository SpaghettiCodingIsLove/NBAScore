using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.ViewModel.BaseClasses;
using NbaScore.View;
using NbaScore.Model.Entities;
using System.Collections.ObjectModel;
using System.Linq;
using NbaScore.Model;

namespace NbaScore.ViewModel
{
    class FavoritesViewModel : ViewModelBase
    {
        private ObservableCollection<Team> favoriteTeams = new ObservableCollection<Team>();

        private Team team;
        public FavoritesViewModel()
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                List<Team> tmp = context.Teams.ToList();
                foreach(Team team in tmp)
                {
                    FavoriteTeams.Add(team);
                }
            }
        }

        public ObservableCollection<Team> FavoriteTeams
        {
            get => favoriteTeams;
            set
            {
                favoriteTeams = value;
                OnPropertyChanged(nameof(FavoriteTeams));
            }
        }

        public Team Team
        {
            get => team;
            set
            {
                team = value;
                if(value != null)
                {
                    HelperClass.team = team;
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new TeamGames());
                    Team = null;
                }
                OnPropertyChanged(nameof(Team));
            }
        }
    }
}
