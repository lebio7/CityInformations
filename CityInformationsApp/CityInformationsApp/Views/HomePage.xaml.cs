using CityInformationsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomePageViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomePageViewModel();
            BindingContext = viewModel;
        }
    }
}