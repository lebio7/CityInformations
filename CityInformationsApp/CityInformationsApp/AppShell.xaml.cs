using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using CityInformationsApp.Views;
using System.Reflection;
using Xamarin.Forms;

namespace CityInformationsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            ApplicationModel applicationModel = new ApplicationModel(Assembly.GetAssembly(this.GetType()));
            BaseApplication.applicationModel = applicationModel;
            Routing.RegisterRoute(nameof(InformationDetailsPage), typeof(InformationDetailsPage));
        }

    }
}
