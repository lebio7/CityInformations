namespace CityInformationsEF.Models
{
    public class LOCATIONDATA
    {
        public int LOCATIONDATAID { get; set; }
        public int LOCATIONID { get; set; }
        public int DATATYPEID { get; set; }
        public string VALUE { get; set; }

        public virtual LOCATION LOCATION { get; set; }
        public virtual DATATYPE DATATYPE { get; set; }
    }
}
