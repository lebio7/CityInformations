using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using CityInformationsApp.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationDetailsPage : ContentPage
    {
        private InformationDetailsPageViewModel viewModel;

        public InformationDetailsPage(string title, string description, Enums.Events eventDetail, List<InformationDetailsModel> informationDetailsModels, string dayOfWeek = null)
        {
            InitializeComponent();
            viewModel = new InformationDetailsPageViewModel(title, description, eventDetail, informationDetailsModels, dayOfWeek);
            BindingContext = viewModel;
            GenerateCustomDetails();
        }

        public void GenerateCustomDetails()
        {
            if (viewModel?.InformationDetails?.Count > 0)
            {
                viewModel.InformationDetails.ForEach(x => Details.Children.Add(x.GenerateView()));
            }
        }
    }
}