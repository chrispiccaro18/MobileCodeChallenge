using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;

namespace MobileCodeChallenge.Services
{
    public class SWApi
    {
        private static string BaseUri { get; set; } = "https://swapi.co/api/starships";
        public async Task<Starship> GetStarshipAsync(HttpClient client, int starshipNumber)
        {
            Starship starship = null;
            HttpResponseMessage response = await client.GetAsync($"{BaseUri}/{starshipNumber}");
            if (response.IsSuccessStatusCode)
            {
                starship = await response.Content.ReadAsAsync<Starship>();
            }
            return starship;
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

        public async Task<List<Starship>> GetAllStarshipsAsync(HttpClient client)
        {
            List<Starship> allStarships = new List<Starship>();

            StarshipsResponse originalStarships = await GetStarshipsAsync(client);

            int pages = originalStarships.Count / originalStarships.Results.Count;
            if (originalStarships.Count % originalStarships.Results.Count != 0) pages++;

            originalStarships.Results.ForEach(starship => {
                allStarships.Add(starship);
            });

            for (int i = 2; i < pages + 1; i++)
            {
                StarshipsResponse starships = await GetStarshipsAsync(client, i);
                starships.Results.ForEach(starship => {
                    allStarships.Add(starship);
                });
            }

            return allStarships;
        }
    }
}
