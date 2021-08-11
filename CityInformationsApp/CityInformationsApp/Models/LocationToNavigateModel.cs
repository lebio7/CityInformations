using System.Collections.Generic;

namespace CityInformationsApp.Models
{
    public class LocationToNavigateModel
    {
        public List<long> SelectedLocations { get; set; }

        public LocationToNavigateModel()
        {
            SelectedLocations = new List<long>();
        }

        public void AddNewLocation(long elementId)
        {
            if (SelectedLocations.Contains(elementId))
            {
                return;
            }

            SelectedLocations.Add(elementId);
            // pokaż popUp z animacją
        }
    }
}
