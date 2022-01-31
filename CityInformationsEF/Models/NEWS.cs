using System;

namespace CityInformationsEF.Models
{
    public class NEWS
    {
        public int NEWSID { get; set; }
        public string TITLE { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public int EVENTID { get; set; }

        public virtual EVENT EVENT { get; set; }
    }
}
