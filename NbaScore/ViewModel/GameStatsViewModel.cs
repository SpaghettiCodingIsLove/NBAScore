﻿using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.View;
using NbaScore.Model.Entities;
using NbaScore.Model;
using NbaScore.ViewModel.BaseClasses;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using NbaScore.View.Services;
using System.Windows.Input;

namespace NbaScore.ViewModel
{
    class GameStatsViewModel : ViewModelBase
    {

        public GameStatsViewModel()
        {
            game = HelperClass.game;
            stats = ApiService.GetStatsFromGame(game.Id);
            currentStats = new ObservableCollection<Stats>(stats.Data);
            A = new Command(Away);
            H = new Command(Home);
        }

        private Game game;
        public Game Game
        {
            get => game;
            set => game = value;
        }

        private ObservableCollection<Stats> currentStats;

        public ObservableCollection<Stats> CurrentStats
        {
            get => currentStats;
            set => currentStats = value;
        }

        private StatsData stats;
        public StatsData Stats
        {
            get => stats;
            set => stats = value;
        }

        public ICommand A { get; }
        public ICommand H { get; }

        private void Away()
        {
            currentStats.Clear();
            foreach (var s in stats.Data)
            {
                if (s.Team.Id == game.VisitorTeam.Id)
                {
                    currentStats.Add(s);
                }
            }

        }
        private void Home()
        {
            currentStats.Clear();
            foreach (var s in stats.Data)
            {
                if (s.Team.Id == game.HomeTeam.Id)
                {
                    currentStats.Add(s);
                }
            }
        }
    }
}
