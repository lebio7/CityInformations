using CityInformationsApp.Utils;
using System;

namespace CityInformationsApp.ViewModels
{
    public class MapPageViewModel
    {
        #region Properties
        public SortButtonBuilder SortButtonBuilder { get; private set; }

        #endregion

        #region Ctor

        public MapPageViewModel()
        {
            SortButtonBuilder = new SortButtonBuilder(SortByEventButton);

            PrepareData();
        }

        #endregion

        #region Methods
        private void PrepareData()
        {
            SortButtonBuilder.AddButtonsByObjectLocation((Enums.ObjectLocation[])Enum.GetValues(typeof(Enums.ObjectLocation)));
        }

        private void SortByEventButton(int nameEnums)
        {

        }


        #endregion
    }
}
