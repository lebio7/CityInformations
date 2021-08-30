using Xamarin.Forms;

namespace CityInformationsApp.Models
{
    public class AlertPopUpModel
    {
        public ImageSource Image { get; private set; }
        public string Details { get; private set; }

        public AlertPopUpModel(string details, ImageSource image)
        {
            Details = details;
            Image = image;
        }
    }
}
