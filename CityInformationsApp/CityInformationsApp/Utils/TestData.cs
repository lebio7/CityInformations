using CityInformationsApp.Models;
using System;
using System.Collections.Generic;

namespace CityInformationsApp.Utils
{
    public static class TestData
    {
        public static List<NewsModel> TestNewsList = new List<NewsModel>
        {
            new NewsModel("Koncert Dody", "Koncert Dody odbędzie sie na dożynkach na boisku sportowym imienia Jana Dworianka, ", BaseApplication.LoadImage("DefaultImage"), DateTime.Now.ToString(Constants.DateTimeExtenstion)),
            new NewsModel("Konferencja Biznesu", "Konferencja biznesu zaplanowana na dzień 27.04 przeniesiona została na 29.04. Godzina bez zmian...", BaseApplication.LoadImage("DefaultImage"), DateTime.Now.ToString(Constants.DateTimeExtenstion)),
            new NewsModel("Konferencja Biznesu", "Konferencja biznesu zaplanowana na dzień 27.04 przeniesiona została na 29.04. Godzina bez zmian...", BaseApplication.LoadImage("DefaultImage"), DateTime.Now.ToString(Constants.DateTimeExtenstion)),
            new NewsModel("Konferencja Biznesu", "Konferencja biznesu zaplanowana na dzień 27.04 przeniesiona została na 29.04. Godzina bez zmian...", BaseApplication.LoadImage("DefaultImage"), DateTime.Now.ToString(Constants.DateTimeExtenstion)),
            new NewsModel("Konferencja Biznesu", "Konferencja biznesu zaplanowana na dzień 27.04 przeniesiona została na 29.04. Godzina bez zmian...", BaseApplication.LoadImage("DefaultImage"), DateTime.Now.ToString(Constants.DateTimeExtenstion)),
        };
    }
}
