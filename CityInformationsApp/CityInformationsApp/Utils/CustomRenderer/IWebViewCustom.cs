using System;
using Xamarin.Forms;

namespace CityInformationsApp.Utils.CustomRenderer
{
    public class IWebViewCustom : WebView
    {
        public Action<long> RefreshView;

        public void AddLocation(long idLocation)
        {
            RefreshView?.Invoke(idLocation);
        }
    }
}
