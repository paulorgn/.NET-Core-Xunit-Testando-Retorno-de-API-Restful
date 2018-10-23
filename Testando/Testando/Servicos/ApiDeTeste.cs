using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Testando.DTOs;
using Newtonsoft.Json;

namespace Testando.Servicos
{
    public class ApiDeTeste
    {
        public HttpClient IniciarCliente()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                cliente.Timeout = new TimeSpan(12000000);
                cliente.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HttpResponseMessage ClienteChamarAAPI()
        {
            try
            {
                HttpClient cliente = IniciarCliente();

                HttpResponseMessage resposta;
                resposta = cliente.GetAsync("/todos/1").Result;

                return resposta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DtoRetornoDaAPI PegarRetornoDaAPI()
        {
            try
            {
                HttpResponseMessage resposta = ClienteChamarAAPI();

                if (resposta.IsSuccessStatusCode)
                {
                    string stringRetornoDaApi = resposta.Content.ReadAsStringAsync().Result.ToString();
                    DtoRetornoDaAPI retornoDaAPI = JsonConvert.DeserializeObject<DtoRetornoDaAPI>(stringRetornoDaApi);

                    return retornoDaAPI;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
