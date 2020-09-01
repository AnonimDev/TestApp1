using System.Net.Http;
using System.Net.Http.Headers;
using TestApp1.Models;

namespace ConsoleClient
{
    class ClientApi
    {
        private const string APP_PATH = "https://localhost:44352/";

        private HttpClient _client = new HttpClient();

        public string Delete(int id)
        {
            var response = _client.DeleteAsync(APP_PATH + "api/Person/" + id).Result;

            return response.StatusCode.ToString();
        }

        public string Select(int id)
        {
            return _client.GetStringAsync(APP_PATH + "api/Person" + ((id != 0) ? "/" + id : "")).Result;
        }

        public string Create(Person model)
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = _client.PostAsJsonAsync(APP_PATH + "api/Person", model).Result;

            return response.StatusCode.ToString();
        }

    }
}
