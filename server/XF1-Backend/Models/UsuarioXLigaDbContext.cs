using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XF1_Backend.Models
{
    public class UsuarioXLigaDbContext : DbContext
    {
        public DbSet<UsuarioXLiga> UsuarioXLiga { get; set; }
        public UsuarioXLigaDbContext(DbContextOptions<UsuarioXLigaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioXLiga>().ToTable("UsuarioXLiga");
        }
    }
}
