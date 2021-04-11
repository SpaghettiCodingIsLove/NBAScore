using NbaScore.View.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaScore.ViewModel
{
    class MatchesViewModel
    {
        public string Test
        {
            get
            {
                return ApiService.GetGames().Data[0].HomeTeam.FullName;
            }
        }
    }
}
