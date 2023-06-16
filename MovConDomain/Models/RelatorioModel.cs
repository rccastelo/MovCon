using System;

namespace MovConDomain.Models
{
    public class RelatorioModel : RelatorioEntity
    {
        public RelatorioModel()
        {

        }

        public RelatorioModel(string cliente, string numero, string tipoConteiner, string status, string categoria,
            string tipoMovimentacao, DateTime dataHoraInicio, DateTime dataHoraInicioAte, DateTime dataHoraFim, 
            DateTime dataHoraFimAte, bool pendente)
        {
            this.Cliente = cliente;
            this.Numero = numero;
            this.TipoConteiner = tipoConteiner;
            this.Status = status;
            this.Categoria = categoria;
            this.TipoMovimentacao = tipoMovimentacao;
            this.DataHoraInicio = dataHoraInicio;
            this.DataHoraInicioAte = dataHoraInicioAte;
            this.DataHoraFim = dataHoraFim;
            this.DataHoraFimAte = dataHoraFimAte;
            this.Pendente = pendente;
        }
    }
}
