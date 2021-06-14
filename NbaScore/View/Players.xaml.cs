using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NbaScore.Model;

namespace NbaScore.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Players : ContentPage
    {
        public Players()
        {
            InitializeComponent();
        }
        
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            PlayersListView.BeginRefresh();
            
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                PlayersListView.ItemsSource = HelperClass.AllPlayers.Where(x => x.FirstName.ToLower().Contains(e.NewTextValue.ToLower()) || 
                x.LastName.ToLower().Contains(e.NewTextValue.ToLower())).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            }
            else
            {
                PlayersListView.ItemsSource = HelperClass.AllPlayers.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            }

            PlayersListView.EndRefresh();

        }
    }
}