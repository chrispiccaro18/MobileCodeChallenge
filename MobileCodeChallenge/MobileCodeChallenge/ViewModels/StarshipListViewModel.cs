using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;
using MobileCodeChallenge.Services;
using MobileCodeChallenge.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge.ViewModels
{
    public class StarshipListViewModel 
    {
        private ObservableCollection<Starship> starships;
        public ObservableCollection<Starship> Starships
        {
            get { return starships; }
            set
            {
                starships = value;
            }
        }

        public StarshipListViewModel()
        {
            Starships = new ObservableCollection<Starship>();
            SWApi.GetStarshipsAsync(starships =>
            {
                foreach (Starship starship in starships)
                    Starships.Add(starship);
            });
        }

        private Starship selectedStarship;
        public Starship SelectedStarship
        {
            get { return selectedStarship; }
            set
            {
                if (value == selectedStarship)
                    return;
                selectedStarship = value;
                Application.Current.MainPage.Navigation.PushAsync(new StarshipPage(new StarshipViewModel(selectedStarship)));
            }
        }
    }
}
