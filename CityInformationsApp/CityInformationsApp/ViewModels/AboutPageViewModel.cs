using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using System.Collections.ObjectModel;

namespace CityInformationsApp.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<CarouselAboutModel> CityImages { get; }

        private string descriptionCity;
        public string DescriptionCity
        {
            get
            {
                return descriptionCity;
            }
            set
            {
                descriptionCity = value;
                OnPropertyChanged();
            }
        }

        private string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged();
            }
        }

        private string hours;
        public string Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
                OnPropertyChanged();
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string titleAbout;
        public string TitleAbout
        {
            get
            {
                return titleAbout;
            }
            set
            {
                titleAbout = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Ctor

        public AboutPageViewModel()
        {
            CityImages = new ObservableCollection<CarouselAboutModel>();
            PrepareData();
        }

        #endregion

        #region Methods

        private void PrepareData()
        {
            LoadCarouselImages();
            LoadDescriptionText();
        }

        private void LoadCarouselImages()
        {
            if (BaseApplication.applicationModel.ImagesToCarouselAboutPage?.Count > 0)
            {
                foreach (string nameImage in BaseApplication.applicationModel.ImagesToCarouselAboutPage)
                {
                    CityImages.Add(new CarouselAboutModel(nameImage));
                }
            }
        }

        private void LoadDescriptionText()
        {
            DescriptionCity = TestData.SiewierzDescriptionAbout;
            TitleAbout = TestData.TitleAbout;
            Location = TestData.Location;
            Hours = TestData.Hours;
            PhoneNumber = TestData.PhoneNumber;
            Email = TestData.Email;
        }

        #endregion
    }
}
