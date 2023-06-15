namespace MovConApplication.Transports
{
    public class MovimentacaoFiltroRequest
    {
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public bool Pendente { get; set; }
    }
}
