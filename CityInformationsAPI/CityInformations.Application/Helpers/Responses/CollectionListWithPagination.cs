namespace CityInformations.Application.Helpers.Responses
{
    public class CollectionListWithPagination<T>
    {
        public IReadOnlyList<T> Results { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public int Total { get; set; }
    }
}
