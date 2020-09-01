using System.Net.Http;
using System.Net.Http.Headers;
using TestApp1.Models;
using System.Collections;
using System;

namespace ConsoleClient
{
    class ClientApi
    {
        private const string APP_PATH = "https://localhost:44352/";

        private HttpClient _client = new HttpClient();

        public string SelectId(int id)
        {
            return _client.GetStringAsync(APP_PATH + "api/Person" + ((id != 0) ? "/" + id : "")).Result;
        }

        public string SelectFilter(Hashtable filters)
        {
            string filterString = "";
            ICollection keys = filters.Keys;
            foreach (string key in keys)
            {
                filterString += key + "=" + filters[key] + "&";
            }

            return _client.GetStringAsync(APP_PATH + "api/Person?" + filterString).Result;
        }

        public string Create(Person model)
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = _client.PostAsJsonAsync(APP_PATH + "api/Person", model).Result;

            return response.StatusCode.ToString();
        }

        public string Delete(int id)
        {
            var response = _client.DeleteAsync(APP_PATH + "api/Person/" + id).Result;

            return response.StatusCode.ToString();
        }
    }
}
