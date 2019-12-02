using MobileCodeChallenge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCodeChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarshipPage : ContentPage
    {
        public StarshipPage(StarshipViewModel starshipViewModel)
        {
            InitializeComponent();
            BindingContext = starshipViewModel;
        }
    }
}
