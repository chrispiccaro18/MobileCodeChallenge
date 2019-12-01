using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;
using MobileCodeChallenge.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarshipPage : ContentPage
    {
        public Starship thisStarship { get; set; }
        public StarshipPage(Starship starship)
        {
            thisStarship = starship;
            InitializeComponent();
            Console.WriteLine(starship.Name);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            StarshipImageService imageService = new StarshipImageService();
            string starshipImageUrl = await imageService.GetImageUrl(thisStarship.Name);
            thisStarship.ImageUrl = starshipImageUrl;
            starshipImage.Source = new UriImageSource()
            {
                Uri = new Uri(starshipImageUrl),
                CachingEnabled = false
            };
            BindingContext = thisStarship;
        }
    }
}
