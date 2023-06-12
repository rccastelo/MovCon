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

        public async Task<ConteinerViewModel> Insert(ConteinerViewModel transport)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try {
                string jsonRequest = JsonConvert.SerializeObject(transport.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}", content);

                if ((response.IsSuccessStatusCode) || 
                    (response.StatusCode == HttpStatusCode.BadRequest)) {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                } else {
                    message = $"Não foi possível acessar o serviço {methodAddress} Insert";
                }

                if (!string.IsNullOrEmpty(message)) {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            } catch (Exception ex) {
                conteiner = new ConteinerViewModel();
                conteiner.SetError("Erro em ConteinerModel Insert [" + ex.Message + "]");
            } finally {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Update(ConteinerViewModel transport)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try
            {
                string jsonRequest = JsonConvert.SerializeObject(transport.Item);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PutAsync($"{methodAddress}/{transport.Item.Id}", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest))
                {

                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                }
                else
                {
                    message = $"Não foi possível acessar o serviço {methodAddress} Update";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            }
            catch (Exception ex)
            {
                conteiner = new ConteinerViewModel();
                conteiner.SetError("Erro em ConteinerModel Insert [" + ex.Message + "]");
            }
            finally
            {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Delete(Int64 id)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try
            {
                response = await httpClient.DeleteAsync($"{methodAddress}/{id}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest))
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                }
                else
                {
                    message = $"Não foi possível acessar o serviço {methodAddress} Delete";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            }
            catch (Exception ex)
            {
                conteiner = new ConteinerViewModel();
                conteiner.SetError("Erro em ConteinerModel Insert [" + ex.Message + "]");
            }
            finally
            {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> List()
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try
            {
                response = await httpClient.GetAsync($"{methodAddress}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest))
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                }
                else
                {
                    message = $"Não foi possível acessar o serviço {methodAddress} List";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            }
            catch (Exception ex)
            {
                conteiner = new ConteinerViewModel();
                conteiner.SetError("Erro em ConteinerModel Insert [" + ex.Message + "]");
            }
            finally
            {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Get(Int64 id)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try
            {
                response = await httpClient.GetAsync($"{methodAddress}/{id}");

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest))
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                }
                else
                {
                    message = $"Não foi possível acessar o serviço {methodAddress} Get";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            }
            catch (Exception ex)
            {
                conteiner = new ConteinerViewModel();
                conteiner.SetError("Erro em ConteinerModel Insert [" + ex.Message + "]");
            }
            finally
            {
                response = null;
            }

            return conteiner;
        }

        public async Task<ConteinerViewModel> Filter(ConteinerViewModel transport)
        {
            ConteinerViewModel conteiner = null;
            HttpResponseMessage response = null;
            string message = null;

            try
            {
                string jsonRequest = JsonConvert.SerializeObject(transport.Filter);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync($"{methodAddress}/filter", content);

                if ((response.IsSuccessStatusCode) ||
                    (response.StatusCode == HttpStatusCode.BadRequest))
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    conteiner = JsonConvert.DeserializeObject<ConteinerViewModel>(jsonResult);
                }
                else
                {
                    message = $"Não foi possível acessar o serviço {methodAddress} Filter";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    conteiner = new ConteinerViewModel();
                    conteiner.SetError(message);
                }
            }
            catch (Exception ex)
            {
                conteiner = new ConteinerViewModel();
                conteiner.SetError("Erro em ConteinerModel Insert [" + ex.Message + "]");
            }
            finally
            {
                response = null;
            }

            return conteiner;
        }
    }
}
