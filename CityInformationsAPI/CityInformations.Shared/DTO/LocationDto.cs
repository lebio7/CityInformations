namespace CityInformations.Shared.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }

        public int ObjectLocationId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ObjectLocationDto ObjectLocation { get; set; }

        public List<LocationDateDto> Dates { get; set; }
    }
}
