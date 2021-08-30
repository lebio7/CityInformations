using CityInformationsApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace CityInformationsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoveElementPopUpPage : PopupPage
    {
        private MoveElementPopUpViewModel viewModel;

        public MoveElementPopUpPage()
        {
            InitializeComponent();

            viewModel = new MoveElementPopUpViewModel();
            BindingContext = viewModel;
        }

        #region Show/Close PopUp

        public async Task<int> ShowAlert(bool animate = true)
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