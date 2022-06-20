using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace XF1_Backend.Models
{
    public class PuntajeDBContext : DbContext
    {
        public DbSet<Puntaje> Puntajes { get; set; }

        public PuntajeDBContext(DbContextOptions<PuntajeDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Puntaje>().HasNoKey();
        }
    }
}
