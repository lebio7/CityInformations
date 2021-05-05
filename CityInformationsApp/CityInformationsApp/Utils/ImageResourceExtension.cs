using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Utils
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            ImageSource imageSource = BaseApplication.LoadImage(Source);

            return imageSource;
        }
    }
}
