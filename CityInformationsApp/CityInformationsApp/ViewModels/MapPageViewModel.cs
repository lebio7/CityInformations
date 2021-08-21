using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using CityInformationsApp.Utils.CustomRenderer;
using CityInformationsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInformationsApp.ViewModels
{
    public class MapPageViewModel
    {
        #region Members

        private List<CustomPin> locationToNavigate;
        private CustomMapProvider mapProvider;
        private ImageAndTextPopUp popUp;
        private Enums.ObjectLocation selectedEventName;

        #endregion

        #region Properties

        public SortButtonBuilder SortButtonBuilder { get; private set; }

        #endregion

        #region Ctor

        public MapPageViewModel(CustomMapProvider mapProvider)
        {
            SortButtonBuilder = new SortButtonBuilder(SortByEventButton);
            this.mapProvider = mapProvider;
            locationToNavigate = new List<CustomPin>();
            popUp = new ImageAndTextPopUp(BaseApplication.applicationModel.GetValueFromResourceManager(Utils.Constants.PleaseWaitLoadingData));

            SortButtonBuilder.AddButtonsByObjectLocation((Enums.ObjectLocation[])Enum.GetValues(typeof(Enums.ObjectLocation)));
        }

        #endregion

        #region Methods
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
