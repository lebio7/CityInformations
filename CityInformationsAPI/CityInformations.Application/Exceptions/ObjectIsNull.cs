namespace CityInformations.Application.Exceptions
{
    public class ObjectIsNull : ArgumentException
    {
        public ObjectIsNull() : base("Object is null")
        { }
    }
}
