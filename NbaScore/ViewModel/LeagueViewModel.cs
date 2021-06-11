using NbaScore.Model.Entities;
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
            if (allTeams == null)
            {
                allTeams = ApiService.GetTeams()?.Data.ToList();
            }

            if (allTeams != null)
            {
                if (conference)
                {
                    Teams = allTeams.Where(x => x.Conference.Equals(name, System.StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    Teams = allTeams.Where(x => x.Division.Equals(name, System.StringComparison.OrdinalIgnoreCase)).ToList();
                }

                /*using (DatabaseContext context = new DatabaseContext())
                {
                    //zapis
                    Team team = Teams.First();
                    if (!context.Teams.Any(x => x.Id == team.Id))
                    {
                        context.Teams.Add(Teams.First());
                        context.SaveChanges();
                    }
                    //odczyt
                    List<Team> teams = context.Teams.ToList();
                }*/
            }
        }

        public List<Team> Teams { get; }
    }
}
