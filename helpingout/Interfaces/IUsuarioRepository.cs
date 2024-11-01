using helpingout.Dtos.Usuario;
using helpingout.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using helpingout.Dtos;


namespace helpingout.Interfaces
{
	public interface IUsuarioRepository
	{
        Task<IEnumerable<Usuario>> GetAllAsync(QueryObject query);
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> GetByNameAsync(string nome);
        Task<bool> UsuarioHasAccount(string nome);
        Task CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
