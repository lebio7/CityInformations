using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using CityInformationsApp.Utils.CustomRenderer;
using CityInformationsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class MapPageViewModel
        : BaseViewModel
    {
        #region Members

        private CustomMapProvider mapProvider;
        private ImageAndTextPopUp popUp;
        private Enums.ObjectLocation selectedEventName;
        private AlertImagePopUpPage alertImagePopUp;

        #endregion

        #region Properties

        public SortButtonBuilder SortButtonBuilder { get; private set; }

        public bool IsButtonFavouriteVisible
        {
            get
            {
                return BaseApplication.applicationModel?.SelectedLocations?.SelectedLocations?.Count > 0;
            }
        }

        public ICommand GoToFavouriteList { get; private set; }

        #endregion

        #region Ctor

        public MapPageViewModel(IWebViewCustom customMap)
        {
            SortButtonBuilder = new SortButtonBuilder(SortByEventButton);
            this.mapProvider = new CustomMapProvider(customMap, TestData.TestLocationData, ShowMarkerToolTip);
            popUp = new ImageAndTextPopUp(BaseApplication.applicationModel.GetValueFromResourceManager(Utils.Constants.PleaseWaitLoadingData));
            SortButtonBuilder.AddButtonsByObjectLocation((Enums.ObjectLocation[])Enum.GetValues(typeof(Enums.ObjectLocation)));
            GoToFavouriteList = new Command(FavouriteListButton);
        }

        #endregion

        #region Methods

        public async void FavouriteListButton()
        {
            FavouriteLocationListPage page = new FavouriteLocationListPage();
            await Shell.Current.Navigation.PushModalAsync(page);
        }

        public async void ShowMarkerToolTip(long idLocation)
        {
            if (idLocation != 0 && mapProvider.AllPins.Exists(x=> x.ElementId == idLocation))
            {
                CustomPin pin = mapProvider.AllPins.FirstOrDefault(x=> x.ElementId == idLocation);
                if (pin != null)
                {
                    FormattedString fs = new FormattedString();
                    fs.Spans.Add(new Span() { Text = $"{pin.Name}", FontAttributes = FontAttributes.Bold, FontSize = 17 });

                    List<(string image, string details)> details = new List<(string image, string details)>();
                    details.Add((Constants.Location, pin.Address));
                    details.Add((Constants.Calendar, pin.TimeOpenClose));
                    details.Add((Constants.NumberPhone, pin.PhoneNumber));

                    alertImagePopUp = new AlertImagePopUpPage(Constants.CarouselView.Carousel1,
                       fs,
                        BaseApplication.applicationModel.GetValueFromResourceManager(Constants.GoBack),
                        BaseApplication.applicationModel.GetValueFromResourceManager(Constants.AddToRoute),
                        details);

                    bool result = await alertImagePopUp.ShowAlert();
                    if (result)
                    {
                        Utils.BaseApplication.applicationModel.SelectedLocations.AddNewLocation(idLocation);
                    }
                }
            }

            IsVisibleFavouriteButton();
        }

        public void IsVisibleFavouriteButton()
        {
            OnPropertyChanged(nameof(IsButtonFavouriteVisible));
        }

        public async Task PrepareData()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => { await popUp.ShowAlert(); });

            await Task.Delay(500);

            await mapProvider.LoadMap();

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { popUp.CloseAllPopup(); });
        }

        public void ReloadMapPins()
        {
            mapProvider?.ReloadPins(selectedEventName);
        }

        private void SortByEventButton(int nameEnums)
        {
            Enums.ObjectLocation eventName = (Enums.ObjectLocation)nameEnums;
            selectedEventName = eventName;

            mapProvider.SortCustomPins(eventName);
        }
        #endregion
    }
}
