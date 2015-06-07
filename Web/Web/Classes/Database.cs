using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Configuration;

namespace Web
{
    public class Database
    {
        #region Users
            public static async Task<Users> GetUserByUsername(string username)
            {
                using (var client = new HttpClient())
                {
                    Users user = new Users();

                    client.BaseAddress = new Uri("http://elitebackend-001-site1.myasp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //voorzie strings en urls in configfile
                    //voorzie methode voor post en get in utilityclass
                    string url = "api/users/username/" + username;

                    HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        user = await response.Content.ReadAsAsync<Users>();

                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public static async Task<HttpResponseMessage> AddUser(Users user)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://elitebackend-001-site1.myasp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync("api/users/", user);
                        return response;
                    }

                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }

            public static async Task<HttpResponseMessage> SaveUser(Users user)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://elitebackend-001-site1.myasp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/users/put/", user);

                    return response;
                }
            }
        #endregion

        #region Systems
            public static async Task<List<Systems>> GetSystems()
            {
                using (var client = new HttpClient())
                {
                    List<Systems> systems = new List<Systems>();

                    client.BaseAddress = new Uri("http://elitebackend-001-site1.myasp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //voorzie strings en urls in configfile
                    //voorzie methode voor post en get in utilityclass
                    string url = "api/systems";

                    HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        systems = await response.Content.ReadAsAsync<List<Systems>>();

                        return systems;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public static async Task<List<Systems>> GetSystemsByFilter(string name)
            {
                using (var client = new HttpClient())
                {
                    List<Systems> systems = new List<Systems>();

                    client.BaseAddress = new Uri("http://elitebackend-001-site1.myasp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //voorzie strings en urls in configfile
                    //voorzie methode voor post en get in utilityclass
                    string url = "api/systems/filter/" + name;

                    HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        systems = await response.Content.ReadAsAsync<List<Systems>>();

                        return systems;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public static async Task<Systems> GetSystemById(int systemId)
            {
                using (var client = new HttpClient())
                {
                    Systems system = new Systems();

                    client.BaseAddress = new Uri("http://elitebackend-001-site1.myasp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //voorzie strings en urls in configfile
                    //voorzie methode voor post en get in utilityclass
                    string url = "api/systems/" + systemId;

                    HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        system = await response.Content.ReadAsAsync<Systems>();

                        return system;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        #endregion
    }
}