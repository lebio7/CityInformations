using CityInformationsApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        private AboutPageViewModel viewModel;
        public AboutPage()
        {
            InitializeComponent();

            viewModel = new AboutPageViewModel();
            BindingContext = viewModel;
        }
    }
}