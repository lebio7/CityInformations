using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class AlertImagePopUpPageViewModel
    {
        #region Members

        private AutoResetEvent autoResetEvent;
        private bool selectedOption;

        #endregion

        #region Properties

        public bool IsCancelEnabled { get; private set; }
        public bool IsShowing { get; private set; }

        public ICommand RightCommand { get; private set; }
        public ICommand LeftCommand { get; private set; }
        public FormattedString TitleToDisplay { get; private set; }
        public string LeftButton { get; private set; }
        public string RightButton { get; private set; }
        public ImageSource ImageToDisplay { get; private set; }
        public bool IsAdditionallData { get; private set; }

        public ObservableCollection<AlertPopUpModel> AdditionallList { get; private set; }

        #endregion

        #region Ctor

        public AlertImagePopUpPageViewModel(string imageToDisplay, FormattedString title, string leftButton, string rightButton, List<(string image, string details)> additionallDetails = null)
        {
            selectedOption = false;
            autoResetEvent = new AutoResetEvent(false);
            TitleToDisplay = title;
            LeftButton = leftButton;
            RightButton = rightButton;

            if (!string.IsNullOrEmpty(imageToDisplay))
            {
                ImageToDisplay = BaseApplication.LoadImage(imageToDisplay);
            }

            RightCommand = new Command(RightClick);
            LeftCommand = new Command(LeftClick);

            IsAdditionallData = additionallDetails != null;
            if(IsAdditionallData)
            {
                AdditionallList = new ObservableCollection<AlertPopUpModel>();
                additionallDetails.ForEach(x =>
                {
                    AdditionallList.Add(new AlertPopUpModel(x.details, BaseApplication.LoadImage(x.image)));
                });
            }
        }

        #endregion

        #region Methods

        public async Task<bool> ShowAlertAsync(PopupPage page, bool animate)
        {
            if (await ShowPopUp(page, animate))
            {
                return await Task.Run(() =>
                {
                    return ShowAlert();
                });
            }

            return false;
        }

        public async void CloseAllPopup(bool animation = true)
        {
            IsShowing = false;
            await PopupNavigation.Instance.PopAllAsync(animate: animation);
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

        private bool ShowAlert()
        {
            autoResetEvent.WaitOne();
            CloseAllPopup();

            return selectedOption;
        }

        private void LeftClick()
        {
            selectedOption = false;
            autoResetEvent.Set();
        }

        private void RightClick()
        {
            selectedOption = true;
            autoResetEvent.Set();
        }

        #endregion
    }
}
