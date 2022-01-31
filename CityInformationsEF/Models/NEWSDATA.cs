namespace CityInformationsEF.Models
{
    public class NEWSDATA
    {
        public int NEWSDATAID { get; set; }
        public int NEWSID { get; set; }
        public int DATATYPEID { get; set; }
        public string VALUE { get; set; }

        public virtual NEWS NEWS { get; set; }
        public virtual DATATYPE DATATYPE { get; set; }
    }
}
