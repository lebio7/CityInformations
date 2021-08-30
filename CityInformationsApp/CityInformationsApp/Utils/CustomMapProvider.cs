using CityInformationsApp.Utils.CustomRenderer;
using CityInformationsApp.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CityInformationsApp.Utils
{
    public class CustomMapProvider
    {
        #region Const

        public const string IndexPath = "CityInformationsApp.Utils.index.html";
        public const int TimeWaitAfterStartMap = 1000;// ms
        public const string DirectionIcon = @"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGAAAABgCAQAAABIkb+zAAADpElEQVR4Ae3aA9DsSBQF4DNa2+ZvZNL3lNa2d0tr24W1bdu2bdu2beO5l8/InX/6JpmqfKdcgz4dA4VCoVAohNQ7mSwrB8k5cjOf4gcyiL/zA3lcbpZzeIAsyxpyrMLV5Ab+Tj+J/C7XcTVUkDcLTCG7yWf0ushnsnvb5MiNqtuZX9I3mC+5A6rIHtfme/QDzHtuTWSqIifSNxc5IbMtgtPLffTNR+7j9EhffW6+TR8ob0XzIF2cTz6nDxf5nPMhPV0z8336wHm/a2akgzU+TW+Qp1M6TvMieqNcBHvcgN4wG8BW2+TyuWUB+dz4FEP2obeN7Gt76PrNvMBvhoc1OZbePnKM2e5TfqVPIb8Y7U5lHf0gZJBc5TaJ43iGvxO7TeQqGUT9t9eBBblKPYR73PwYh5ufd6sLXA0DJf6kHMCRmLCSHE6vyk8oIbR4MeXsHY5JcEfQaxIvhtDcnrqVJ2HuSryHXpG9EJqcr9l0k8/r++ZVbc7nITR5RFHgMijIZYpfegSh8YNQp2Ka00H5EKHxe/qkRJ1QiDoVU/E9QpMR9EnpnBYKndMqlsBwhMY/6JPSNh0U2qajT8wfCI2f0CfF9UDB9SgKfILQ+EKaGzFfQGiqA9AVUOAVqgNiaHK66kC2IBJEC2oOZHI6QpPNdLcJk04ldLcjZTOEVu9Vn4tOAo+i16Tei+DK/KPJ89GSHEavyh8oIzy5o5kLmv6FeI/2+3InLHCrRi8pXT2egdO7uttEruIQenW2MrqlKyPo7SMjemeCDT5An0IegBW3XSoFtoeVaGoZZD18GcSpYEcuNC9wISzFi1oXiBeFLb5tOv/vwppsZlpgM5irykdmBT5GFfbcFlYF3BYwYr8M7OfffjuQzZGaMt8MXuAtlJEet17oAm49pEteClrgFaTNLR/0+LsC0sdrgxW4FlnonSPMU0v5tW92ZIPb257/2yvJ403P/xMoITtRJ4c1VWBY1IlsydFNzf/RyNo8U/KTARf4dJ4pkb14rQHv/ddCPvCKARW4AnnRNh2/aHj4X7RNh/yIl260gFsK+dLYW9RyEvKGNXlOXeB51pA/9bn5nWr437u5kE/x0jI8+RG2WxL5JQcmFjgQuVbmU5Ms8DTKyLe+eeWHic7+j9E8yD+uOOEtQYZzRbQG2W2CBXaDHfsX1OR8tJSKPDnW8J9EBa0lmk2+HjX8r6PZ0Hoo/z8bHkJBa5Kt6ella7QuHsWjYKZQKBQKhb8AaFXSW3c/idsAAAAASUVORK5CYII=";
        #endregion

        #region Members

        private IWebViewCustom webViewCustom;
        
        private string navigateText;
        private double latitude;
        private double longtitude;

        #endregion

        #region Properties

        public List<CustomPin> AllPins { get; set; }

        #endregion

        #region Ctor

        public CustomMapProvider(IWebViewCustom webViewCustom, List<CustomPin> pins, Action<long> refreshView)
        {
            webViewCustom.RefreshView = refreshView;
            this.webViewCustom = webViewCustom;

            AllPins = pins;
            navigateText = BaseApplication.applicationModel.GetValueFromResourceManager(Utils.Constants.AddToLocationsList);
        }

        #endregion

        #region Methods

        public async Task LoadMap()
        {
            HtmlWebViewSource source = new HtmlWebViewSource();
            source.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            Assembly assembly = typeof(MapPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(IndexPath);
            StreamReader reader = null;

            if (stream != null)
            {
                try
                {
                    reader = new StreamReader(stream);
                    source.Html = reader.ReadToEnd();
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

                webViewCustom.Source = source;
            }

            await Task.Delay(TimeWaitAfterStartMap);

            LoadPinsInMap(AllPins);

            await LoadCustomPosition();
        }

        public void SortCustomPins(Enums.ObjectLocation sortButton)
        {
            if (sortButton == Enums.ObjectLocation.All)
            {
                LoadPinsInMap(AllPins);
            }
            else
            {
                LoadPinsInMap(AllPins.Where(x => x.EnumName == (int)sortButton).ToList());
            }
        }

        public async void ReloadPins(Enums.ObjectLocation sortButton)
        {
            ClearMarker();

            await Task.Delay(TimeWaitAfterStartMap);

            SortCustomPins(sortButton);
        }

        public async Task LoadCustomPosition()
        {
            try
            {
                Xamarin.Essentials.Location location = await Xamarin.Essentials.Geolocation.GetLocationAsync();

                if (location != null && location.Latitude != 0 && location.Longitude != 0)
                {
                    latitude = location.Latitude;
                    longtitude = location.Longitude;
                    CenterMap(location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture), location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            catch(Exception ex)
            {
                latitude = 0;
                longtitude = 0;
            }
        }

        private void LoadPinsInMap(List<CustomPin> pinsToShow)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ClearMarker();

                foreach (CustomPin pin in pinsToShow)
                {
                    CreateTooltip(pin);
                }

                Show();
            });
        }

        private void Show()
        {
            webViewCustom.Eval(@"show()");

            if (latitude != 0 && longtitude != 0)
            {
                CenterMap(latitude.ToString(System.Globalization.CultureInfo.InvariantCulture), longtitude.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
        }

        private void ClearMarker()
        {
            webViewCustom.Eval(@"delMarker()");
        }

        private void CenterMap(string lat, string lon)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                return;
            }

            webViewCustom.Eval(string.Format("centerMap({0},{1})", "\"" + lat + "\"", "\"" + lon + "\""));
        }

        private void NewCircle(string lat, string lon, string color = "blue", string fillcolor = "#07", double fillopacity = 0.5, int radius = 500)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                return;
            }

            webViewCustom.Eval(string.Format("newCircle({0},{1},{2},{3},{4},{5})", "\"" + lat + "\"", "\"" + lon + "\"", "\"" + color + "\"", "\"" + fillcolor + "\"", "\"" + fillopacity + "\"", "\"" + radius + "\""));
        }

        private void NewLine(string latFrom, string lonFrom, string latTo, string lonTo, string color = "blue")
        {
            if (string.IsNullOrEmpty(latFrom) || string.IsNullOrEmpty(lonFrom) || string.IsNullOrEmpty(latTo) || string.IsNullOrEmpty(lonTo))
            {
                return;
            }

            webViewCustom.Eval(string.Format("newLine({0},{1},{2}),{3},{4}", "\"" + latFrom + "\"", "\"" + lonFrom + "\"", "\"" + latTo + "\"", "\"" + lonTo + "\"", "\"" + color + "\""));
        }

        private void NewMarkerWithOwnIcon(string lat, string lon, string texto = "", string ownIcon = "Location")
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                return;
            }

            webViewCustom.Eval(string.Format("newMarkerWithOwnIcon({0}, {1}, {2}, {3})", "\"" + lat + "\"", "\"" + lon + "\"", "\"" + texto + "\"", "\"" + ownIcon + "\""));
        }

        private void NewMarker(string lat, string lon, string texto = "")
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                return;
            }

            webViewCustom.Eval(string.Format("newMarker({0}, {1}, {2})", "\"" + lat + "\"", "\"" + lon + "\"", "\"" + texto + "\""));
        }

        private void CreateTooltip(CustomPin pin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<b> {pin.Name}</b>");
            sb.Append($"<br>");
            sb.Append($"<u>{pin.Address}</u>");
            sb.Append(string.Format(@"<button class=\'directionButton\' onClick=\'CSharp.AddToLocationToNavigate({0})\'>{1} <img src=\'{2}\' /></button>", pin.ElementId.ToString(), navigateText, DirectionIcon));
            //NewMarkerWithOwnIcon(pin.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture), pin.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture), sb.ToString(), pin.EnumName.ToString());
            NewMarkerWithOwnIcon(pin.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture), pin.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture), pin.ElementId.ToString(), pin.EnumName.ToString());
        }

        #endregion
    }
}
