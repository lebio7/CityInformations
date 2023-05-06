namespace CityInformations.Domain.Entities
{
    public class Weather
    {
        public int Id { get; set; }

        public float? Temperature { get; set; }

        public int? Pressure { get; set; }

        public string? Icon { get; set; }

        public DateTime? AddedDate { get; set; }
    }
}
