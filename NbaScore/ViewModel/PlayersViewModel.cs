using NbaScore.Model;
using NbaScore.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NbaScore.ViewModel
{
    class PlayersViewModel : ViewModelBase
    {
        public PlayersViewModel()
        {
            loading = true;
            Init();
        }

        private async Task Init()
        {
            await HelperClass.Init();

            Loading = false;
        }

        private bool loading;
        public bool Loading
        {
            get => loading;
            set => SetProperty(ref loading, value);
        }
    }
}
