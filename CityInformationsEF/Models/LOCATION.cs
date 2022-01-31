namespace CityInformationsEF.Models
{
    public class LOCATION
    {
        public int LOCATIONID { get; set; }
        public int OBJECTLOCATIONID { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }

        public virtual OBJECTLOCATION OBJECTLOCATION { get; set; }
    }
}
