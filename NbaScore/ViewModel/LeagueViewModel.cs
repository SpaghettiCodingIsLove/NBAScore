using NbaScore.Model.Entities;
using NbaScore.View;
using NbaScore.View.Services;
using NbaScore.ViewModel.BaseClasses;
using System.Collections.Generic;
using System.Linq;

namespace NbaScore.ViewModel
{
    class LeagueViewModel : ViewModelBase
    {
        private static List<Team> allTeams = null;
        public LeagueViewModel(bool conference, string name)
        {
            Name = name;

            if (allTeams == null)
            {
                allTeams = ApiService.GetTeams()?.Data.ToList();
            }

            if (allTeams != null)
            {
                if (conference)
                {
                    Teams = allTeams.Where(x => x.Conference.Equals(name, System.StringComparison.InvariantCultureIgnoreCase)).ToList();
                }
                else
                {
                    Teams = allTeams.Where(x => x.Division.Equals(name, System.StringComparison.InvariantCultureIgnoreCase)).ToList();
                }
            }
        }

        public List<Team> Teams { get; }

        public Team TeamSelected
        {
            get => null;
            set
            {
                OnPropertyChanged(nameof(TeamSelected));

                if (value != null)
                {
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new TeamPage(value));
                }
            }
        }

        public string Name { get; set; }
    }
}
