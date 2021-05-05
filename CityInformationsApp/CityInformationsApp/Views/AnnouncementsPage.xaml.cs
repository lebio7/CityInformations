using CityInformationsApp.Utils;
using CityInformationsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnnouncementsPage : ContentPage
    {
        private AnnouncementsPageViewModel viewModel;
        public AnnouncementsPage()
        {
            InitializeComponent();
            viewModel = new AnnouncementsPageViewModel();
            BindingContext = viewModel;

            GenerateButtonsSortView();
        }

        public void GenerateButtonsSortView()
        {
            viewModel?.SortButtonBuilder.Build(SortButtons);
        }
    }
}