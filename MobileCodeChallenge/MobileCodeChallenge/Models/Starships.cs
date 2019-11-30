using System;
using System.Collections.Generic;

namespace MobileCodeChallenge.Models
{
    class Starships
    {
        public List<Starship> starships { get; set; }

        public List<Starship> SortStarshipsAlphabetically()
        {
            this.starships.Sort(delegate (Starship x, Starship y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });

            return starships;
        }
    }
}
