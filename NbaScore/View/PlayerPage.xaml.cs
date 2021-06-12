using NbaScore.Model.Entities;
using NbaScore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NbaScore.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage(Player player)
        {
            this.BindingContext = new PlayerViewModel(player);
            InitializeComponent();
        }
    }
}