using CityInformationsApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CityInformationsApp.Utils
{
    public static class Helper
    {
        public static ImageSource GetImageForEvent(Enums.Events selectedEvent)
        {
            switch(selectedEvent)
            {
                case Enums.Events.Culture:
                {
                    return BaseApplication.LoadImage(Constants.EventNames.Culture);
                }
                case Enums.Events.Sport:
                {
                    return BaseApplication.LoadImage(Constants.EventNames.Sports);
                }
                case Enums.Events.Tourism:
                {
                    return BaseApplication.LoadImage(Constants.EventNames.Tourism);
                }
                default:
                {
                    return BaseApplication.LoadImage(Constants.EventNames.Culture);
                }
            }
        }

        public static List<InformationDetailsModel> GenerateInformationDetailsByNewModel(NewsModel news)
        {
            List<InformationDetailsModel> detailsModel = new List<InformationDetailsModel>();
            if (news != null)
            {
                if (!string.IsNullOrEmpty(news.Address))
                {
                    detailsModel.Add(new InformationDetailsModel(Constants.Location, news.Address));
                }

                if (!string.IsNullOrEmpty(news.DateEvent))
                {
                    detailsModel.Add(new InformationDetailsModel(Constants.Calendar, news.DateEvent));
                }

                if (!string.IsNullOrEmpty(news.Price))
                {
                    detailsModel.Add(new InformationDetailsModel(Constants.Price, news.Price));
                }

                if (news.AdditionalDetails?.Count > 0)
                {
                    foreach(string text in news.AdditionalDetails)
                    {
                        detailsModel.Add(new InformationDetailsModel(Constants.DetailDot, text));
                    }
                }

            }

            return detailsModel;
        }

        public static string GetDayNameByDateText(string date)
        {
            try
            {
                DateTime time =  DateTime.ParseExact(date, Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo);
                if (time != null)
                {
                   return time.ToString(Constants.DateTimeExtension.Day, BaseApplication.applicationModel.cultureInfo);
                }

                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
