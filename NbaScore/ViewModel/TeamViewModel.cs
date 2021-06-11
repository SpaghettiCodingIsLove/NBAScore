using NbaScore.Model.Entities;
using NbaScore.ViewModel.BaseClasses;
using System.Linq;
using System.Windows.Input;

namespace NbaScore.ViewModel
{
    class TeamViewModel : ViewModelBase
    {
        private readonly Team team;
        public TeamViewModel(Team team)
        {
            this.team = team;
        }

        public string Name => team.FullName;

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
                            }
                            else
                            {
                                context.Teams.Remove(team);
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
