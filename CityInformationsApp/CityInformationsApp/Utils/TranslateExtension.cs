using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Utils
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return null;
            }

            return BaseApplication.applicationModel.GetValueFromResourceManager(Text);
        }
    }
}
