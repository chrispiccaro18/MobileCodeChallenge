using System.Collections.Generic;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;

namespace MobileCodeChallenge.Services
{
    public class StarshipManager
    {
        IRestService restService;

        public StarshipManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Starship>> GetStarshipsAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
