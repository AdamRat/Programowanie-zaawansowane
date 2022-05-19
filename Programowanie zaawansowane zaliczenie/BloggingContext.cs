using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Programowanie_zaawansowane_zaliczenie.Models;

namespace Programowanie_zaawansowane_zaliczenie
{
    public class BloggingContext : DbContext
    {
        public DbSet<Adresses> Adresses { get; set; }
        public DbSet<ContactCategories> ContactCategories { get; set; }
        public DbSet<ContactVievModel> ContactVievModel { get; set; }

        public string DbPath { get; }

        public BloggingContext()
        {
            DbPath = System.IO.Path.Join
                (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Contacts.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    
}
