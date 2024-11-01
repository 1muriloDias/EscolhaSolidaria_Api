using helpingout.Models;

namespace EscolhaSolidariaAPI.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Adicione esta propriedade se ela não existir
        public double Valor { get; set; }
        public int UsuarioId { get; set; }
    }
}
