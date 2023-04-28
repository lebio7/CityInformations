using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class Date
    {
        public int Id { get; set; }

        public int TypeDateId { get; set; }

        public string Value { get; set; }

        public virtual TypeDate TypeDate { get; set; }
    }
}
