using System.Collections.ObjectModel;
using MobileCodeChallenge.Models;
using MobileCodeChallenge.Services;
using MobileCodeChallenge.Views;
using Xamarin.Forms;

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
                foreach (var starship in starships)
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
