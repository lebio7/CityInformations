using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using CityInformationsApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class FavouriteLocationListViewModel
        : BaseViewModel
    {
        #region Const

        public const int TimeShowPopUpInMS = 1500;

        #endregion

        #region Members

        private ImageAndTextPopUp popUpComeBack;
        private AlertImagePopUpPage alertImagePopUp;
        private MoveElementPopUpPage popUpMoveElement;
        private bool userGoToNavigation;


        #endregion

        #region Properties

        public ObservableCollection<LocationModel> FavouriteLocationList { get; private set; }
        public ICommand GoByCar { get; private set; }
        public ICommand GoByWalk { get; private set; }

        #endregion

        #region Ctor

        public FavouriteLocationListViewModel()
        {
            FavouriteLocationList = new ObservableCollection<LocationModel>();
            popUpComeBack = new ImageAndTextPopUp(BaseApplication.applicationModel.GetValueFromResourceManager(Utils.Constants.ListElementIsEmpty), Constants.ElementExist);
            popUpMoveElement = new MoveElementPopUpPage();
            GoByCar = new Command(NavigateByCar);
            GoByWalk = new Command(NavigateByWalk);
            userGoToNavigation = false;

            PrepareData();
        }

        #endregion

        #region Methods

        public async void ShowPopUpIfUserComeBackFromNavigation()
        {
            if (userGoToNavigation)
            {
                CustomPin pin = FavouriteLocationList.FirstOrDefault()?.Pin;
                if (pin != null)
                {
                    FormattedString fs = new FormattedString();
                    fs.Spans.Add(new Span() { Text = BaseApplication.applicationModel.GetValueFromResourceManager(Constants.AreYouArchievedTargetPlace), FontAttributes = FontAttributes.None, FontSize = 15 });
                    fs.Spans.Add(new Span() { Text = $" {pin.Name}", FontAttributes = FontAttributes.Bold, FontSize = 15});

                    alertImagePopUp = new AlertImagePopUpPage(Constants.CarouselView.Carousel1,
                        fs,
                        BaseApplication.applicationModel.GetValueFromResourceManager(Constants.No),
                        BaseApplication.applicationModel.GetValueFromResourceManager(Constants.Yes));

                    bool result = await alertImagePopUp.ShowAlert();
                    if (result)
                    {
                        RemoveToListIcon(FavouriteLocationList.FirstOrDefault(x => x.Pin.ElementId == pin.ElementId));
                    }
                }
            }

            userGoToNavigation = false;
        }

        private void PrepareData()
        {
            if (BaseApplication.applicationModel.SelectedLocations.SelectedLocations == null
                || BaseApplication.applicationModel.SelectedLocations.SelectedLocations.Count == 0)
            {
                GoBackCommand();
            }

            List<CustomPin> favouriteList = TestData.TestLocationData.Where(x => BaseApplication.applicationModel.SelectedLocations.SelectedLocations.Contains(x.ElementId))
                .OrderBy(x => BaseApplication.applicationModel.SelectedLocations.SelectedLocations.FindIndex(a => a == x.ElementId))
                .ToList();

            foreach (CustomPin pin in favouriteList)
            {
                LocationModel model = new LocationModel(pin);
                FavouriteLocationList.Add(model);
                model.RemoveToListIcon = new Command<object>(RemoveToListIcon);
                model.MoveToListIcon = new Command<object>(MoveToListIcon);
            }
        }

        private void RemoveToListIcon(object selectedItem)
        {
            if (selectedItem is LocationModel locationPin)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    FavouriteLocationList.Remove(locationPin);

                    BaseApplication.applicationModel.SelectedLocations.RemoveLocation(locationPin.Pin.ElementId);

                    DisplayAlertAndGoBack();
                });
            }
        }

        private async void NavigateByCar()
        {
            CustomPin pin = FavouriteLocationList.FirstOrDefault()?.Pin;

            await NavigateTo(pin.Latitude, pin.Longitude, NavigationMode.Driving);
        }

        private async void NavigateByWalk()
        {
            CustomPin pin = FavouriteLocationList.FirstOrDefault()?.Pin;

            await NavigateTo(pin.Latitude, pin.Longitude, NavigationMode.Walking);
        }

        private async void MoveToListIcon(object selectedItem)
        {
            if (selectedItem is LocationModel locationPin)
            {
                int index = await popUpMoveElement.ShowAlert();

                if (index != 0)
                {
                    int currentIndex = FavouriteLocationList.IndexOf(locationPin);

                    if (currentIndex + index < 0 || currentIndex + index >= FavouriteLocationList?.Count)
                    {
                        return;
                    }

                    int newIndex = currentIndex + index;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        FavouriteLocationList.Remove(locationPin);
                        FavouriteLocationList.Insert(newIndex, locationPin);

                        BaseApplication.applicationModel.SelectedLocations.InitListAfterChange(FavouriteLocationList.Select(x => (long)x.Pin.ElementId).ToList());
                    });
                }
            }
        }

        private async void DisplayAlertAndGoBack()
        {
            if (FavouriteLocationList.Count == 0)
            {
                Device.BeginInvokeOnMainThread(async () => { await popUpComeBack.ShowAlert(); });

                await Task.Delay(TimeShowPopUpInMS);

                Device.BeginInvokeOnMainThread(() => { popUpComeBack.CloseAllPopup(); });

                GoBackCommand();
            }
        }

        private async Task NavigateTo(double latitude, double longitude, Xamarin.Essentials.NavigationMode navigateMode)
        {
            userGoToNavigation = true;
            Location location = new Location(latitude, longitude);
            MapLaunchOptions options = new MapLaunchOptions { NavigationMode = navigateMode };
            await Map.OpenAsync(location, options);
        }

        #endregion
    }
}
