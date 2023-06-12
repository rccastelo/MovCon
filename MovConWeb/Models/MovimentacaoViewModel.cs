using System.Collections.Generic;

namespace MovConWeb.Models
{
    public class MovimentacaoViewModel
    {
        public bool IsValid { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public MovimentacaoEntity Item { get; set; }
        public MovimentacaoEntity Filter { get; set; }
        public List<MovimentacaoEntity> List { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public string SortSelected { get; set; }

        public MovimentacaoViewModel()
        {
            this.IsError = false;
            this.IsValid = true;
        }

        public void SetError(string message)
        {
            this.IsValid = false;
            this.IsError = true;

            if (!string.IsNullOrWhiteSpace(message)) {
                this.Message = message;
            }
        }
    }
}
