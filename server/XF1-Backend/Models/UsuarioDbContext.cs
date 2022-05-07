using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XF1_Backend.Models
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}
