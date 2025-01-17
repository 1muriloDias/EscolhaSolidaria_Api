﻿using System.Threading.Tasks;
using helpingout.Data;
using helpingout.Models;

namespace helpingout.Controllers
{
    public class UsuarioService
    {
        private readonly ApiContext _context;

        public UsuarioService(ApiContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(string userId)
        {
            return await _context.Usuarios.FindAsync(userId);
        }
    }
}
