namespace CityInformations.Shared.DTO
{
    public class LocationDateDto
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public int TypeDateId { get; set; }

        public string Value { get; set; }

        public TypeDateDto TypeDate { get; set; }
    }
}
