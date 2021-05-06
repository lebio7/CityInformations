using CityInformationsApp.Utils;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace CityInformationsApp.Models
{
    public class ApplicationModel
    {
        #region Const

        public IReadOnlyList<string> ImagesToRandInHomePage = new List<string>
        {
            "RandomSiewierz1"
        };

        public IReadOnlyList<string> ImagesToCarouselAboutPage = new List<string>
        {
            Constants.CarouselView.Carousel1,
            Constants.CarouselView.Carousel2,
            Constants.CarouselView.Carousel3,
            Constants.CarouselView.Carousel4,
        };

        public string LogoName = "SiewierzLogo";

        #endregion

        #region Properties
        public CultureInfo cultureInfo { get; private set; }
        #endregion

        public Assembly ProjectAssembly { get; private set; }

        public ApplicationModel(Assembly projectAssembly)
        {
            ProjectAssembly = projectAssembly;
            cultureInfo = new CultureInfo("pl-PL");
        }
    }
}
