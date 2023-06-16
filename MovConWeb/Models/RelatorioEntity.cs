using MovConWeb.Helpers;
using System;

namespace MovConWeb.Models
{
    public class RelatorioEntity
    {
        private string _numero;
        private string _cliente;
        private string _tipoMovimentacao;
        private string _tipoConteiner;
        private string _status;
        private string _categoria;

        public string Cliente {
            get {
                return (this._cliente == null) ? "" : this._cliente;
            }
            set {
                this._cliente = (value == null) ? "" : value;
            }
        }
        public string TipoMovimentacao {
            get {
                return (this._tipoMovimentacao == null) ? "" : this._tipoMovimentacao;
            }
            set {
                this._tipoMovimentacao = (value == null) ? "" : value;
            }
        }
        public string TipoMovimentacaoFormatado {
            get {
                return DomainsHelper.ObterTipoMovimentacao(_tipoMovimentacao);
            }
        }
        public string Numero {
            get {
                return (this._numero == null) ? "" : this._numero;
            }
            set {
                this._numero = (value == null) ? "" : value;
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
        public DateTime DataHoraInicioAte { get; set; }
        public string DataHoraInicioAteFormatado {
            get {
                return (DataHoraInicioAte != DateTime.MinValue) ? DataHoraInicioAte.ToString() : "";
            }
            set {
                if (DateTime.TryParse(value, out DateTime _inicioAte))
                    this.DataHoraInicioAte = _inicioAte;
            }
        }
        public DateTime DataHoraFim { get; set; }
        public string DataHoraFimFormatado {
            get {
                return (DataHoraFim != DateTime.MinValue) ? DataHoraFim.ToString() : "";
            }
            set {
                if (DateTime.TryParse(value, out DateTime _fim))
                    this.DataHoraFim = _fim;
            }
        }
        public DateTime DataHoraFimAte { get; set; }
        public string DataHoraFimAteFormatado {
            get {
                return (DataHoraFimAte != DateTime.MinValue) ? DataHoraFimAte.ToString() : "";
            }
            set {
                if (DateTime.TryParse(value, out DateTime _fimAte))
                    this.DataHoraFimAte = _fimAte;
            }
        }
        public bool Pendente { get; set; }
    }
}
