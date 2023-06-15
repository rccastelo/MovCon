using System;

namespace MovConDomain.Models
{
    public class RelatorioModel : RelatorioEntity
    {
        public RelatorioModel()
        {

        }

        public RelatorioModel(string cliente, string numero, string tipoConteiner, string status, string categoria,
            string tipoMovimentacao, DateTime dataHoraInicio, DateTime dataHoraFim, bool pendente)
        {
            this.Cliente = cliente;
            this.Numero = numero;
            this.TipoConteiner = tipoConteiner;
            this.Status = status;
            this.Categoria = categoria;
            this.TipoMovimentacao = tipoMovimentacao;
            this.DataHoraInicio = dataHoraInicio;
            this.DataHoraFim = dataHoraFim;
            this.Pendente = pendente;
        }
    }
}
