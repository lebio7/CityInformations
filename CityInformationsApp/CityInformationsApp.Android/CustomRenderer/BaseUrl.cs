using CityInformationsApp.Utils.CustomRenderer;
using Xamarin.Forms;

[assembly: Dependency(typeof(CityInformationsApp.Droid.CustomRenderer.BaseUrl))]
namespace CityInformationsApp.Droid.CustomRenderer
{
    public class BaseUrl : IBaseUrl
    {
        public string Get() { return "file:///android_asset/"; }
    }
}