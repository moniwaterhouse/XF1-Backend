using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XF1_Backend.Models
{
    public class CampeonatoDbContext : DbContext
    {
        public DbSet<Campeonato> Campeonato { get; set; }
        public DbSet<Fechas> Fechas { get; set; }
        public CampeonatoDbContext(DbContextOptions<CampeonatoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campeonato>().ToTable("Campeonato");
            modelBuilder.Entity<Fechas>().ToView("Fechas").HasNoKey();
        }
    }
}
