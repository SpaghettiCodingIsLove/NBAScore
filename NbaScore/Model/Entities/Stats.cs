using System;
using System.Collections.Generic;
using System.Text;

namespace NbaScore.Model.Entities
{
    class Stats
    {
        long id;
        int ast;
        int blk;
        int dreb;
        double fg3_pct;
        int fg3a;
        int fg3m;
        double fg_pct;
        int fga;
        int fgm;
        double ft_pct;
        int fta;
        int ftm;
        Game game;
        string min;
        int oreb;
        int pf;
        Player player;
        int pts;
        int reb;
        int stl;
        Team team;
        int turnover;

        public Stats() { }
        public Stats(long id,
        int ast,
        int blk,
        int dreb,
        double fg3_pct,
        int fg3a,
        int fg3m,
        double fg_pct,
        int fga,
        int fgm,
        double ft_pct,
        int fta,
        int ftm,
        Game game,
        string min,
        int oreb,
        int pf,
        Player player,
        int pts,
        int reb,
        int stl,
        Team team,
        int turnover)
        {
            this.id = id;
            this.ast = ast;
            this.blk = blk;
            this.dreb = dreb;
            this.fg3_pct = fg3_pct;
            this.fg3a = fg3a;
            this.fg3m = fg3m;
            this.fg_pct = fg_pct;
            this.fga = fga;
            this.fgm = fgm;
            this.ft_pct = ft_pct;
            this.fta = fta;
            this.ftm = ftm;
            this.game = game;
            this.min = min;
            this.oreb = oreb;
            this.pf = pf;
            this.player = player;
            this.pts = pts;
            this.reb = reb;
            this.stl = stl;
            this.team = team;
            this.turnover = turnover;
        }

        public long Id { get => id; private set { } }
        public string Min { get => min; private set { } }
        public int Fgm { get => fgm; private set { } }
        public int Fga { get => fga; private set { } }
        public int Fg3m { get => fg3m; private set { } }
        public int Fg3a { get => fg3a; private set { } }
        public int Ftm { get => ftm; private set { } }
        public int Fta { get => fta; private set { } }
        public int Oreb { get => oreb; private set { } }
        public int Dreb { get => dreb; private set { } }
        public int Reb { get => reb; private set { } }
        public int Ast { get => ast; private set { } }
        public int Stl { get => stl; private set { } }
        public int Blk { get => blk; private set { } }
        public int Turnover { get => turnover; private set { } }
        public int Pf { get => pf; private set { } }
        public int Pts { get => pts; private set { } }
        public double Fg_pct { get => fg_pct; private set { } }
        public double Fg3_pct { get => fg3_pct; private set { } }
        public double Ft_pct { get => ft_pct; private set { } }
        public Game Game { get => game; private set { } }
        public Team Team { get => team; private set { } }
        public Player Player { get => player; private set { } }

    }
}
