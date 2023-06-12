using System;

namespace MovConDomain.Models
{
    public class ConteinerEntity
    {
        public Int64 Id { get; set; }
        public string Cliente { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }

        public ConteinerEntity()
        {
            
        }

        public ConteinerEntity(Int64 id, string cliente, string numero, string tipo, string status, string categoria)
        {
            this.Id = id;
            this.Cliente = cliente;
            this.Numero = numero;
            this.Tipo = tipo;
            this.Status = status;
            this.Categoria = categoria;
        }
    }
}
