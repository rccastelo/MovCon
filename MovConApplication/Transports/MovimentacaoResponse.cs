using MovConDomain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovConApplication.Transports
{
    public class MovimentacaoResponse
    {
        public bool IsError { get; private set; }
        public bool IsValid { get; private set; }
        public string Message { get; private set; }
        public MovimentacaoEntity Item { get; private set; }
        public List<MovimentacaoEntity> List { get; private set; }

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

        public void SetItem(MovimentacaoModel model)
        {
            if (model != null) {
                this.Item = new MovimentacaoEntity() {
                    Id = model.Id,
                    Numero = model.Numero,
                    Tipo = model.Tipo,
                    TipoConteiner = model.TipoConteiner,
                    Status = model.Status,
                    Categoria = model.Categoria,
                    DataHoraInicio = model.DataHoraInicio,
                    DataHoraFim = model.DataHoraFim
                };
            }
        }

        public void SetList(List<MovimentacaoModel> list)
        {
            if ((list != null) && (list.Count > 0)) {
                this.List = list.Select(c => new MovimentacaoEntity() {
                    Id = c.Id,
                    Numero = c.Numero,
                    Tipo = c.Tipo,
                    TipoConteiner = c.TipoConteiner,
                    Status = c.Status,
                    Categoria = c.Categoria,
                    DataHoraInicio = c.DataHoraInicio,
                    DataHoraFim = c.DataHoraFim
                }).ToList();
            }
        }

        public void SetList(List<MovimentacaoEntity> list)
        {
            if ((list != null) && (list.Count > 0)) {
                this.List = list.Select(c => new MovimentacaoEntity() {
                    Id = c.Id,
                    Numero = c.Numero,
                    Tipo = c.Tipo,
                    TipoConteiner = c.TipoConteiner,
                    Status = c.Status,
                    Categoria = c.Categoria,
                    DataHoraInicio = c.DataHoraInicio,
                    DataHoraFim = c.DataHoraFim
                }).ToList();
            }
        }
    }
}
