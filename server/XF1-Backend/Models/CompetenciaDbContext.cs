using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XF1_Backend.Models
{
    public class CompetenciaDbContext : DbContext
    {
        public DbSet<Competencia> Competencia { get; set; }
        public CompetenciaDbContext(DbContextOptions<CompetenciaDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competencia>().ToTable("Competencia");
        }
    }
}
