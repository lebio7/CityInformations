using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using CityInformationsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class AnnouncementsPageViewModel : BaseViewModel
    {
        #region Members 

        private List<NewsModel> allItemsList;

        #endregion

        #region Properties

        private ObservableCollection<NewsModel> newsList;

        public ObservableCollection<NewsModel> NewsList
        {
            get
            {
                return newsList;
            }
            set
            {
                newsList = value;
                OnPropertyChanged();
            }
        }

        public SortButtonBuilder SortButtonBuilder { get; private set; }

        #endregion

        #region Ctor

        public AnnouncementsPageViewModel()
        {
            allItemsList = new List<NewsModel>();
            NewsList = new ObservableCollection<NewsModel>();
            SortButtonBuilder = new SortButtonBuilder(SortByEventButton);
            PrepareData();
        }

        #endregion

        #region Methods

        private void PrepareData()
        {
            SortButtonBuilder.AddButtonsByEvents((Enums.Events[])Enum.GetValues(typeof(Enums.Events)));
            LoadNewsCollection();
        }

        private void LoadNewsCollection()
        {
            foreach (NewsModel news in TestData.TestNewsList)
            {
                allItemsList.Add(news);
                news.ReadMore = new Command<object>(GoToReadMore);
            }
        }

        private void SortByEventButton(int nameEnums)
        {
            Enums.Events eventName = (Enums.Events)nameEnums;
            if (eventName == Enums.Events.All)
            {
                NewsList = new ObservableCollection<NewsModel>(allItemsList);
            }
            else
            {
                NewsList = new ObservableCollection<NewsModel>(allItemsList.Where(x => x.SelectedEvent == eventName));
            }
        }


        private async void GoToReadMore(object selectedItem)
        {
            if (selectedItem is NewsModel news)
            {
                InformationDetailsPage page = new InformationDetailsPage(news.Title, TestData.TestLongDescription, news.SelectedEvent, Helper.GenerateInformationDetailsByNewModel(news), dayOfWeek: Helper.GetDayNameByDateText(news.DateEvent));
                await Shell.Current.Navigation.PushModalAsync(page);
            }
        }

        #endregion
    }
}
