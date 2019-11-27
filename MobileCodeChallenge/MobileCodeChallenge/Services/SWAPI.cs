using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MobileCodeChallenge.Models;
using Newtonsoft.Json;

namespace MobileCodeChallenge.Services
{
    public class SWAPI
    {
        HttpClient client;

        public async void GetStarships()
        {
            client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.co/api/starships");
            var starships = JsonConvert.DeserializeObject<List<Starship>>(response);
        }
    }
}
