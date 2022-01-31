namespace CityInformationsApp.Utils
{
    public class Enums
    {
        /// <summary>
        /// event compatible with Event => DBO
        /// </summary>
        public enum Events
        {
            All = 1,
            Culture = 2,
            Sport = 3,
            Tourism = 4,
        }

        /// <summary>
        /// object location compatible with object location => dbo
        /// </summary>
        public enum ObjectLocation
        {
            All = 1,
            Shops = 2,
            Restaurant = 3,
            Health = 4,
            Education = 5,
            Accommodation = 6,
            Sport = 7,
            Monuments = 8, 
        }
    }
}
