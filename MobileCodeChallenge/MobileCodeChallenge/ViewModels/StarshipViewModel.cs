using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        }
        private string imageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Frobert.accettura.com%2Fwp-content%2Fuploads%2F2008%2F12%2F20081217_simcity_iphone_loading.jpg&f=1&nofb=1";
        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
                NotifyPropertyChanged();
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
            ImageUrl = await imageService.GetImageUrl(name);
        }
    }
}
