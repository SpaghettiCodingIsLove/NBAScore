using NbaScore.View;
using NbaScore.ViewModel.BaseClasses;
using System.Windows.Input;

namespace NbaScore.ViewModel
{
    class ClubsViewModel : ViewModelBase
    {
        private ICommand goTo;
        public ICommand GoTo
        {
            get
            {
                if (goTo == null)
                {
                    goTo = new RelayCommand<string>(x =>
                    {
                        switch (x)
                        {
                            case "conf":
                                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Conferences());
                                break;
                            case "div":
                                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Divisions());
                                break;
                            case "East":
                                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new League(true, x));
                                break;
                            case "West":
                                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new League(true, x));
                                break;
                            default:
                                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new League(false, x));
                                break;
                        }
                    });
                }

                return goTo;
            }
        }
    }
}
