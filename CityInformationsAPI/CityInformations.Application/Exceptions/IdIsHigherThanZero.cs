namespace CityInformations.Application.Exceptions
{
    public class IdIsHigherThanZero : ArgumentException
    {
        public IdIsHigherThanZero() : base("Given Id is higher than 0")
        { }
    }
}
