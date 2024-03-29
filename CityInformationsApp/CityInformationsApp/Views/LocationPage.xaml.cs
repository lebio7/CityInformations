﻿using CityInformationsApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        private LocationPageViewModel viewModel;

        public LocationPage()
        {
            InitializeComponent();
            viewModel = new LocationPageViewModel();

            BindingContext = viewModel;
            GenerateButtonsSortView();
        }

        protected override async void OnAppearing()
        {
            viewModel?.IsVisibleFavouriteButton();
        }

        public void GenerateButtonsSortView()
        {
            viewModel?.SortButtonBuilder.Build(SortButtons);
        }
    }
}