using CityInformationsApp.Models;
using System;
using System.Collections.Generic;

namespace CityInformationsApp.Utils
{
    public static class TestData
    {
        public static List<NewsModel> TestNewsList = new List<NewsModel>
        {
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 30,0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Sport, additionalDetails: new List<string>{ "Impreza od lat 12", "Dzieci pod opieką dorosłego"}),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Tourism),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
        };

        public static string TestLongDescription = "Wydarzenie jest typu otwarte, oznacza to, że każdy mieszkaniec Miasta, może przyjść i wziąć udział. Wymagany jest strój galowy. Mile widzane pary. Po wydarzeniu, zapraszamy na krótki" +
            "poczęstunek, który przygotowała dla nas pobliska Cukiernia Płomyczek. Bardzo dziękujemy za hojne dary oraz mamy nadzieje na nawiązanie dłuższej współpracy. Zgodnie ze zwyczajem na koniec Proboszcz udzieli wszystkim Błogosławieństwa" +
            "na następne dni tygodnia." +
            "Wydarzenie jest typu otwarte, oznacza to, że każdy mieszkaniec Miasta, może przyjść i wziąć udział. Wymagany jest strój galowy. Mile widzane pary. Po wydarzeniu, zapraszamy na krótki" +
            "poczęstunek, który przygotowała dla nas pobliska Cukiernia Płomyczek. Bardzo dziękujemy za hojne dary oraz mamy nadzieje na nawiązanie dłuższej współpracy. Zgodnie ze zwyczajem na koniec Proboszcz udzieli wszystkim Błogosławieństwa" +
            "na następne dni tygodnia.";

        public static List<InformationDetailsModel> testDetails = new List<InformationDetailsModel>
        {
            new InformationDetailsModel("Godzina rozpoczęcia:", new DateTime(2021, 04, 22, 15, 30, 10).ToString(Constants.DateTimeExtension.DateTimeCreated)),
            new InformationDetailsModel("Cena:", "Za darmo"),
            new InformationDetailsModel("Miejsce:", "Boisko sportowe"),
            new InformationDetailsModel("Strój obowiązujący na wydarzenie:", "Galowy(czytaj, nie dres sportowy, jeansy, buty halówki, trampki, korki) wymagane buty garnituowe"),
        };
    }
}
