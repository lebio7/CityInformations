using CityInformationsApp.Utils;
using Xamarin.Forms;

namespace CityInformationsApp.Models
{
    public class SortButtonModel
    {
        public string Title { get; private set; }

        public ImageSource ImageSort { get; private set; }

        public bool IsSelected { get; set; }

        public int IdEnum { get; private set; }

        public SortButtonModel(int id, string nameOfEnum, ImageSource image)
        {
            IdEnum = id;
            Title = BaseApplication.applicationModel.GetValueFromResourceManager(nameOfEnum);
            ImageSort = image;
            IsSelected = false;
        }
    }
}
