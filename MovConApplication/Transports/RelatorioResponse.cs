using MovConDomain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovConApplication.Transports
{
    public class RelatorioResponse
    {
        public bool IsError { get; private set; }
        public bool IsValid { get; private set; }
        public string Message { get; private set; }
        public RelatorioEntity Item { get; private set; }
        public List<RelatorioEntity> List { get; private set; }

        public void SetError(string message)
        {
            this.IsValid = false;
            this.IsError = true;
            this.Message = message;
        }

        public void SetValid(bool valid)
        {
            this.IsValid = valid;
        }

        public void SetMessage(string message)
        {
            this.Message = message;
        }

        public void SetItem(RelatorioModel model)
        {
            if (model != null) {
                this.Item = new RelatorioEntity() {
                    Cliente = model.Cliente,
                    Numero = model.Numero,
                    TipoConteiner = model.TipoConteiner,
                    Status = model.Status,
                    Categoria = model.Categoria,
                    TipoMovimentacao = model.TipoMovimentacao,
                    DataHoraInicio = model.DataHoraInicio,
                    DataHoraFim = model.DataHoraFim
                };
            }
        }

        public void SetList(List<RelatorioModel> list)
        {
            if ((list != null) && (list.Count > 0)) {
                this.List = list.Select(c => new RelatorioEntity() {
                    Cliente = c.Cliente,
                    Numero = c.Numero,
                    TipoConteiner = c.TipoConteiner,
                    Status = c.Status,
                    Categoria = c.Categoria,
                    TipoMovimentacao = c.TipoMovimentacao,
                    DataHoraInicio = c.DataHoraInicio,
                    DataHoraFim = c.DataHoraFim
                }).ToList();
            }
        }

        public void SetList(List<RelatorioEntity> list)
        {
            if ((list != null) && (list.Count > 0)) {
                this.List = list.Select(c => new RelatorioEntity() {
                    Cliente = c.Cliente,
                    Numero = c.Numero,
                    TipoConteiner = c.TipoConteiner,
                    Status = c.Status,
                    Categoria = c.Categoria,
                    TipoMovimentacao = c.TipoMovimentacao,
                    DataHoraInicio = c.DataHoraInicio,
                    DataHoraFim = c.DataHoraFim
                }).ToList();
            }
        }
    }
}
