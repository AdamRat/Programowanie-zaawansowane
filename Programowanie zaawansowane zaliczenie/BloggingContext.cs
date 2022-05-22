using System;
using System.Collections.Generic;
using System.IO;
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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={System.IO.Path.Join(Path.Combine(Directory.GetCurrentDirectory()), "Contacts.db")}");
    }

    
}
