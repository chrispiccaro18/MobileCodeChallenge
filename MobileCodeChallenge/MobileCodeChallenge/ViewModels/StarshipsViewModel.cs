using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;
using MobileCodeChallenge.Services;
using Xamarin.Forms;

namespace MobileCodeChallenge.ViewModels
{
    public class StarshipsViewModel
    {
        public static StarshipManager starshipManager { get; private set; }
        List<Starship> allStarships
        {
            get { return allStarships;  }
            set
            {
                allStarships = value;
                LoadStarshipsCommand.ChangeCanExecute();
            }
        }
        public Command LoadStarshipsCommand { get; }
        public StarshipsViewModel()
        {
            LoadStarshipsCommand = new Command(async () => await LoadStarships());
        }

        async Task LoadStarships()
        {
            starshipManager = new StarshipManager(new RestService());
            allStarships = await starshipManager.GetStarshipsAsync();
            allStarships.Sort(delegate (Starship x, Starship y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });
        }
    }


}
