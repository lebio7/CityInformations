using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.Models
{
    public class NewsModel
    {
        public ICommand ReadMore { get; set; }

        public string Title { get; private set; }

        public ImageSource LeftImage { get; private set; }

        public string ShortDescription { get; private set; }

        public string CreatedDate { get; private set; }

        public NewsModel(string title, string shortDescription, ImageSource leftImage, string createdDate)
        {
            Title = title;
            LeftImage = leftImage;
            ShortDescription = shortDescription;
            CreatedDate = createdDate;
        }
    }
}
