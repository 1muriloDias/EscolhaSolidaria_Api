using System.Collections.Generic;
using System.Threading.Tasks;
using EscolhaSolidariaAPI.Models;
using helpingout.Models;

namespace helpingout.Interfaces
{
    public interface IDoacaoRepository
    {
        Task<IEnumerable<Doacao>> GetAllAsync();
        Task<Doacao> GetByIdAsync(int id);
        Task CreateAsync(Doacao doacao);
    }
}
