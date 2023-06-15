using MovConDomain.Models;
using System.Collections.Generic;

namespace MovConRepository.Interfaces
{
    public interface IRelatorioRepository
    {
        List<RelatorioEntity> Pesquisar(RelatorioEntity entity);
    }
}
