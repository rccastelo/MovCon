using MovConWeb.Models;
using System.Threading.Tasks;

namespace MovConWeb.Interfaces
{
    public interface IRelatorioExtern
    {
        Task<RelatorioViewModel> Pesquisar(RelatorioViewModel model);
    }
}
