namespace CityInformations.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int? id) : base($"Item not found {id?.ToString() ?? string.Empty}")
        {

        }
    }
}