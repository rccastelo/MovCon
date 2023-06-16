using System;

namespace MovConDomain.Models
{
    public class RelatorioEntity
    {
        public string Cliente { get; set; }
        public string Numero { get; set; }
        public string TipoConteiner { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }
        public string TipoMovimentacao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraInicioAte { get; set; }
        public DateTime DataHoraFim { get; set; }
        public DateTime DataHoraFimAte { get; set; }
        public bool Pendente { get; set; }

        public RelatorioEntity()
        {

        }

        public RelatorioEntity(string cliente, string numero, string tipoConteiner, string status, string categoria, 
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
