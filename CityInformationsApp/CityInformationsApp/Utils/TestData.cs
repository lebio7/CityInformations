﻿using CityInformationsApp.Models;
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
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
            new NewsModel(title: "Koncert Wielkanocny Dody", address: "Porębska 11", dateEvent: new DateTime(2021, 05, 21, 15, 0, 0).ToString(Constants.DateTimeExtension.DateTimeList, BaseApplication.applicationModel.cultureInfo), DateTime.Now.ToString(Constants.DateTimeExtension.DateTimeCreated), Enums.Events.Culture),
        };

        public static string TestLongDescription = "Wydarzenie jest typu otwarte, oznacza to, że każdy mieszkaniec Miasta, może przyjść i wziąć udział. Wymagany jest strój galowy. Mile widzane pary. Po wydarzeniu, zapraszamy na krótki" +
            "poczęstunek, który przygotowała dla nas pobliska Cukiernia Płomyczek. Bardzo dziękujemy za hojne dary oraz mamy nadzieje na nawiązanie dłuższej współpracy. Zgodnie ze zwyczajem na koniec Proboszcz udzieli wszystkim Błogosławieństwa" +
            "na następne dni tygodnia." +
            "Wydarzenie jest typu otwarte, oznacza to, że każdy mieszkaniec Miasta, może przyjść i wziąć udział. Wymagany jest strój galowy. Mile widzane pary. Po wydarzeniu, zapraszamy na krótki" +
            "poczęstunek, który przygotowała dla nas pobliska Cukiernia Płomyczek. Bardzo dziękujemy za hojne dary oraz mamy nadzieje na nawiązanie dłuższej współpracy. Zgodnie ze zwyczajem na koniec Proboszcz udzieli wszystkim Błogosławieństwa" +
            "na następne dni tygodnia.";

        public static string TitleAbout = "Miejski ośrodek kultury Siewierz";
        public static string Location = "ul. Słowackiego 2a\n42-470 Siewierz";
        public static string Hours = "Dni Tygodnia - 8:30 - 18:00 \nDni wolne - 8:30 - 19:00";
        public static string PhoneNumber = "32 67 41 649";
        public static string Email = "mgcksit@siewierz.pl";

        public static string SiewierzDescriptionAbout = "Siewierz należy do najstarszych grodów w Polsce, jednakże jego początki nie są znane, bowiem nie zachowały się" +
          " dawne dokumenty, zaś dotąd nie przeprowadzono odpowiednich badań archeologicznych. Pierwsza wzmianka historyczna znajduje się w dokumencie legata" +
          " papieskiego Idziego z 1125 r. w którym napisano, iż klasztor Benedyktów w Tyńcu pod Krakowem pobierał część opłat z targu i jatki w Siewierzu. Dalszym dowodem istnienia" +
          " grodu oraz jego funkcji w handlu śląsko-małopolskim jest fakt działalności komory celnej w Siewierzu, z której dochody pobierał konwent norbertanek z Rybnika w 1233 r." +
          " W początkach swego istnienia Siewierz wchodził w skład kasztelanii bytomskiej w granicach ziemi krakowskiej. W 1177 r. Kazimierz Sprawiedliwy podarował Bytom, " +
          "Oświęcim i Siewierz Mieszkowi Plątonogiemu, księciu raciborskiemu. W początkach XIII w. Siewierz był już siedzibą kasztelami, bowiem stare śląskie dokumenty wymieniają" +
          " nazwiska pierwszych kasztelanów: Jaksę i Wawrzyńca. Gród siewierski w tym czasie położony był wokół kościoła św. Jana Chrzciciela, a więc na terenie obecnego cmentarza" +
          " grzebalnego. Prawdopodobnie w 1241 r. po spaleniu grodu przez Tatarów przeniesiono osadę w dolinę Czarnej Przemszy chronioną rzeką i rozległymi bagnami. W 1276 r, Siewierz otrzymał" +
          " prawa miejskie, jednakże nie zachował się dokument lokacyjny. W czasie rozbicia dzielnicowego Siewierz był miejscem znanych bitew. W 1289 r. wojska Władysława Łokietka rozbiły wojska książąt śląskich w walce o tron krakowski" +
          ", a w 1292 r. Wacław II czeski zwyciężył wojska polskie i zajął Kraków. Odrębność terytorialną ziemi siewierskiej po raz pierwszy stwierdzono w dokumencie z 1266 r., wspominającym o districtus severiensis.";

        public static List<CustomPin> TestLocationData = new List<CustomPin>
        {
            new CustomPin (1){Name = "Park Miejski",EnumName = (int)Enums.ObjectLocation.Health, Latitude = 50.475273471298564, Longitude = 19.2369778461592, Address =  "Żwirki i Wigury 26, 42-470 Siewierz", TimeOpenClose = "Pon- Piątek - 8:00 - 16:00, \nsob - ndz 7:00 - 15:00", PhoneNumber = "881-431-121"},
            new CustomPin (2){Name = "Plac Zabaw",EnumName = (int)Enums.ObjectLocation.Sport, Latitude = 50.47534741185839, Longitude = 19.23514549951801, Address =  "Stolarska 2, 42-470 Siewierz", TimeOpenClose = "8:00 - 16:00", PhoneNumber = "881-431-121"},
            new CustomPin (3){Name = "Hotel Natura Residence",EnumName = (int)Enums.ObjectLocation.Accommodation, Latitude = 50.46622341947345, Longitude = 19.202231609038382, Address =  "Sucha 4, 42-470 Siewierz", TimeOpenClose = "8:00 - 17:00", PhoneNumber = "881-431-121"},
            new CustomPin (4){Name = "Ruiny Zamku w Siewierzu" ,EnumName = (int)Enums.ObjectLocation.Sport, Latitude = 50.46747274085934, Longitude = 19.241545498722413, Address =  "Tadeusza Kościuszki, 42-470 Siewierz", TimeOpenClose = "10:00 - 18:00", PhoneNumber = "881-431-121"},
            new CustomPin (5){Name = "Złota Gęś" ,EnumName = (int)Enums.ObjectLocation.Restaurant, Latitude = 50.4667713589257, Longitude = 19.231372606695754, Address =  "Bytomska 59, 42-470 Siewierz", TimeOpenClose = "10:00 - 18:00", PhoneNumber = "881-431-121"},
            new CustomPin (6){Name = "Profesor Burger" ,EnumName = (int)Enums.ObjectLocation.Restaurant, Latitude = 50.467911099284926, Longitude = 19.23050682865093, Address =  "Warszawska 6c, 42-470 Siewierz", TimeOpenClose = "10:00 - 18:00", PhoneNumber = "881-431-121"},
        };
    }
}
