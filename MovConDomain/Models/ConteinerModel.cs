using MovConDomain.Enums;
using System;
using System.Text.RegularExpressions;

namespace MovConDomain.Models
{
    public class ConteinerModel : ConteinerEntity
    {
        public ConteinerModel(string id, string cliente, string numero, string tipo, string status, string categoria)
        {
            ValidateAndSet(id, cliente, numero, tipo, status, categoria);
        }

        public ConteinerModel(string cliente, string numero, string tipo, string status, string categoria)
        {
            ValidateAndSet(cliente, numero, tipo, status, categoria);
        }

        public ConteinerModel(Int64 id, string cliente, string numero, string tipo, string status, string categoria)
        {
            ValidateAndSet(cliente, numero, tipo, status, categoria);

            this.Id = id;
        }

        private void ValidateAndSet(string id, string cliente, string numero, string tipo, string status, string categoria)
        {
            if (!Int64.TryParse(id, out Int64 _id))
                throw new ArgumentException("Id inválido", "id");

            ValidateAndSet(cliente, numero, tipo, status, categoria);

            this.Id = _id;
        }

        private void ValidateAndSet(string cliente, string numero, string tipo, string status, string categoria) 
        {
            if (string.IsNullOrWhiteSpace(cliente))
                throw new ArgumentException("Cliente deve ser informado", "cliente");

            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Número deve ser informado", "numero");

            if (!Regex.IsMatch(numero, "^[A-Za-z]{4}[0-9]{7}$"))
                throw new ArgumentException("Número deve estar no formato AAAA9999999", "numero");

            if (!ConteinerTipoEnum.Validate(tipo))
                throw new ArgumentException("Tipo inválido", "tipo");

            if (!ConteinerStatusEnum.Validate(status))
                throw new ArgumentException("Status inválido", "status");

            if (!ConteinerCategoriaEnum.Validate(categoria))
                throw new ArgumentException("Categoria inválida", "categoria");

            this.Cliente = cliente;
            this.Numero = numero;
            this.Tipo = tipo;
            this.Status = status;
            this.Categoria = categoria;
        }
    }
}
