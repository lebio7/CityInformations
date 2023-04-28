using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class NewsDate
    {
        public int Id { get; set; }

        public int NewsId { get; set; }

        public int TypeDateId { get; set; }

        public string Value { get; set; }

        public virtual News News { get; set; }

        public virtual TypeDate TypeDate { get; set; }
    }
}
