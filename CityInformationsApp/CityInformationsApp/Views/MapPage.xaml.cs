using CityInformationsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        MapPageViewModel viewModel;
        private bool isRunning;

        public MapPage()
        {
            InitializeComponent();

            viewModel = new MapPageViewModel(webView);

            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            if (!isRunning)
            {
                isRunning = true;
                GenerateButtonsSortView();

                await viewModel.PrepareData();

                return;
            }

            viewModel?.ReloadMapPins();
            viewModel?.IsVisibleFavouriteButton();
        }

        public void GenerateButtonsSortView()
        {
            viewModel?.SortButtonBuilder.Build(SortButtons);
        }
    }
}