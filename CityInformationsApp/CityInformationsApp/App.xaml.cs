using Xamarin.Forms;
using System.Linq;
using CityInformationsApp.Views;

namespace CityInformationsApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            Page lastPage = Shell.Current?.Navigation?.ModalStack?.LastOrDefault();

            if (lastPage != null && lastPage is FavouriteLocationListPage favouritePage)
            {
                favouritePage.ShowPopUpIfUserComeBackFromNavigation();
            }
        }
    }
}
