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
        public DbSet<InfoLigaPrivada> InfoLigaPrivadas { get; set; }
        public DbSet<UsuariosLiga> UsuariosLigas { get; set; }
        public DbSet<CantidadJugador> CantidadJugadores { get; set; }
        public DbSet<CampeonatoActual> CampeonatoActual { get; set; }
        public DbSet<IdPrivadas> IdPrivadas { get; set; }

        public DbSet<NuevaLiga> NuevaLiga { get; set; }
        public DbSet<ActualizarLiga> ActualizarLigas { get; set; }

        public LigaDbContext(DbContextOptions<LigaDbContext> options) : base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Liga>().ToTable("Liga").HasNoKey();
            modelBuilder.Entity<PuntajesPublica>().ToView("PuntajesPublica").HasNoKey();
            modelBuilder.Entity<InfoLigaPrivada>().HasNoKey();
            modelBuilder.Entity<UsuariosLiga>().HasNoKey();
            modelBuilder.Entity<CantidadJugador>().HasNoKey();
            modelBuilder.Entity<CampeonatoActual>().HasNoKey();
            modelBuilder.Entity<NuevaLiga>().HasNoKey();
            modelBuilder.Entity<IdPrivadas>().HasNoKey();
            modelBuilder.Entity<ActualizarLiga>().HasNoKey();
        }
    }
}
