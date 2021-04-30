using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<NewsModel> NewsList { get; }

        private ImageSource logoCity;
        public ImageSource LogoCity
        {
            get
            {
                return logoCity;
            }
            set
            {
                logoCity = value;
                OnPropertyChanged();
            }
        }


        private ImageSource randomImage;
        public ImageSource RandomImage
        {
            get
            {
                return randomImage;
            }
            set
            {
                randomImage = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Ctor

        public HomePageViewModel()
        {
            NewsList = new ObservableCollection<NewsModel>();

            PrepareData();
        }

        #endregion

        #region Methods

        private void PrepareData()
        {
            LoadLogoCity();
            RandDefaultImage();
            LoadNewsCollection();
        }

        private void LoadLogoCity()
        {
            LogoCity = BaseApplication.LoadImage(BaseApplication.applicationModel.LogoName);
        }

        private void RandDefaultImage()
        {
            Random generator = new Random();

            if (BaseApplication.applicationModel.ImagesToRandInHomePage?.Count > 0)
            {
                int randIndex = generator.Next(0, BaseApplication.applicationModel.ImagesToRandInHomePage.Count);

                string loadedImage = BaseApplication.applicationModel.ImagesToRandInHomePage[randIndex] != null
                    ? BaseApplication.applicationModel.ImagesToRandInHomePage[randIndex]
                    : BaseApplication.applicationModel.ImagesToRandInHomePage.FirstOrDefault();

                if (!string.IsNullOrEmpty(loadedImage))
                {
                    RandomImage = BaseApplication.LoadImage(loadedImage);
                }
            }
        }

        private void LoadNewsCollection()
        {
            foreach (NewsModel news in TestData.TestNewsList)
            {
                NewsList.Add(news);
                news.ReadMore = new Command(GoToReadMore);
            }

        }

        private void GoToReadMore()
        {
            //ToDo przejscie do InformationDetailsView 
        }

        #endregion
    }
}
