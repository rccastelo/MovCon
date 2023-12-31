﻿using System;

namespace MovConDomain.Models
{
    public class MovimentacaoEntity
    {
        public Int64 Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public string TipoConteiner { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public bool Pendente { get; set; }

        public MovimentacaoEntity()
        {

        }

        public MovimentacaoEntity(string numero, string tipo, bool pendente)
        {
            this.Numero = numero;
            this.Tipo = tipo;
            this.Pendente = pendente;
        }

        public MovimentacaoEntity(Int64 id, string numero, string tipo, DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            this.Id = id;
            this.Numero = numero;
            this.Tipo = tipo;
            this.DataHoraInicio = dataHoraInicio;
            this.DataHoraFim = dataHoraFim;
        }
    }
}
