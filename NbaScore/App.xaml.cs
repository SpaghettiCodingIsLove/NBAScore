using NbaScore.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NbaScore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new BottomMenu();
            MainPage = new NavigationPage(new BottomMenu());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
