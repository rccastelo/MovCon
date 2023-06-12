using MovConDomain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovConApplication.Transports
{
    public class ConteinerResponse
    {
        public bool IsError { get; private set; }
        public bool IsValid { get; private set; }
        public string Message { get; private set; }
        public ConteinerEntity Item { get; private set; }
        public List<ConteinerEntity> List { get; private set; }

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

        public void SetItem(ConteinerModel model)
        {
            if (model != null) {
                this.Item = new ConteinerEntity() {
                    Id = model.Id,
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
                this.List = list.Select(c => new ConteinerEntity() {
                    Id = c.Id,
                    Cliente = c.Cliente,
                    Numero = c.Numero,
                    Tipo = c.Tipo,
                    Status = c.Status,
                    Categoria = c.Categoria
                }).ToList();
            }
        }

        public void SetList(List<ConteinerEntity> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                this.List = list.Select(c => new ConteinerEntity()
                {
                    Id = c.Id,
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
