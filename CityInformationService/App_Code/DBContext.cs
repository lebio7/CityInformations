using CityInformationsEF;
using System;

public class DBContext
{
    private static Lazy<DBOContext> instance = new Lazy<DBOContext>(() => new DBOContext());

    public static DBOContext GetInstance
    {
        get
        {
            return instance.Value;
        }
    }
   
}
