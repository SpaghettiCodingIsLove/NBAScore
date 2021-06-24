using NbaScore.Model.Entities;
using NbaScore.View.Services;
using NbaScore.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NbaScore.ViewModel
{
    public class Season
    {
        public int Year { get; set; }
        public string Name => $"{Year}/{Year + 1}";

        public override string ToString() => Name;
    }

    class PlayerViewModel : ViewModelBase
    {
        public Player Player { get; set; }

        public PlayerViewModel(Player player)
        {
            Player = player;
            int yearNow = DateTime.Now.Year;

            if (DateTime.Now.Month <= 9)
            {
                yearNow -= 1;
            }

            Seasons = Enumerable.Range(1979, yearNow - 1978).OrderByDescending(x => x).Select(x => new Season() { Year = x }).ToList();           

            SelectedSeason = Seasons.First();
        }

        public string Name => $"{Player.FirstName} {Player.LastName}";

        public string Height => Player.HeightFeet.HasValue ? $"{Player.HeightFeet}'{Player.HeightInches}\"" : string.Empty;

        public string Weight => Player.WeightPounds.HasValue ? $"{Player.WeightPounds} lbs" : string.Empty;
        public List<Season> Seasons { get; set; }

        private Season selectedSeason;
        public Season SelectedSeason
        {
            get => selectedSeason;
            set
            {
                if (value != default)
                {
                    SetProperty(ref selectedSeason, value);

                    Stats = ApiService.GetPlayersSeasonAverages(Player.Id, value.Year)?.Data?.FirstOrDefault();
                    if (Stats == null)
                    {
                        Visible = false;
                    }
                    else
                    {
                        Visible = true;
                    }
                }
            }
        }

        private SeasonAverages stats;
        public SeasonAverages Stats
        {
            get => stats;
            set => SetProperty(ref stats, value);
        }

        private bool visible;
        public bool Visible
        {
            get => visible;
            set => SetProperty(ref visible, value);
        }
    }
}
