using System;
using System.Collections.Generic;
using System.Text;
using MobileCodeChallenge.Models;

namespace MobileCodeChallenge.ViewModels
{
    public class StarshipViewModel
    {
        public Starship Starship { get; set; }
        public string Title { get; set; }
        public StarshipViewModel(Starship starship = null)
        {
            Title = starship.Name;
            Starship = starship;
        }
    }
}
