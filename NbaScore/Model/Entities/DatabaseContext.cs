using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NbaScore.Model.Entities
{
    class DatabaseContext : DbContext
    {
        private readonly string DBNAME = "NbaScore.db";

        public DbSet<Team> Teams { get; set; }

        public DatabaseContext()
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath;

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DBNAME);
            }
            else
            {
                dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "..", "Library", DBNAME);
            }

            optionsBuilder.UseSqlite($"filename={dbPath}");
        }
    }
}
