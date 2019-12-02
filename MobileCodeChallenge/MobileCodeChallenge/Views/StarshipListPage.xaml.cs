using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCodeChallenge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Starships : ContentPage
    {
        public Starships()
        {
            InitializeComponent();
            BindingContext = new StarshipListViewModel();
        }
    }
}
