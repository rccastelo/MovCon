using MovConDomain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovConApplication.Transports
{
    public class ConteinerResponse
    {
        public bool Status { get; private set; }
        public string Message { get; private set; }
        public ConteinerRequest Item { get; private set; }
        public List<ConteinerRequest> List { get; private set; }

        public void SetStatus(bool status)
        {
            this.Status = status;
        }

        public void SetMessage(string message)
        {
            this.Message = message;
        }

        public void SetItem(ConteinerModel model)
        {
            if (model != null) {
                this.Item = new ConteinerRequest() {
                    Id = model.Id.ToString(),
                    Cliente = model.Cliente,
                    Numero = model.Numero,
                    Tipo = model.Tipo,
                    Status = model.Status,
                    Categoria = model.Categoria
                };
            }
        }

        public void SetList(List<ConteinerModel> list)
        {
            if ((list != null) && (list.Count > 0)) {
                this.List = list.Select(c => new ConteinerRequest() {
                    Id = c.Id.ToString(),
                    Cliente = c.Cliente,
                    Numero = c.Numero,
                    Tipo = c.Tipo,
                    Status = c.Status,
                    Categoria = c.Categoria
                }).ToList();
            }
        }
    }
}
