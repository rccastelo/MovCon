using MovConDomain.Enums;
using System;
using System.Text.RegularExpressions;

namespace MovConDomain.Models
{
    public class MovimentacaoModel : MovimentacaoEntity
    {
        public MovimentacaoModel(string numero)
        {
            ValidarFimPorNumero(numero);
        }

        public MovimentacaoModel(string numero, string tipo)
        {
            ValidarInicio(numero, tipo);
        }

        public MovimentacaoModel(Int64 id, string numero)
        {
            ValidarFim(id, numero);
        }

        public MovimentacaoModel(Int64 id, string numero, string tipo, DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            this.Id = id;
            this.Numero = numero;
            this.Tipo = tipo;
            this.DataHoraInicio = dataHoraInicio;
            this.DataHoraFim = dataHoraFim;
        }

        private void ValidarInicio(string numero, string tipo)
        {
            if (!Regex.IsMatch(numero, "^[A-Za-z]{4}[0-9]{7}$"))
                throw new ArgumentException("Número inválido", "numero");

            if (!MovimentacaoTipoEnum.Validate(tipo))
                throw new ArgumentException("Tipo inválido", "tipo");

            this.Numero = numero;
            this.Tipo = tipo;
        }

        private void ValidarFim(Int64 id, string numero)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido", "id");

            if (!Regex.IsMatch(numero, "^[A-Za-z]{4}[0-9]{7}$"))
                throw new ArgumentException("Número inválido", "numero");

            this.Id = id;
            this.Numero = numero;
        }

        private void ValidarFimPorNumero(string numero)
        {
            if (!Regex.IsMatch(numero, "^[A-Za-z]{4}[0-9]{7}$"))
                throw new ArgumentException("Número inválido", "numero");

            this.Numero = numero;
        }
    }
}
