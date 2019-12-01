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
            listView.ItemsSource = await App.starshipManager.GetStarshipsAsync();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new StarshipPage
            {
                BindingContext = e.SelectedItem as Starship
            });
        }
    }
}
