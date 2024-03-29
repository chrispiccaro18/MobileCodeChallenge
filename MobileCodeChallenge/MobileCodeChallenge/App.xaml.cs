﻿using MobileCodeChallenge.Services;
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

            MainPage = new NavigationPage(new Views.Starships());
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
