using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Interfaces
{
    public interface IMovimentacaoService
    {
        Task<MovimentacaoViewModel> Pesquisar(MovimentacaoViewModel model);
        Task<MovimentacaoViewModel> Obter(Int64 id);
        Task<MovimentacaoViewModel> Listar();
        Task<MovimentacaoViewModel> Iniciar(MovimentacaoViewModel model);
        Task<MovimentacaoViewModel> Finalizar(MovimentacaoViewModel model);
    }
}
