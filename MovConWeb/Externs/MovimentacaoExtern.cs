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
    public class MovimentacaoExtern : IMovimentacaoExtern
    {
        private string serviceAddress = "https://localhost:5010/";
        private string methodAddress = "Movimentacoes";
        private HttpClient httpClient = null;

        public MovimentacaoExtern(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(serviceAddress);
        }

        public async Task<MovimentacaoViewModel> Iniciar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(model.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Iniciar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError($"Erro em {methodAddress} Iniciar");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Finalizar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(model.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PutAsync($"{methodAddress}/{model.Item.Id}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Finalizar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError($"Erro em {methodAddress} Finalizar");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Listar()
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                response = await httpClient.GetAsync($"{methodAddress}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Listar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError($"Erro em {methodAddress} Listar");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Obter(Int64 id)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                response = await httpClient.GetAsync($"{methodAddress}/{id}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Obter";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError($"Erro em {methodAddress} Obter");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Pesquisar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(model.Filter);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}/filtrar", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Pesquisar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError($"Erro em {methodAddress} Pesquisar");
            } finally {
                response = null;
            }

            return movimentacao;
        }
    }
}
