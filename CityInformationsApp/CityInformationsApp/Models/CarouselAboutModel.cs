using CityInformationsApp.Utils;
using Xamarin.Forms;

namespace CityInformationsApp.Models
{
    public class CarouselAboutModel
    {
        public string NameImage { get; private set; }

        public ImageSource Image { get; private set; }

        public CarouselAboutModel(string nameImage)
        {
            NameImage = nameImage;

            Image = BaseApplication.LoadImage(nameImage);
        }
    }
}
