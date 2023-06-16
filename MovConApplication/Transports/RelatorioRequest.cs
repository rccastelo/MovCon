using System;

namespace MovConApplication.Transports
{
    public class RelatorioRequest
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
    }
}
