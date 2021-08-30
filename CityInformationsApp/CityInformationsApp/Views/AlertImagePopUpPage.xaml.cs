using CityInformationsApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertImagePopUpPage : PopupPage
    {
        private AlertImagePopUpPageViewModel viewModel;

        public AlertImagePopUpPage(string imageToDisplay, FormattedString title, string leftButton, string rightButton, List<(string image, string details)> additionallDetails = null)
        {
            InitializeComponent();

            viewModel = new AlertImagePopUpPageViewModel(imageToDisplay, title, leftButton, rightButton, additionallDetails);
            BindingContext = viewModel;
        }

        #region Show/Close PopUp

        public async Task<bool> ShowAlert(bool animate = true)
        {
           return await viewModel.ShowAlertAsync(this, animate);
        }

        public void CloseAllPopup(bool animation = true)
        {
            viewModel?.CloseAllPopup();
        }

        #endregion

        #region Override

        protected override bool OnBackButtonPressed()
        {
            if (!viewModel.IsCancelEnabled)
            {
                return true;
            }

            return false;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        #endregion
    }
}