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
            try
            {
                var originalStarships = await GetStarshipsAsync(_client);

                int pages = originalStarships.Count / originalStarships.Results.Count;
                if (originalStarships.Count % originalStarships.Results.Count != 0) pages++;

                originalStarships.Results.ForEach(starship => {
                    starships.Add(starship);
                });

                for (int i = 2; i < pages + 1; i++)
                {
                    StarshipsResponse starshipsResponse = await GetStarshipsAsync(_client, i);
                    starshipsResponse.Results.ForEach(starship => {
                        starships.Add(starship);
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return starships;
        }

        public async Task<StarshipsResponse> GetStarshipsAsync(HttpClient client, int page = 1)
        {
            StarshipsResponse starships = null;
            HttpResponseMessage response = await client.GetAsync($"{BaseUri}/?page={page}");
            if (response.IsSuccessStatusCode)
            {
                starships = await response.Content.ReadAsAsync<StarshipsResponse>();
            }
            return starships;
        }
    }
}
