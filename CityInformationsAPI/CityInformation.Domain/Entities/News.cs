using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public List<NewsDate> NewsDates { get; set; }
    }
}
