using CityInformationsApp.Utils;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class MoveElementPopUpViewModel : BaseViewModel
    {

        #region Members

        private AutoResetEvent autoResetEvent;
        private int selectedOption;

        #endregion

        #region Properties

        public ImageSource ImageMoveUp { get; private set; }
        public ImageSource ImageMoveDown { get; private set; }

        public ICommand MoveUpCommand { get; private set; }
        public ICommand MoveDownCommand { get; private set; }

        public bool IsCancelEnabled { get; private set; }
        public bool IsShowing { get; private set; }

        #endregion

        #region Ctor

        public MoveElementPopUpViewModel()
        {
            autoResetEvent = new AutoResetEvent(false);
            selectedOption = 0;

            MoveUpCommand = new Command(MoveUp);
            MoveDownCommand = new Command(MoveDown);
        }

        public async Task<int> ShowAlertAsync(PopupPage page, bool animate)
        {
            if (await ShowPopUp(page, animate))
            {
                return await Task.Run(() =>
                {
                    return ShowAlert();
                });
            }

            return 0;
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

        private int ShowAlert()
        {
            autoResetEvent.WaitOne();
            CloseAllPopup();

            return selectedOption;
        }

        private void MoveUp()
        {
            selectedOption = -1;
            autoResetEvent.Set();
        }

        private void MoveDown()
        {
            selectedOption = +1;
            autoResetEvent.Set();
        }

        #endregion
    }
}
