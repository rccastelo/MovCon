using MovConWeb.Models;
using System.Threading.Tasks;

namespace MovConWeb.Interfaces
{
    public interface IRelatorioService
    {
        Task<RelatorioViewModel> Pesquisar(RelatorioViewModel model);
    }
}
