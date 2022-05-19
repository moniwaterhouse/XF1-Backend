using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace XF1_Backend.Models
{
    public class EscuderiaDbContext : DbContext
    {
        public DbSet<Escuderia> Escuderia { get; set; }

        public EscuderiaDbContext(DbContextOptions<EscuderiaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Escuderia>().ToTable("Escuderia").HasNoKey();
        }

    }
}
