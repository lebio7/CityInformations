using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using CityInformationsApp.Utils.CustomRenderer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityInformationsApp.ViewModels
{
    public class MapPageViewModel
    {
        #region Members
        private List<CustomPin> locationToNavigate;
        private CustomMapProvider mapProvider;
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

            PrepareData();
        }

        #endregion

        #region Methods
        private async void PrepareData()
        {
            SortButtonBuilder.AddButtonsByObjectLocation((Enums.ObjectLocation[])Enum.GetValues(typeof(Enums.ObjectLocation)));
            await mapProvider.LoadMap();
        }


        private void SortByEventButton(int nameEnums)
        {
            Enums.ObjectLocation eventName = (Enums.ObjectLocation)nameEnums;

            mapProvider.SortCustomPins(eventName);
        }

        #endregion
    }
}
