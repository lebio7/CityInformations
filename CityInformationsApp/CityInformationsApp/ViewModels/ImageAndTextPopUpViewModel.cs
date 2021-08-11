using CityInformationsApp.Utils;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class ImageAndTextPopUpViewModel : BaseViewModel
    {
        #region Properties

        public bool IsActivityIndicator { get; private set; }
        public bool IsShowing { get; private set; }
        public bool IsImageToDisplay { get; private set; }

        public ImageSource ImageToShow { get; private set; }

        public bool IsCancelEnabled { get; private set; }
        public string TextToDisplay { get; private set; }

        #endregion


        #region Ctor

        public ImageAndTextPopUpViewModel(string textToDisplay, string imageToDisplay = null, bool imageIsAnimated = false)
        {
            IsActivityIndicator = string.IsNullOrEmpty(imageToDisplay);
            IsImageToDisplay = !IsActivityIndicator;

            if (IsImageToDisplay)
            {
                ImageToShow = BaseApplication.LoadImage(imageToDisplay);
            }

            TextToDisplay = textToDisplay;
        }

        #endregion

        private async void ClosePopUp()
        {
            try
            {
                IsShowing = false;

                try
                {
                    if (PopupNavigation.Instance.PopupStack.ToList()?.Exists(q => q.GetType() == typeof(ImageAndTextPopUpViewModel)) ?? false)
                    {
                        await PopupNavigation.Instance.PopAsync(animate: true);
                    }
                }
                catch (IndexOutOfRangeException iex)
                {
                }
            }
            catch (IndexOutOfRangeException iex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<bool> ShowPopUp(PopupPage page, bool animate = true)
        {
            if (IsShowing)
            {
                return false;
            }

            if (page.Parent != null)
            {
                return false;
            }

            IsShowing = true;

            await PopupNavigation.Instance.PushAsync(page, animate: animate);

            return true;
        }

        public async void CloseAllPopup(bool animation = true)
        {
            IsShowing = false;
            await PopupNavigation.Instance.PopAllAsync(animate: animation);
        }
    }
}
