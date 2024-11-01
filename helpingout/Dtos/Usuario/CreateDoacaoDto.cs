using EscolhaSolidariaAPI.Models;
using helpingout.Models;

namespace helpingout.Dtos
{
    public class CreateDoacaoDto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        // Método para converter CreateDoacaoDto em Doacao
        public Doacao ToDoacao()
        {
            return new Doacao
            {
                Nome = this.Nome,
                Valor = this.Valor
                // Adicione outros campos aqui, se necessário
            };
        }
    }
}
