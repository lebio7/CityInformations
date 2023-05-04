namespace CityInformations.Shared.DTO
{
    public class DateDto
    {
        public int Id { get; set; }

        public int TypeDateId { get; set; }

        public string Value { get; set; }

        public TypeDateDto TypeDate { get; set; }
    }
}
