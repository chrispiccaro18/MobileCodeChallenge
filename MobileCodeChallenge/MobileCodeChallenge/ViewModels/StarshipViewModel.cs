using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MobileCodeChallenge.Models;
using MobileCodeChallenge.Services;

namespace MobileCodeChallenge.ViewModels
{
    public class StarshipViewModel : INotifyPropertyChanged
    {
        public Starship Starship { get; set; }
        public string Title { get; set; }
        public StarshipViewModel(Starship starship = null)
        {
            Title = starship.Name;
            Starship = starship;
            LoadImage(Starship.Name);
            Console.WriteLine(imageUrl);
            Console.WriteLine(ImageUrl);
        }
        private string imageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.jennybeaumont.com%2Fwp-content%2Fuploads%2F2015%2F03%2Fplaceholder.gif&f=1&nofb=1";
        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                if (value != imageUrl)
                {
                    ImageUrl = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadImage(string name)
        {
            var imageService = new StarshipImageService();
            Console.WriteLine(await imageService.GetImageUrl(name));
            ImageUrl = await imageService.GetImageUrl(name);
        }
    }
}
