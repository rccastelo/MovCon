using MovConWeb.Helpers;
using System;

namespace MovConWeb.Models
{
    public class MovimentacaoEntity
    {
        private string _numero;
        private string _tipo;

        public Int64 Id { get; set; }
        public string Numero {
            get {
                return this._numero;
            } 
            set {
                this._numero = (value == null) ? "" : value;
            } 
        }
        public string Tipo {
            get {
                return this._tipo;
            }
            set {
                this._tipo = (value == null) ? "" : value;
            }
        }
        public string TipoFormatado {
            get {
                return DomainsHelper.ObterTipoMovimentacao(_tipo);
            }
        }
        public DateTime DataHoraInicio { get; set; }
        public string DataHoraInicioFormatado {
            get { 
                return (DataHoraInicio != DateTime.MinValue) ? DataHoraInicio.ToString() : ""; 
            }
            set { 
                if (DateTime.TryParse(value, out DateTime _inicio)) 
                    this.DataHoraInicio = _inicio; 
            } 
        }
        public DateTime DataHoraFim { get; set; }
        public string DataHoraFimFormatado {
            get {
                return (DataHoraFim != DateTime.MinValue) ? DataHoraFim.ToString() : "";
            }
            set {
                if (DateTime.TryParse(value, out DateTime _inicio))
                    this.DataHoraFim = _inicio;
            }
        }
        public bool Finalizado {
            get { 
                return (DataHoraFim == DateTime.MinValue) ? false : true;
            }
        }
        public bool Pendente { get; set; }
    }
}
