using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpingout.Data;
using helpingout.Dtos;
using helpingout.Interfaces;
using helpingout.Models;
using Microsoft.EntityFrameworkCore;


namespace helpingout.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiContext _context;

        public UsuarioRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

     

        public async Task CreateAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UsuarioHasAccount(string nome)
        {
            return await _context.Usuarios.AnyAsync(u => u.Nome == nome);
        }

        public Task<IEnumerable<Usuario>> GetAllAsync(QueryObject query)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByNameAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
