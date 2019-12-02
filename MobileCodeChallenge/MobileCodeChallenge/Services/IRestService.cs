using System.Collections.Generic;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;

namespace MobileCodeChallenge.Services
{
    public interface IRestService
    {
        Task<List<Starship>> RefreshDataAsync();
    }
}
