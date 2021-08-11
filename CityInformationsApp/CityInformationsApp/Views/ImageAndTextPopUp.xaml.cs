using CityInformationsApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;


namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ImageAndTextPopUp : PopupPage
    {
        private ImageAndTextPopUpViewModel viewModel;

        public ImageAndTextPopUp(string textToDisplay, string imageToDisplay = null, bool imageIsAnimated = false)
        {
            InitializeComponent();

            viewModel = new ImageAndTextPopUpViewModel(textToDisplay, imageToDisplay, imageIsAnimated);
            BindingContext = viewModel;
        }

        #region Show/Close PopUp

        public async Task ShowAlert(bool animate = true)
        {
            await viewModel.ShowPopUp(this, animate);
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