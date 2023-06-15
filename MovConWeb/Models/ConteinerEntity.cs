using MovConWeb.Helpers;
using System;

namespace MovConWeb.Models
{
    public class ConteinerEntity
    {
        private string _numero;
        private string _cliente;
        private string _tipo;
        private string _status;
        private string _categoria;

        public Int64 Id { get; set; }
        public string Cliente {
            get {
                return this._cliente;
            }
            set {
                this._cliente = (value == null) ? "" : value;
            }
        }
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
                return DomainsHelper.ObterTipoConteiner(_tipo);
            }
        }
        public string Status {
            get {
                return this._status;
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
                return this._categoria;
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
    }
}
