namespace CityInformationsApp.Utils
{
    public static class Constants
    {
        public const string FolderImages = "Resources.Images";
        public const string ProjectName = "CityInformationsApp";
        public const string PngExtension = "png";
      
        public const string Siewierz = nameof(Siewierz);
        public const string Location = nameof(Location);
        public const string GoNext = nameof(GoNext);
        public const string Calendar = nameof(Calendar);
        public const string Price = nameof(Price);
        public const string DetailDot = nameof(DetailDot);

        public class DateTimeExtension
        {
            public const string DateTimeCreated = "yyyy-MM-dd hh:mm";
            public const string DateTimeList = "dd.MM.yyyy HH:mm";
            public const string Day = "dddd";
        }
        public class PageNames
        {
            public const string InformationDetails = "Szczegóły";
        }

        public class EventNames
        {
            public const string Culture = nameof(Culture);
            public const string Sports = nameof(Sports);
            public const string Tourism = nameof(Tourism);
        }

        public class Extensions
        {
            public const string Zlotych = ".zł";
            public const string Street = "ul.";
        }
    }
}
