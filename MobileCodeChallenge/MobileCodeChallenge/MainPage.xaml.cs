using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;
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
              new Starship() { Name = "AA-9 Coruscant freighter", StarshipClass = "freighter"},
              new Starship() { Name = "arc-170", StarshipClass = "starfighter"},
              new Starship() { Name = "A-wing", StarshipClass = "starfighter"},
            };
        }
    }
}
