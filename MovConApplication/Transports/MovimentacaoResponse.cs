using MovConDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovConApplication.Transports
{
    public class MovimentacaoResponse
    {
        public bool Status { get; private set; }
        public string Message { get; private set; }
        public MovimentacaoTransport Item { get; private set; }
        public List<MovimentacaoTransport> List { get; private set; }

        public void SetStatus(bool status)
        {
            this.Status = status;
        }

        public void SetMessage(string message)
        {
            this.Message = message;
        }

        public void SetItem(MovimentacaoModel model)
        {
            if (model != null) {
                this.Item = new MovimentacaoTransport() {
                    Id = model.Id.ToString(),
                    Numero = model.Numero,
                    Tipo = model.Tipo,
                    DataHoraInicio = (model.DataHoraInicio.Equals(DateTime.MinValue)) ? "" : model.DataHoraInicio.ToString(),
                    DataHoraFim = (model.DataHoraFim.Equals(DateTime.MinValue)) ? "" : model.DataHoraFim.ToString(),
                };
            }
        }

        public void SetList(List<MovimentacaoModel> list)
        {
            if ((list != null) && (list.Count > 0)) {
                this.List = list.Select(c => new MovimentacaoTransport() {
                    Id = c.Id.ToString(),
                    Numero = c.Numero,
                    Tipo = c.Tipo,
                    DataHoraInicio = (c.DataHoraInicio.Equals(DateTime.MinValue)) ? "" : c.DataHoraInicio.ToString(),
                    DataHoraFim = (c.DataHoraFim.Equals(DateTime.MinValue)) ? "" : c.DataHoraFim.ToString(),
                }).ToList();
            }
        }
    }
}
