namespace CityInformations.Shared.DTO
{
    public class NewsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public int EventId { get; set; }

        public List<NewsDateDto> Dates { get; set; }
    }
}
