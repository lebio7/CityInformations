using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class Descr
    {
        public int Id { get; set; }

        public int MainDescrId { get; set; }

        public string Description { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
    }
}
