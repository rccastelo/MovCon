using MovConDomain.Models;
using System.Collections.Generic;

namespace MovConRepository.Interfaces
{
    public interface IRelatorioData
    {
        List<RelatorioEntity> Pesquisar(RelatorioEntity entity);
    }
}
