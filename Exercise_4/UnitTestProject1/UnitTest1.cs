using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //TODO: Usunac testy

        [TestMethod]
        public void TestMethod1()
        {
            DataRepository data = new DataRepository();
            Location location;

            location = data.GetLocation(70);
        }

        [TestMethod]
        public void TestMethod2()
        {
            DataRepository data = new DataRepository();
            List<Location> location;

            location = (List<Location>)data.GetAllLocations();
        }

        [TestMethod]
        public void TestMethod3()
        {
            DataRepository data = new DataRepository();

            Location location1 = new Location();
            location1.LocationID = 69;
            location1.Name = "Location";
            location1.ModifiedDate = DateTime.Now;
            location1.Availability = 0.0m;
            location1.CostRate = 0.0m;

            data.AddLocation(location1);
        }


        [TestMethod]
        public void TestMethod4()
        {
            DataRepository data = new DataRepository();
            List<Location> location;

            location = (List<Location>)data.GetAllLocations();
        }
    }
}
