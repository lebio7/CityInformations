using CityInformationsApp.Models;
using Xamarin.Forms;

namespace CityInformationsApp.Utils
{
    public static class BaseApplication
    {
        #region Members

        public static ApplicationModel applicationModel;
        #endregion

        #region Methods

        public static ImageSource LoadImage(string nameImage)
        {
            return ImageSource.FromResource($"{Constants.ProjectName}.{Constants.FolderImages}.{nameImage}.{Constants.PngExtension}", applicationModel.ProjectAssembly);
        }

        #endregion
    }
}
