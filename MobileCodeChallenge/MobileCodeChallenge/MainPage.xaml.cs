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

            listView.ItemsSource = new Starship[]
            {
              new Starship() { Name = "AA-9 Coruscant freighter", Starship_Class = "freighter"},
              new Starship() { Name = "arc-170", Starship_Class = "starfighter"},
              new Starship() { Name = "A-wing", Starship_Class = "starfighter"},
            };
        }
    }
}
