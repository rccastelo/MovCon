using MovConApplication.Interfaces;
using MovConApplication.Transports;
using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;

namespace MovConApplication.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            this._relatorioRepository = relatorioRepository;
        }

        public RelatorioResponse Pesquisar(RelatorioRequest request)
        {
            RelatorioEntity entity = new RelatorioEntity(
                request.Cliente, request.Numero, request.TipoConteiner, request.Status, request.Categoria,
                request.TipoMovimentacao, request.DataHoraInicio, request.DataHoraInicioAte, request.DataHoraFim, 
                request.DataHoraFimAte, request.Pendente);

            List<RelatorioEntity> list = this._relatorioRepository.Pesquisar(entity);

            RelatorioResponse response = new RelatorioResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetValid(true);
                response.SetList(list);
            } else {
                response.SetValid(false);
                response.SetMessage("Nenhuma informação encontrada");
            }

            return response;
        }
    }
}
