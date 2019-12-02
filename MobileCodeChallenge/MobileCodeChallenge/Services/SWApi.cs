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
        public static async Task GetStarshipsAsync(Action<IEnumerable<Starship>> action)
        {
            var client = new HttpClient();
            var allstarships = new List<Starship>();

            var firstPageStarships = await GetStarshipsByPageAsync(client);

            int pages = firstPageStarships.Count / firstPageStarships.Results.Count;
            if (firstPageStarships.Count % firstPageStarships.Results.Count != 0) pages++;

            firstPageStarships.Results.ForEach(starship =>
            {
                allstarships.Add(starship);
            });

            for (int i = 2; i < pages + 1; i++)
            {
                var starshipsResponse = await GetStarshipsByPageAsync(client, i);
                starshipsResponse.Results.ForEach(starship => {
                    allstarships.Add(starship);
                });
            }

            // this should probably be in the view model
            // but not sure how
            allstarships.Sort(delegate (Starship x, Starship y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });

            action(allstarships);
        }
        public static async Task<StarshipsResponse> GetStarshipsByPageAsync(HttpClient client, int page = 1)
        {
            StarshipsResponse starships = null;
            var response = await client.GetAsync($"{BaseUri}/?page={page}");

            if (response.IsSuccessStatusCode)
            {
                starships = await response.Content.ReadAsAsync<StarshipsResponse>();
            }
            return starships;
        }
    }
}
