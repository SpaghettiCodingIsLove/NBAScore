using NbaScore.Model.Entities;
using NbaScore.View.Services;
using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.ViewModel.BaseClasses;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using NbaScore.Model;
using NbaScore.View;

namespace NbaScore.ViewModel
{
    class GamesViewModel : ViewModelBase
    {
        private int month = DateTime.Now.Month;
        private int year = DateTime.Now.Year;

        private ObservableCollection<Date> dates = new ObservableCollection<Date>();
        public ObservableCollection<Date> Dates
        {
            get => dates;
            set
            {
                dates = value;
                OnPropertyChanged(nameof(Dates));
            }
        }

        private string currentMonth = "";
        public string CurrentMonth
        {
            get => currentMonth;
            set
            {
                currentMonth = value;
                OnPropertyChanged(nameof(CurrentMonth));
            }
        }

        private Game game;
        public Game Game
        {
            get => game;
            set
            {
                game = value;
                if(value != null)
                {
                    HelperClass.Game = value;
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new GameStats());
                    Game = null;
                }
                OnPropertyChanged(nameof(Game));
            }
        }

        private Date date;
        public Date Date
        {
            get => date;
            set
            {
                if(value != null)
                {
                    date = value;
                    string newDate = date.Year + "-" + date.Month + "-" + date.Day;
                    Games = ApiService.GetGamesByDate(newDate, newDate).Data;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        private ObservableCollection<Game> games = new ObservableCollection<Game>();
        public ObservableCollection<Game> Games
        {
            get => games;
            set
            {
                games = value;
                OnPropertyChanged(nameof(Games));
            }

        }

        public string Test
        {
            get
            {
                return ApiService.GetGames().Data[0].HomeTeam.FullName;
            }
        }

        public GamesViewModel()
        {
            Games = ApiService.GetGamesByDate("2021-05-03", "2021-05-03").Data;
            GetDates();

            for(int i=0; i<Dates.Count; i++)
            {
                if (Dates[i].Day == DateTime.Now.Day && Dates[i].Month == DateTime.Now.Month && Dates[i].Year == DateTime.Now.Year)
                    Date = Dates[i];
            }

            CurrentMonth = DateTime.Now.ToString("MMMM") + ", " + year;
            AddMonth = new Command(NextMonth);
            SubtractMonth = new Command(PrevMonth);
        }

        private void GetDates()
        {
            Dates.Clear();
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                string color = "#FA2400";
                if (date.DayOfWeek.ToString() != "Sunday")
                    color = "#000000";
                Dates.Add(new Date(date.Day, date.Month, date.Year, date.DayOfWeek.ToString(), color));
            }
        }

        private void NextMonth()
        {
            month += 1;
            if(month == 13)
            {
                month = 1;
                year += 1;
            }
            GetDates();
            CurrentMonth = new DateTime(year, month, 1).ToString("MMMM") + ", " + year.ToString();
        }

        public ICommand AddMonth { get; }

        private void PrevMonth()
        {
            month -= 1;
            if(month == 0)
            {
                month = 12;
                year -= 1;
            }
            GetDates();
            CurrentMonth = new DateTime(year, month, 1).ToString("MMMM") + ", " + year.ToString();
        }

        public ICommand SubtractMonth { get; }
    }
}
