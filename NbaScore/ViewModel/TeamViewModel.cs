using NbaScore.Model;
using NbaScore.Model.Entities;
using NbaScore.ViewModel.BaseClasses;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NbaScore.ViewModel
{
    class TeamViewModel : ViewModelBase
    {
        private readonly Team team;
        public TeamViewModel(Team team)
        {
            this.team = team;
            loading = true;
            initialized = false;
            Init();
        }

        private async Task Init()
        {
            await HelperClass.Init();

            Players = HelperClass.AllPlayers.Where(x => x.Team.Id == team.Id);
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

        private IEnumerable<Player> players;
        public IEnumerable<Player> Players
        {
            get => players;
            set => SetProperty(ref players, value);
        }

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
