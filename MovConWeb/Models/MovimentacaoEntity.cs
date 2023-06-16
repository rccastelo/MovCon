using MovConWeb.Helpers;
using System;

namespace MovConWeb.Models
{
    public class MovimentacaoEntity
    {
        private string _numero;
        private string _tipo;
        private string _tipoConteiner;
        private string _status;
        private string _categoria;

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
        public string TipoConteiner {
            get {
                return (this._tipoConteiner == null) ? "" : this._tipoConteiner;
            }
            set {
                this._tipoConteiner = (value == null) ? "" : value;
            }
        }
        public string TipoConteinerFormatado {
            get {
                return DomainsHelper.ObterTipoConteiner(_tipoConteiner);
            }
        }
        public string Status {
            get {
                return (this._status == null) ? "" : this._status;
            }
            set {
                this._status = (value == null) ? "" : value;
            }
        }
        public string StatusFormatado {
            get {
                return DomainsHelper.ObterStatusConteiner(_status);
            }
        }
        public string Categoria {
            get {
                return (this._categoria == null) ? "" : this._categoria;
            }
            set {
                this._categoria = (value == null) ? "" : value;
            }
        }
        public string CategoriaFormatado {
            get {
                return DomainsHelper.ObterCategoriaConteiner(_categoria);
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
