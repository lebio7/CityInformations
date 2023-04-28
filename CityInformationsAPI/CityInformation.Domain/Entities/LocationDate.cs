using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class LocationDate
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public int TypeDateId { get; set; }

        public string Value { get; set; }

        public virtual Location Location { get; set; }

        public virtual TypeDate TypeDate { get; set; }
    }
}
