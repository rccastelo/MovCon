using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Interfaces
{
    public interface IMovimentacaoService
    {
        Task<MovimentacaoViewModel> Search(MovimentacaoViewModel transport);
        Task<MovimentacaoViewModel> Get(Int64 id);
        Task<MovimentacaoViewModel> List();
        Task<MovimentacaoViewModel> Insert(MovimentacaoViewModel transport);
        Task<MovimentacaoViewModel> Update(MovimentacaoViewModel transport);
        Task<MovimentacaoViewModel> Delete(Int64 id);
    }
}
