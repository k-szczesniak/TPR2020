using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Service;
using System;

namespace GUITests
{
    [TestClass]
    public class ModelTests
    {
        IDataRepository testDataRepository;
        LocationList locationList;
        
        [TestInitialize]
        public void Initialize()
        {
            testDataRepository = new DataRepositoryForTests();
            locationList = new LocationList(testDataRepository);
        }

        [TestMethod]
        public void GetLocationTest()
        {
            LocationModel location = locationList.GetLocation(0);
            Assert.AreEqual(location.Id, 0);
            Assert.AreEqual(location.Name, "Test1");
            Assert.AreEqual(location.CostRate, 0.1m);
            Assert.AreEqual(location.Availability, 1.0m);
        }

        [TestMethod]
        public void DeleteLocationTest()
        {
            locationList.CurrentLocation = locationList.Locations[0];
            int before = locationList.Locations.Count;
            locationList.DeleteLocation();
            int after = locationList.Locations.Count;
            Assert.AreEqual(before - 1, after);
        }

        [TestMethod]
        public void AddLocationTest()
        {
            LocationModel location = new LocationModel(5, "Test6", 1.6m, 6.1m, DateTime.Now);
            int before = locationList.Locations.Count;
            locationList.AddLocation(location);
            locationList.RefreshLocations();
            int after = locationList.Locations.Count;
            Assert.AreEqual(before + 1, after);
        }

        [TestMethod]
        public void UpdateLocationTest()
        {
            LocationModel location = new LocationModel(0, "Tset", 1.2m, 2.1m, DateTime.Now);
            locationList.CurrentLocation = location;
            locationList.UpdateLocation();
            locationList.RefreshLocations();
            Assert.AreEqual(location.Id, locationList.Locations[0].Id);
            Assert.AreEqual(location.Name, locationList.Locations[0].Name);
            Assert.AreEqual(location.CostRate, locationList.Locations[0].CostRate);
            Assert.AreEqual(location.Availability, locationList.Locations[0].Availability);
        }
    }
}
