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
