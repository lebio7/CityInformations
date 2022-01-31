namespace CityInformationsEF.Models
{
    public class DATA
    {
        public int DATAID { get; set; }
        public int DATATYPEID { get; set; }
        public string VALUE { get; set; }

        public virtual DATATYPE DATATYPE { get; set; }

    }
}
