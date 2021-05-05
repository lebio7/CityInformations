using CityInformationsApp.Utils;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.Models
{
    public class NewsModel
    {
        public ICommand ReadMore { get; set; }

        public string Title { get; private set; }
        public string Address { get; private set; }
        public string DateEvent { get; private set; }
        public string Price { get; private set; }

        public ImageSource LeftImage { get; private set; }

        public string CreatedDate { get; private set; }

        public List<string> AdditionalDetails;

        public Enums.Events SelectedEvent { get; private set; }

        public NewsModel(string title, string address, string dateEvent, string createdDate, Enums.Events selectedEvent, double price = 0, List<string> additionalDetails = null)
        {
            Title = title;
            CreatedDate = createdDate;
            DateEvent = dateEvent;
            LeftImage = Helper.GetImageForEvent(selectedEvent);
            SelectedEvent = selectedEvent;

            Address = string.IsNullOrEmpty(address) ? string.Empty : $"{Constants.Extensions.Street}{address}";
            Price = price == 0 ? "Bezpłatne" : $"{price}{Constants.Extensions.Zlotych}";

            AdditionalDetails = additionalDetails;
        }
    }
}
