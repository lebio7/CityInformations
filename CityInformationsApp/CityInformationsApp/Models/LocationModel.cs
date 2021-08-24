using CityInformationsApp.Utils;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.Models
{
    public class LocationModel
    {
        public ICommand AddToFavourite { get; set; }

        public string Title { get; private set; }

        public string Address { get; private set; }

        public string DateOpenAndClose { get; private set; }

        public string PhoneNumber { get; private set; }

        public Enums.ObjectLocation SelectedEvent { get; private set; }

        public ImageSource LeftImage { get; private set; }

        public CustomPin Pin { get; private set; }

        public LocationModel(string title, string address, string dateOpenAndClose, string phoneNumber, Enums.ObjectLocation selectedEvent)
        {
            Title = title;
            DateOpenAndClose = dateOpenAndClose;
            LeftImage = Helper.GetImageForSortButtonObjectLocation(selectedEvent);
            PhoneNumber = phoneNumber;
            SelectedEvent = selectedEvent;
            Address = string.IsNullOrEmpty(address) ? string.Empty : $"{Constants.Extensions.Street}{address}";
        }

        public LocationModel(CustomPin pin) 
            : this(pin.Name, pin.Address, pin.TimeOpenClose, pin.PhoneNumber, (Enums.ObjectLocation)pin.EnumName)
        {
            Pin = pin;
        }
    }
}
