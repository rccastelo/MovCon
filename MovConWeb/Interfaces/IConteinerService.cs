using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Interfaces
{
    public interface IConteinerService
    {
        Task<ConteinerViewModel> Pesquisar(ConteinerViewModel model);
        Task<ConteinerViewModel> Obter(Int64 id);
        Task<ConteinerViewModel> Listar();
        Task<ConteinerViewModel> Incluir(ConteinerViewModel model);
        Task<ConteinerViewModel> Alterar(ConteinerViewModel model);
        Task<ConteinerViewModel> Excluir(Int64 id);
    }
}
