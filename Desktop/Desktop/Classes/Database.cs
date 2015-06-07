using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desktop
{
    class Database
    {
        public static async Task<HttpResponseMessage> AddSystem(Systems system)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:43649/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/systems/", system);
                    return response;
                }

                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static async Task<HttpResponseMessage> SaveSystem(Systems system)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:43649/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync("api/systems/put/", system);

                return response;
            }
        }
    }
}
