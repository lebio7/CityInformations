using CityInformationsApp.Utils;
using Xamarin.Forms;

namespace CityInformationsApp.Models
{
    public class InformationDetailsModel
    {
        #region Const

        public const int WidthRequest = 30;
        public const int HeightRequest = 30;
        public const int FontSize = 13;

        #endregion

        #region Properties

        public string LeftIconName { get; private set; }

        public string DetailValue { get; private set; }

        #endregion

        #region Ctor

        public InformationDetailsModel(string leftIconName, string detailValue)
        {
            LeftIconName = leftIconName;
            DetailValue = detailValue;
        }

        #endregion

        #region Methods

        public StackLayout GenerateView()
        {
            StackLayout stackLayout = new StackLayout();
            stackLayout.Orientation = StackOrientation.Horizontal;
            stackLayout.HorizontalOptions = LayoutOptions.StartAndExpand;

            //Icon
            Image leftImage = new Image();
            leftImage.Source = BaseApplication.LoadImage(LeftIconName);
            leftImage.WidthRequest = WidthRequest;
            leftImage.HeightRequest = HeightRequest;
            leftImage.VerticalOptions = LayoutOptions.Start;

            //Value
            Label label = new Label();
            label.Text = string.IsNullOrEmpty(DetailValue) ? string.Empty : DetailValue;
            label.TextColor = Color.Gray;
            label.FontSize = FontSize;
            label.VerticalTextAlignment = TextAlignment.Center;

            stackLayout.Children.Add(leftImage);
            stackLayout.Children.Add(label);

            return stackLayout;
        }

        #endregion
    }
}
