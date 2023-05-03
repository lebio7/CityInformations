namespace CityInformations.Domain.Exceptions
{
    public class NotFoundExceptionById : NotFoundException
    {
        public NotFoundExceptionById(int id) : base(id) { }
    }
}