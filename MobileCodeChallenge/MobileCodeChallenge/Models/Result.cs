using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCodeChallenge.Models
{
    public class Result
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Starship> starships { get; set; }
    }
}
