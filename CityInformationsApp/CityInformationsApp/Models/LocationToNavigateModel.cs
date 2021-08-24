using CityInformationsApp.Utils;
using CityInformationsApp.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInformationsApp.Models
{
    public class LocationToNavigateModel
    {
        #region Const

        public const int TimeShowPopUpInMS = 1500;

        #endregion

        #region Members

        private ImageAndTextPopUp popUpExist;
        private ImageAndTextPopUp popUpNotExist;

        #endregion

        #region Properties

        public List<long> SelectedLocations { get; set; }

        #endregion

        public LocationToNavigateModel()
        {
            SelectedLocations = new List<long>();
        }


        public async void AddNewLocation(long elementId)
        {
            if (popUpExist == null || popUpNotExist == null)
            {
                InitPopUp();
            }

            if (SelectedLocations.Contains(elementId))
            {
                await LocationExist();
                return;
            }

            SelectedLocations.Add(elementId);

            await LocationNotExist();
        }

        private void InitPopUp()
        {
            popUpExist = new ImageAndTextPopUp(BaseApplication.applicationModel.GetValueFromResourceManager(Utils.Constants.ElementExist), Constants.ElementExist);
            popUpNotExist = new ImageAndTextPopUp(BaseApplication.applicationModel.GetValueFromResourceManager(Utils.Constants.ElementNotExist), Constants.ElementNotExist);
        }
        private async Task LocationExist()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => { await popUpExist.ShowAlert(); });

            await Task.Delay(TimeShowPopUpInMS);

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { popUpExist.CloseAllPopup(); });
        }

        private async Task LocationNotExist()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => { await popUpNotExist.ShowAlert(); });

            await Task.Delay(TimeShowPopUpInMS);

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { popUpNotExist.CloseAllPopup(); });
        }
    }
}
