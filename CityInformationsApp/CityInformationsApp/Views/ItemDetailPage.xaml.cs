using CityInformationsApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CityInformationsApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}