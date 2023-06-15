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
    public class ConteinerExtern : IConteinerExtern
    {
        private string serviceAddress = "https://localhost:5010/";
        private string methodAddress = "Conteineres";
        private HttpClient httpClient = null;

        public ConteinerExtern(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(serviceAddress);
        }

        public async Task<ConteinerViewModel> Incluir(ConteinerViewModel model)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(model.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Incluir";
                }

                if (!string.IsNullOrEmpty(message)) {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                conteiner = new ConteinerViewModel();
                conteiner.SetError($"Erro em {methodAddress} Incluir");
            } finally {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Alterar(ConteinerViewModel model)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(model.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PutAsync($"{methodAddress}/{model.Item.Id}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Alterar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                conteiner = new ConteinerViewModel();
                conteiner.SetError($"Erro em {methodAddress} Alterar");
            } finally {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Excluir(Int64 id)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                response = await httpClient.DeleteAsync($"{methodAddress}/{id}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Excluir";
                }

                if (!string.IsNullOrEmpty(message)) {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                conteiner = new ConteinerViewModel();
                conteiner.SetError($"Erro em {methodAddress} Excluir");
            } finally {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Listar()
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                response = await httpClient.GetAsync($"{methodAddress}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Listar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                conteiner = new ConteinerViewModel();
                conteiner.SetError($"Erro em {methodAddress} Listar");
            } finally {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Obter(Int64 id)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                response = await httpClient.GetAsync($"{methodAddress}/{id}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Obter";
                }

                if (!string.IsNullOrEmpty(message)) {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                conteiner = new ConteinerViewModel();
                conteiner.SetError($"Erro em {methodAddress} Obter");
            } finally {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Pesquisar(ConteinerViewModel model)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(model.Filter);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}/filtrar", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest)) {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Pesquisar";
                }

                if (!string.IsNullOrEmpty(message)) {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);

                conteiner = new ConteinerViewModel();
                conteiner.SetError($"Erro em {methodAddress} Pesquisar");
            } finally {
                response = null;
            }

            return conteiner;
        }
    }
}
