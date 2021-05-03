using NbaScore.Model.Entities;
using NbaScore.View.Services;
using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.ViewModel.BaseClasses;
using System.Collections.ObjectModel;

namespace NbaScore.ViewModel
{
    class MatchesViewModel : ViewModelBase
    {
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

        public ObservableCollection<Game> Games
        {
            get => ApiService.GetGames().Data;

        }

        public string Test
        {
            get
            {
                return ApiService.GetGames().Data[0].HomeTeam.FullName;
            }
        }

        public MatchesViewModel()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                string color = "#FA2400";
                if (date.DayOfWeek.ToString() != "Sunday")
                    color = "#000000";
                Dates.Add(new Date(date.Day, date.Month, date.Year, date.DayOfWeek.ToString(), color));
            }

            currentMonth = DateTime.Now.ToString("MMMM") + ", " + year;
        }
    }
}
