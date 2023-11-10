namespace CityInformations.Application.Exceptions
{
    public class IdIsHigherThanZero : Exception
    {
        public IdIsHigherThanZero() : base("Given Id is higher than 0")
        { }
    }
}
