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
        public DbSet<CorreoUsuario> Correo { get; set; }
        public DbSet<EscuderiaUsuario> EscuderiaUsuario { get; set; }
        public DbSet<Id> Ids { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario").HasKey("Correo");
            modelBuilder.Entity<CorreoUsuario>().HasNoKey();
            modelBuilder.Entity<EscuderiaUsuario>().HasNoKey();
            modelBuilder.Entity<Id>().HasNoKey();
            //modelBuilder.Entity<Equipo>().HasKey("Id");
        }
    }
}
