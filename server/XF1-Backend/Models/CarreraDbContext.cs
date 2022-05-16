using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XF1_Backend.Models
{
    public class CarreraDbContext : DbContext
    {
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Fechas> FechasCarrera { get; set; }
        public CarreraDbContext(DbContextOptions<CarreraDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>().ToTable("Carrera");
            modelBuilder.Entity<Fechas>().ToView("FechasCarrera").HasNoKey();
        }
    }
}

