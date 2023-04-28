using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public int ObjectLocationId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ObjectLocation ObjectLocation { get; set; }
    }
}
