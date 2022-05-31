using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XF1_Backend.Models
{
    public class LigaDbContext : DbContext
    {
        public DbSet<Liga> Liga { get; set; }
        public DbSet<PuntajesPublica> PuntajesPublicas { get; set;}

        public LigaDbContext(DbContextOptions<LigaDbContext> options) : base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Liga>().ToTable("Liga").HasNoKey();
            modelBuilder.Entity<PuntajesPublica>().ToView("PuntajesPublica").HasNoKey();
        }
    }
}
