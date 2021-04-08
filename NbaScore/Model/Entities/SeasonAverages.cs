using System;
using System.Collections.Generic;
using System.Text;

namespace NbaScore.Model.Entities
{
    class SeasonAverages
    {
        int games_played;
        long player_id;
        int season;
        string min;
        double fgm;
        double fga;
        double fg3m;
        double fg3a;
        double ftm;
        double fta;
        double oreb;
        double dreb;
        double reb;
        double ast;
        double stl;
        double blk;
        double turnover;
        double pf;
        double pts;
        double fg_pct;
        double fg3_pct;
        double ft_pct;

        public SeasonAverages() { }
        public SeasonAverages(int games_played,
        long player_id,
        int season,
        string min,
        double fgm,
        double fga,
        double fg3m,
        double fg3a,
        double ftm,
        double fta,
        double oreb,
        double dreb,
        double reb,
        double ast,
        double stl,
        double blk,
        double turnover,
        double pf,
        double pts,
        double fg_pct,
        double fg3_pct,
        double ft_pct) 
        {
            this.games_played = games_played;
            this.season = season;
            this.min = min;
            this.player_id = player_id;
            this.fgm = fgm;
            this.fga = fga;
            this.fg3m = fg3m;
            this.fg3a = fg3a;
            this.ftm = ftm;
            this.fta = fta;
            this.oreb = oreb;
            this.dreb = dreb;
            this.reb = reb;
            this.ast = ast;
            this.stl = stl;
            this.blk = blk;
            this.turnover = turnover;
            this.pf = pf;
            this.pts = pts;
            this.fg_pct = fg_pct;
            this.fg3_pct = fg3_pct;
            this.ft_pct = ft_pct;
        }

        public int Games_played { get => games_played; private set { } }
        public long Player_id { get => player_id; private set { } }
        public int Season { get=> season; private set { } }
        public string Min { get=> min; private set { } }
        public double Fgm { get => fgm; private set { } }
        public double Fga { get => fga; private set { } }
        public double Fg3m { get => fg3m; private set { } }
        public double Fg3a { get => fg3a; private set { } }
        public double Ftm { get => ftm; private set { } }
        public double Fta { get => fta; private set { } }
        public double Oreb { get => oreb; private set { } }
        public double Dreb { get => dreb; private set { } }
        public double Reb { get => reb; private set { } }
        public double Ast { get => ast; private set { } }
        public double Stl { get => stl; private set { } }
        public double Blk { get => blk; private set { } }
        public double Turnover { get => turnover; private set { } }
        public double Pf { get => pf; private set { } }
        public double Pts { get => pts; private set { } }
        public double Fg_pct { get => fg_pct; private set { } }
        public double Fg3_pct { get => fg3_pct; private set { } }
        public double Ft_pct { get => ft_pct; private set { } }
    }
}
