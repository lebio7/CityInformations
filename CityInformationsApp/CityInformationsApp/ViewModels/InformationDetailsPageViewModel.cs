using CityInformationsApp.Models;
using CityInformationsApp.Utils;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class InformationDetailsPageViewModel : BaseViewModel
    {
        #region Properties

        private string titleInformation;
        public string TitleInformation
        {
            get
            {
                return titleInformation;
            }
            set
            {
                titleInformation = value;
                OnPropertyChanged();
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        private string dayOfEvent;
        public string DayOfEvent
        {
            get
            {
                return dayOfEvent;
            }
            set
            {
                dayOfEvent = value;
                OnPropertyChanged();
            }
        }

        private ImageSource informationImage;
        public ImageSource InformationImage
        {
            get
            {
                return informationImage;
            }
            set
            {
                informationImage = value;
                OnPropertyChanged();
            }
        }

        public List<InformationDetailsModel> InformationDetails { get; }


        #endregion

        #region Ctor

        public InformationDetailsPageViewModel(string title, string description, Enums.Events eventDetail, List<InformationDetailsModel> informationDetailsModels, string dayOfWeek = null)
        {
            titleInformation = title;
            Description = description;
            InformationImage = Helper.GetImageForEvent(eventDetail);
            DayOfEvent = dayOfWeek;
            InformationDetails = informationDetailsModels?.Count > 0
                ? new List<InformationDetailsModel>(informationDetailsModels)
                : new List<InformationDetailsModel>();
        }

        #endregion
    }
}
