using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;
using System.Diagnostics;

namespace MobileCodeChallenge.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public List<Starship> starships { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Starship>> RefreshDataAsync()
        {
            starships = new List<Starship>();
            var uri = new Uri("https://swapi.co/api/starships/?page=1");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsAsync<StarshipsResponse>();
                    starships = content.Results;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return starships;
        }
    }
}
