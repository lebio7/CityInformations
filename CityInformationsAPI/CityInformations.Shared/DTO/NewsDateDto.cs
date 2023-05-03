namespace CityInformations.Shared.DTO
{
    public class NewsDateDto
    {
        public int Id { get; set; }

        public int NewsId { get; set; }

        public int TypeDateId { get; set; }

        public string Value { get; set; }

        public TypeDateDto TypeDate { get; set; }
    }
}
