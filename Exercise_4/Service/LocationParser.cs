using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class LocationParser
    {
        //TODO:Sprawdzić czy 2 konstruktory są potrzebne
        public static LocationWrapper CreateNewLocationWrapper(string id, string name, string costRate, string availability)
        {
            Location location = new Location
            {
                LocationID = short.Parse(id),
                Name = name,
                Availability = decimal.Parse(availability),
                CostRate = decimal.Parse(costRate),
                ModifiedDate = DateTime.Now
            };

            return new LocationWrapper(location);
        }

        public static LocationWrapper CreateNewLocationWrapper(short id, string name, decimal costRate, decimal availability)
        {
            Location location = new Location
            {
                LocationID = id,
                Name = name,
                Availability = availability,
                CostRate = costRate,
                ModifiedDate = DateTime.Now
            };

            return new LocationWrapper(location);
        }
    }
}
