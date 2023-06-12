using System;

namespace MovConWeb.Models
{
    public class MovimentacaoEntity
    {
        private string _numero;
        private string _tipo;
        private DateTime _dataHoraInicio;
        private DateTime _dataHoraFim;

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
        public string DataHoraInicio {
            get { 
                return (_dataHoraInicio != DateTime.MinValue) ? _dataHoraInicio.ToString() : ""; 
            }
            set { 
                if (DateTime.TryParse(value, out DateTime _inicio)) 
                    this._dataHoraInicio = _inicio; 
            } 
        }
        public string DataHoraFim {
            get {
                return (_dataHoraFim != DateTime.MinValue) ? _dataHoraFim.ToString() : "";
            }
            set {
                if (DateTime.TryParse(value, out DateTime _inicio))
                    this._dataHoraFim = _inicio;
            }
        }
    }
}
