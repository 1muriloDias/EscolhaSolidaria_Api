using System.Collections.Generic;
using System.Threading.Tasks;
using EscolhaSolidariaAPI.Models;
using helpingout.Data;
using helpingout.Interfaces;
using helpingout.Models;
using Microsoft.EntityFrameworkCore;

namespace helpingout.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly ApiContext _context;

        public DoacaoRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doacao>> GetAllAsync()
        {
            return await _context.Doacoes.Include(d => d.Nome).ToListAsync();
        }

        public async Task<Doacao> GetByIdAsync(int id)
        {
            return await _context.Doacoes.Include(d => d.Nome).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateAsync(Doacao doacao)
        {
            await _context.Doacoes.AddAsync(doacao);
            await _context.SaveChangesAsync();
        }
    }
}
