using System.Collections.Generic;

namespace MovConWeb.Models
{
    public class RelatorioViewModel
    {
        public bool IsValid { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public RelatorioEntity Item { get; set; }
        public RelatorioEntity Filter { get; set; }
        public List<RelatorioEntity> List { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public string SortSelected { get; set; }

        public RelatorioViewModel()
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
