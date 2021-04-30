using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using System.Reflection;

namespace CityInformationsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            ApplicationModel applicationModel = new ApplicationModel(Assembly.GetAssembly(this.GetType()));
            BaseApplication.applicationModel = applicationModel;
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
