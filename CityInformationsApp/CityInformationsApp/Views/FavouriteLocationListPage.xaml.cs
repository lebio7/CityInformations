using CityInformationsApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouriteLocationListPage : ContentPage
    {
        private FavouriteLocationListViewModel viewModel;

        public FavouriteLocationListPage()
        {
            InitializeComponent();

            viewModel = new FavouriteLocationListViewModel();

            BindingContext = viewModel;
        }

        public void ShowPopUpIfUserComeBackFromNavigation()
        {
            viewModel?.ShowPopUpIfUserComeBackFromNavigation();
        }

    }
}