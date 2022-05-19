using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace XF1_Backend.Models
{
    public class EquipoDbContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Id> Ids { get; set; }

        public EquipoDbContext(DbContextOptions<EquipoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>().ToTable("Equipo");
            modelBuilder.Entity<Id>().HasNoKey();
        }
    }
}
