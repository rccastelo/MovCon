using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Interfaces
{
    public interface IMovimentacaoExtern
    {
        Task<MovimentacaoViewModel> Obter(Int64 id);
        Task<MovimentacaoViewModel> Listar();
        Task<MovimentacaoViewModel> Iniciar(MovimentacaoViewModel model);
        Task<MovimentacaoViewModel> Finalizar(MovimentacaoViewModel model);
        Task<MovimentacaoViewModel> Pesquisar(MovimentacaoViewModel model);
    }
}
