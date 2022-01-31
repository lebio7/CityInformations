using CityInformationsEF;
using System;
using System.Linq;

public class Service : IService
{
    public string GetData(int value)
    {
        return DBContext.GetInstance.Event.FirstOrDefault(x=> x.EVENTID == value).NAME;
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }
}
