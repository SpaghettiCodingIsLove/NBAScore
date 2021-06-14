using NbaScore.Model;
using NbaScore.Model.Entities;
using NbaScore.View;
using NbaScore.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NbaScore.ViewModel
{
    class PlayersViewModel : ViewModelBase
    {

        private IEnumerable<Player> players;

        public PlayersViewModel()
        {
            loading = true;
            initialized = false;
            Init();
        }

        private async Task Init()
        {
            await HelperClass.Init();

            //tu można używać HelperClass.AllPlayers
            Players = HelperClass.AllPlayers.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            Loading = false;
            Initialized = true;
        }

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

        public IEnumerable<Player> Players
        {
            get => players;
            set => SetProperty(ref players, value);
        }
    }
}
