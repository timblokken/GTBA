using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace GTBA.Models
{
    public class GTBAContext : DbContext
    {
        private string connectionString;

        public GTBAContext()
        {
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "GTBASQLite.db3");
            connectionString = $"Filename={databasePath}";

            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate(); //i.p.v. EnsureCreated kun je ook Migrate gebruiken
        }

        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Episode> Episodes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
}

