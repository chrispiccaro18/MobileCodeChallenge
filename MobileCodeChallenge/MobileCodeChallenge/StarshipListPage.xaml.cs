using System;
using MobileCodeChallenge.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarshipListPage : ContentPage
    {
        public StarshipListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var rawStarships = await App.starshipManager.GetStarshipsAsync();
            var starships = new Starships();
            starships.starships = rawStarships;
            listView.ItemsSource = starships.SortStarshipsAlphabetically();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var starship = e.SelectedItem as Starship;
            await Navigation.PushAsync(new StarshipPage(starship));
        }
    }
}
