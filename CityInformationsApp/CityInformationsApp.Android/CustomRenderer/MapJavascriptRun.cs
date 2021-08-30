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
        public void AddToLocationToNavigate(string idLocation)
        {
            if (!string.IsNullOrEmpty(idLocation) && long.TryParse(idLocation, out long location))
            {
                if (Owner != null)
                {
                    Owner.AddLocation(location);
                }
                else
                {
                    Utils.BaseApplication.applicationModel.SelectedLocations.AddNewLocation(location);
                }
            }
        }

        [Export]
        [Android.Webkit.JavascriptInterface]
        public void Run()
        {
            
        }
    }
}