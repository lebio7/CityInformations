using CityInformationsApp.Utils.CustomRenderer;
using Java.Interop;
using Xamarin.Forms;

namespace CityInformationsApp.Droid.CustomRenderer
{
    class MapJavascriptRun : Java.Lang.Object, Java.Lang.IRunnable
    {
        public IWebViewCustom Owner;

        public MapJavascriptRun()
        {

        }

        public MapJavascriptRun(IWebViewCustom owner)
        {
            if (owner?.Parent != null)
            {
                Owner = owner;
            }
        }

        [Export]
        [Android.Webkit.JavascriptInterface]
        public void AddToLocationToNavigate(long idLocation)
        {
           if (idLocation != 0)
           {
               Utils.BaseApplication.applicationModel.SelectedLocations.AddNewLocation(idLocation);
           }
        }

        [Export]
        [Android.Webkit.JavascriptInterface]
        public void Run()
        {
            
        }
    }
}