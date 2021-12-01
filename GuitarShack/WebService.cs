using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace GuitarShack
{
    public class WebService<T>
    {
        private readonly string _baseUrl;

        public WebService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public T Fetch(Dictionary<string, string> queryParams)
        {
            string queryString = "?";

            foreach (var key in queryParams.Keys)
            {
                queryString += key + "=" + queryParams[key] + "&";
            }

            HttpClient client = new HttpClient();

            var task = client.GetAsync(
                _baseUrl + queryString);
            var response = task.Result;
            var json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions());
        }
    }
}