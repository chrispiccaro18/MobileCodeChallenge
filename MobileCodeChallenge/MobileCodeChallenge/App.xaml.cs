using MobileCodeChallenge.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileCodeChallenge
{
    public partial class App : Application
    {
        public static StarshipManager starshipManager { get; private set; }
        public App()
        {
            InitializeComponent();

            starshipManager = new StarshipManager(new RestService());

            MainPage = new NavigationPage(new StarshipListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
