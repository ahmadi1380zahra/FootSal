
using Clean.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistance.EF
{
    public class EFDataContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FootsalDB;User ID = sa; Password = 123;TrustServerCertificate = True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
