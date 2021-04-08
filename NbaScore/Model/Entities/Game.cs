using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.Model.Entities;

namespace NbaScore.Model.Entities
{
    class Game
    {
        long id;
        string date;
        int home_team_score;
        int visitor_team_score;
        int season;
        int period;
        string status;
        string time;
        bool postseason;
        Team home_team;
        long? home_team_id;
        Team visitor_team;
        long? visitor_team_id;

        public Game() { }

        public Game(long id, string date, int home_team_score,
        int visitor_team_score,
        int season,
        int period,
        string status,
        string time,
        bool postseason,
        Team home_team,
        long? home_team_id,
        Team visitor_team,
        long? visitor_team_id)
        {
            this.id = id;
            this.date = date;
            this.home_team_score = home_team_score;
            this.visitor_team_score = visitor_team_score;
            this.season = season;
            this.period = period;
            this.status = status;
            this.postseason = postseason;
            this.home_team = home_team;
            this.home_team_id = home_team_id;
            this.visitor_team = visitor_team;
            this.visitor_team_id = visitor_team_id;
        }

        public long Id { get => id; private set { } }
        public string Date { get => date; private set { } }
        public int Home_team_score { get => home_team_score; private set { } }
        public int Visitor_team_score { get => visitor_team_score; private set { } }
        public int Season { get => season; private set { } }
        public int Period { get => period; private set { } }
        public string Status { get => status; private set { } }
        public string Time { get => time; private set { } }
        public bool Postseason { get => postseason; private set { } }
        public Team Home_team { get => home_team; private set { } }
        public long? Home_team_id { get => home_team_id; private set { } }
        public Team Visitor_team { get => visitor_team; private set { } }
        public long? Visitor_team_id { get => visitor_team_id;  private set { } }
    }
}
