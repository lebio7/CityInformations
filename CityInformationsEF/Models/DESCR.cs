using System.ComponentModel.DataAnnotations;

namespace CityInformationsEF.Models
{
    public class DESCR
    {
        public int DESCRID { get; set; }
        public int MAINDESCRID { get; set; }
        public string DESCRIPTION { get; set; }
        public int LANGUAGEID { get; set; }

        public virtual LANGUAGE LANGUAGE { get; set; }
    }
}
