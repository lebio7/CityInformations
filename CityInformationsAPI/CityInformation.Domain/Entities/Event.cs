using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
