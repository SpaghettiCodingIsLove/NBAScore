using System;
using System.Collections.Generic;
using System.Text;
using NbaScore.Model.Entities;

namespace NbaScore.Model.Entities
{
    class Team
    {
        long id;
        string abbreviation;
        string city;
        string conference;
        string division;
        string full_name;
        string name;

        public Team() { }
        public Team(long id,
        string abbreviation,
        string city,
        string conference,
        string division,
        string full_name,
        string name) 
        {
            this.id = id;
            this.abbreviation = abbreviation;
            this.city = city;
            this.conference = conference;
            this.division = division;
            this.full_name = full_name;
            this.name = name;
        }

        public long Id { get => id; private set { } }
        public string Abbreviation { get => abbreviation; private set { } }
        public string City { get => city; private set { } }
        public string Conference { get => conference; private set { } }
        public string Division { get => division; private set { } }
        public string Full_name { get => full_name; private set { } }
        public string Name { get => name; private set { } }
    }
}
