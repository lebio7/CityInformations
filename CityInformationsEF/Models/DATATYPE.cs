using System.Collections.Generic;

namespace CityInformationsEF.Models
{
    public class DATATYPE
    {
        public int DATATYPEID { get; set; }
        public string NAME { get; set; }
        public int IDDESCR { get; set; }

        public virtual List<DESCR> DESCRS { get; set; }
    }
}
