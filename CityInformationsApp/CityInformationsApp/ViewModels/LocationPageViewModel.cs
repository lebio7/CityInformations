using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class LocationPageViewModel 
        : BaseViewModel
    {
        #region Members 

        private List<LocationModel> allItemsList;
        private Enums.ObjectLocation selectedEventName;

        #endregion

        #region Properties

        private ObservableCollection<LocationModel> locationList;

        public ObservableCollection<LocationModel> LocationList
        {
            get
            {
                return locationList;
            }
            set
            {
                locationList = value;
                OnPropertyChanged();
            }
        }

        public SortButtonBuilder SortButtonBuilder { get; private set; }

        #endregion

        #region Ctor

        public LocationPageViewModel()
        {
            allItemsList = new List<LocationModel>();
            LocationList = new ObservableCollection<LocationModel>();
            SortButtonBuilder = new SortButtonBuilder(SortByEventButton);
            PrepareData();
        }

        #endregion

        #region Methods

        private void PrepareData()
        {
            SortButtonBuilder.AddButtonsByObjectLocation((Enums.ObjectLocation[])Enum.GetValues(typeof(Enums.ObjectLocation)));
            LoadNewsCollection();
        }

        private void LoadNewsCollection()
        {
            foreach (CustomPin pin in TestData.TestLocationData)
            {
                LocationModel model = new LocationModel(pin);
                allItemsList.Add(model);
                model.AddToFavourite = new Command<object>(AddToFavouriteList);
            }
        }

        private void SortByEventButton(int nameEnums)
        {
            Enums.ObjectLocation eventName = (Enums.ObjectLocation)nameEnums;
            selectedEventName = eventName;

            if (eventName == Enums.ObjectLocation.All)
            {
                LocationList = new ObservableCollection<LocationModel>(allItemsList);
            }
            else
            {
                LocationList = new ObservableCollection<LocationModel>(allItemsList.Where(x => x.SelectedEvent == eventName));
            }
        }

        private void AddToFavouriteList(object selectedItem)
        {
            if (selectedItem is LocationModel locationPin && locationPin.Pin != null)
            {
                if (locationPin.Pin.ElementId != 0)
                {
                    Utils.BaseApplication.applicationModel.SelectedLocations.AddNewLocation(locationPin.Pin.ElementId);
                }
            }
        }

        #endregion
    }
}
