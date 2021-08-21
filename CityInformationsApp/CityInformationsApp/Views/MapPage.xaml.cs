using CityInformationsApp.Utils;
using CityInformationsApp.Utils.CustomRenderer;
using CityInformationsApp.ViewModels;
using System;
using System.IO;
using System.Reflection;
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
            
            viewModel = new MapPageViewModel(new CustomMapProvider(webView, Utils.TestData.TestLocationData));
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
        }

        public void GenerateButtonsSortView()
        {
            viewModel?.SortButtonBuilder.Build(SortButtons);
        }
    }
}