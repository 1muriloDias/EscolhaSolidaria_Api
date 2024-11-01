namespace helpingout.Controllers
{
 
    using global::EscolhaSolidariaAPI.Models;

    namespace EscolhaSolidariaAPI.Services
    {
        public class DoacaoService
        {
            public Doacao SalvarDoacao(Doacao doacao)
            {
                // Aqui você colocaria a lógica para salvar a doação no banco de dados
                doacao.Id = new Random().Next(1, 1000); // Exemplo de ID gerado para a doação
                return doacao;
            }
        }
    }

}
