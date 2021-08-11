using System;

namespace CityInformationsApp.Utils
{
    public class CustomPin
    {
        public int ElementId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int EnumName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string TimeOpenClose { get; set; }

        public CustomPin(int elementId)
        {
            ElementId = elementId;
        }
    }
}
