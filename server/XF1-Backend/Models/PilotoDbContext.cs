using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace XF1_Backend.Models
{
    public class PilotoDbContext : DbContext
    {
        public DbSet<Piloto> Pilotos { get; set; }
        public PilotoDbContext(DbContextOptions<PilotoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piloto>().ToTable("Piloto").HasNoKey();
        }

    }
}
