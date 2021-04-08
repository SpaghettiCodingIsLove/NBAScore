using System;
using System.Collections.Generic;
using System.Text;

namespace NbaScore.Model.Entities
{
    class Player
    {
        long id;
        string first_name;
        string last_name;
        string position;
        int? height_feet;
        int? height_inches;
        int? weight_pounds;
        Team team;
        long? team_id;

        public Player() { }
        public Player(long id,
        string first_name,
        string last_name,
        string position,
        int? height_feet,
        int? height_inches,
        int? weight_pounds,
        Team team,
        long? team_id) 
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.position = position;
            this.height_feet = height_feet;
            this.height_inches = height_inches;
            this.weight_pounds = weight_pounds;
            this.team = team;
            this.team_id = team_id;
        }

        public long Id { get => id; private set { } }
        public string First_name { get => first_name; private set { } }
        public string Lasr_name { get => last_name; private set { } }
        public int? Height_feet { get=> height_feet; private set { } }
        public int? Height_inches { get => height_inches; private set { } }
        public int? Weight_pounds { get => weight_pounds; private set { } }
        public Team Team { get => team; private set { } }
        public long? Team_id { get => team_id; private set { } }
    }
}
