using System;

namespace MovConApplication.Transports
{
    public class ConteinerRequest
    {
        public Int64 Id { get; set; }
        public string Cliente { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }
    }
}
