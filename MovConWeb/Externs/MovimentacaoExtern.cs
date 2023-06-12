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

        public async Task<MovimentacaoViewModel> Insert(MovimentacaoViewModel transport)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(transport.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Insert";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError("Erro em MovimentacaoModel Insert [" + ex.Message + "]");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Update(MovimentacaoViewModel transport)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(transport.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PutAsync($"{methodAddress}/{transport.Item.Id}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Update";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError("Erro em MovimentacaoModel Insert [" + ex.Message + "]");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Delete(Int64 id)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                response = await httpClient.DeleteAsync($"{methodAddress}/{id}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Delete";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError("Erro em MovimentacaoModel Insert [" + ex.Message + "]");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> List()
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
                    message = $"Não foi possível acessar o serviço {methodAddress} List";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError("Erro em MovimentacaoModel Insert [" + ex.Message + "]");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Get(Int64 id)
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
                    message = $"Não foi possível acessar o serviço {methodAddress} Get";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError("Erro em MovimentacaoModel Insert [" + ex.Message + "]");
            } finally {
                response = null;
            }

            return movimentacao;
        }

        public async Task<MovimentacaoViewModel> Filter(MovimentacaoViewModel transport)
        {
            MovimentacaoViewModel movimentacao = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(transport.Filter);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}/filter", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    movimentacao = JsonConvert.DeserializeObject<MovimentacaoViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Filter";
                }

                if (!string.IsNullOrEmpty(message)) {
                    movimentacao = new MovimentacaoViewModel();
                    movimentacao.SetError(message);
                }
            } catch (Exception ex) {
                movimentacao = new MovimentacaoViewModel();
                movimentacao.SetError("Erro em MovimentacaoModel Insert [" + ex.Message + "]");
            } finally {
                response = null;
            }

            return movimentacao;
        }
    }
}
