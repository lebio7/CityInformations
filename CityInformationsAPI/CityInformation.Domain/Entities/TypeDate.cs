using System.ComponentModel.DataAnnotations.Schema;

namespace CityInformations.Domain.Entities
{
    public class TypeDate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdDescr { get; set; }

        public virtual List<Descr> Descr { get; set; }
    }
}
