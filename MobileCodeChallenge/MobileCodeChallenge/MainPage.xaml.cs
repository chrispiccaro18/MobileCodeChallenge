using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.Models;
using MobileCodeChallenge.Services;
using MobileCodeChallenge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public NotifyTaskCompletion<List<Starship>> Starships { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            /*var starshipManager = new StarshipManager( new RestService());
            Starships = new NotifyTaskCompletion<List<Starship>>(
                starshipManager.GetStarshipsAsync());
            if (Starships.IsSuccessfullyCompleted)
            {
                listView.ItemsSource = Starships.Result;
            }*/
        }
    }
}
