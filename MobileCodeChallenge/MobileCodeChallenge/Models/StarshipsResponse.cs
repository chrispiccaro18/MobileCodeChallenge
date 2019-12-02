using System.Collections.Generic;

namespace MobileCodeChallenge.Models
{
    public class StarshipsResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public List<Starship> Results { get; set; }
    }
}
