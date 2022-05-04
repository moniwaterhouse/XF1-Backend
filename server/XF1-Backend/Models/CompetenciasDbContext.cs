using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XF1_Backend.Models
{
    public class CompetenciasDbContext : DbContext
    {
        public DbSet<Competencias> Competencias { get; set; }
        public CompetenciasDbContext(DbContextOptions<CompetenciasDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competencias>().ToTable("Competencias");
        }
    }
}
