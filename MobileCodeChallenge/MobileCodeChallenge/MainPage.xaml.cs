using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GetStarships();

            listView.ItemsSource = new Starship[]
            {
              new Starship() { name = "AA-9 Coruscant freighter", starship_class = "freighter"},
              new Starship() { name = "arc-170", starship_class = "starfighter"},
              new Starship() { name = "A-wing", starship_class = "starfighter"},
            };
        }

        public async void GetStarships()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.co/api/starships");
            var result = JsonConvert.DeserializeObject<Result>(response);
            Console.WriteLine(result.starships);
            // listView.ItemsSource = result.starships;
        }
    }
}
