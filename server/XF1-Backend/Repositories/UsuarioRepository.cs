﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;

namespace XF1_Backend.Repositories
{
    public class UsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CorreoUsuario> GetCorreos()
        {
            return _context.Correo.FromSqlRaw(UsuarioRequests.getCorreos).ToList();
        }

        public Usuario GetUsuarioPorCorreo(string correo)
        {
            return _context.Usuario.FromSqlRaw(UsuarioRequests.getUsuarioPorCorreo(correo)).FirstOrDefault();
        }

        public async Task Complete(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AddUsuarioLiga(Usuario usuario)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(UsuarioRequests.anadirUsuarioLiga(usuario.Correo));
            await _context.SaveChangesAsync();
        }

        public async Task AbandonarLiga(Usuario usuario)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(UsuarioRequests.eliminarUsuarioLiga(usuario.Correo));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CorreoUsuario>> GetCorreoUsuarios()
        {
            return await _context.Correo.FromSqlRaw(UsuarioRequests.getCorreos).ToListAsync();
        }

        public async Task<IEnumerable<EscuderiaUsuario>> GetEscuderiaUsuarios()
        {
            return await _context.EscuderiaUsuario.FromSqlRaw(UsuarioRequests.getEscuderias).ToListAsync();
        }

        public async Task<IEnumerable<UsuarioPerfil>> GetPerfilUsuario(string correo)
        {
            return await _context.UsuarioPerfil.FromSqlRaw(UsuarioRequests.getPerfilUsuario(correo)).ToListAsync();
        }

    }
}