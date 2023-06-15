using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;

namespace MovConRepository.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly IRelatorioData _relatorioData;

        public RelatorioRepository(IRelatorioData relatorioData)
        {
            this._relatorioData = relatorioData;
        }

        public List<RelatorioEntity> Pesquisar(RelatorioEntity entity)
        {
            return this._relatorioData.Pesquisar(entity);
        }
    }
}
