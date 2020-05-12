using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace GTBA.Models
{
    public class ItemContext : DbContext
    {
        private string connectionString;
        public ItemContext()
        {
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "GTBASQLite.db3");
            connectionString = $"Filename={databasePath}";

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate(); //i.p.v. EnsureCreated kun je ook Migrate gebruiken
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }


    }
}
