using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

            RunAsync().GetAwaiter().GetResult();

            listView.ItemsSource = new Starship[]
            {
              new Starship() { Name = "AA-9 Coruscant freighter", Starship_Class = "freighter"},
              new Starship() { Name = "arc-170", Starship_Class = "starfighter"},
              new Starship() { Name = "A-wing", Starship_Class = "starfighter"},
            };
        }

        static async Task RunAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = new StarshipsResponse();
                var httpResponse = await client.GetAsync("https://swapi.co/api/starships");
                if (httpResponse.IsSuccessStatusCode)
                {
                    response = await httpResponse.Content.ReadAsAsync<StarshipsResponse>();
                }
                response.Results.ForEach(starship => Console.WriteLine(starship.Name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
