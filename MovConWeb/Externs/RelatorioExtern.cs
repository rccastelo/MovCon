using Microsoft.Extensions.Configuration;
using MovConWeb.Interfaces;
using MovConWeb.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovConWeb.Externs
{
    public class RelatorioExtern : IRelatorioExtern
    {
        private string serviceAddress = "https://localhost:5010/";
        private string methodAddress = "Relatorios";
        private HttpClient httpClient = null;

        public RelatorioExtern(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(serviceAddress);
        }

        public async Task<RelatorioViewModel> Pesquisar(RelatorioViewModel model)
        {
            RelatorioViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(model.Filter);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<RelatorioViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Pesquisar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new RelatorioViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                
                movimentacao = new RelatorioViewModel();
                movimentacao.SetError($"Erro em {methodAddress} Pesquisar");
            } finally {
                response = null;
            }

            return movimentacao;
        }
    }
}
