using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GestionInterLigas.entities;

namespace GestionInterLigas
{
    public class ApiService
    {
        private readonly string baseUrl;

        public ApiService(string baseUrl)
        {
            this.baseUrl = baseUrl.TrimEnd('/');
        }

        public async Task<List<Partido>> GetPartidos(string phpFile, Dictionary<string, string> parametros = null)
        {
            return await HttpGets<List<Partido>>(phpFile, parametros);
        }
        
        public async Task<bool> UpdateMatch(string phpFile, List<Partido> partidos)
        {
            return await HttpUpdates(phpFile, partidos);
        }
         

        private async Task<T> HttpGets<T>(string phpFile, Dictionary<string, string> parametros = null)
        {
            string apiUrl = ConstructApiUrl(phpFile, parametros);
            T result = default(T);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<T>(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine($"Error al realizar la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar la solicitud: {ex.Message}");
            }

            return result;
        }

        private async Task<bool> HttpUpdates(string phpFile, object data)
        {
            string apiUrl = ConstructApiUrl(phpFile);
            bool success = false;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    Console.WriteLine("Solicitud HTTP:");
                    Console.WriteLine(jsonData);

                    if (response.IsSuccessStatusCode)
                    {
                        // La solicitud fue exitosa, actualización exitosa
                        success = true;
                        Console.WriteLine(response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine($"Error al realizar la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar la solicitud: {ex.Message}");
            }

            return success;
        }

        private string ConstructApiUrl(string phpFile, Dictionary<string, string> parametros = null)
        {
            StringBuilder apiUrlBuilder = new StringBuilder($"{baseUrl}/apis/gestion/{phpFile}");

            if (parametros != null && parametros.Count > 0)
            {
                apiUrlBuilder.Append("?");
                foreach (var parametro in parametros)
                {
                    apiUrlBuilder.Append($"{parametro.Key}={parametro.Value}&");
                }
                apiUrlBuilder.Length--;
            }
            return apiUrlBuilder.ToString();
        }
    }

}
