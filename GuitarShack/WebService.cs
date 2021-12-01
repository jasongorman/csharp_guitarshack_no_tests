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
            var queryString = new QueryStringBuilder(queryParams).Build();

            HttpClient client = new HttpClient();

            var task = client.GetAsync(
                _baseUrl + queryString);
            var response = task.Result;
            var json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions());
        }
    }
}