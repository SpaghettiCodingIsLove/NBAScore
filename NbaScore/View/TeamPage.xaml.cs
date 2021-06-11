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
    public partial class TeamPage : ContentPage
    {
        public TeamPage(Team team)
        {
            this.BindingContext = new TeamViewModel(team);
            InitializeComponent();
        }
    }
}