using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Service;
using System;
using ViewModel;

namespace GUITests
{
    [TestClass]
    public class ViewModelTests
    {
        IDataRepository testDataRepository;
        LocationList locationList;
        MainWindowActions mainWindowActions;
        AddWindowActions addWindowActions;
        DetailWindowActions detailWindowActions;


        [TestInitialize]
        public void Initialize()
        {
            testDataRepository = new DataRepositoryForTests();
            locationList = new LocationList(testDataRepository);
            mainWindowActions = new MainWindowActions(locationList);
            addWindowActions = new AddWindowActions(locationList);
            detailWindowActions = new DetailWindowActions(locationList);
        }

        #region MainWindow
        [TestMethod]
        public void MainWindowInitializationTest()
        {
            Assert.IsNotNull(mainWindowActions.LocationList);
            Assert.IsNotNull(mainWindowActions.ShowAddWindow);
            Assert.IsNotNull(mainWindowActions.ShowDetailsWindow);
            Assert.IsNotNull(mainWindowActions.DeleteRecord);
            Assert.IsNotNull(mainWindowActions.Refresh);
            Assert.IsNull(mainWindowActions.DetailWindow);
            Assert.IsNull(mainWindowActions.AddWindow);
        }

        [TestMethod]
        public void CanExecuteMainWindowTest()
        {
            Assert.IsTrue(mainWindowActions.ShowAddWindow.CanExecute(null));
            Assert.IsTrue(mainWindowActions.ShowDetailsWindow.CanExecute(null));
            Assert.IsTrue(mainWindowActions.DeleteRecord.CanExecute(null));
            Assert.IsTrue(mainWindowActions.Refresh.CanExecute(null));
        }

        [TestMethod]
        public void DeleteRecordTest()
        {
            locationList.CurrentLocation = locationList.Locations[0];
            int before = locationList.Locations.Count;
            mainWindowActions.DeleteRecord.Execute(null);
            int after = locationList.Locations.Count;
            Assert.AreEqual(before - 1, after);
        }

        [TestMethod]
        public void DeleteRecordFailTest()
        {
            int before = locationList.Locations.Count;
            mainWindowActions.DeleteRecord.Execute(null);
            int after = locationList.Locations.Count;
            Assert.AreEqual(before, after);
        }

        [TestMethod]
        public void RefreshRecordTest()
        {
            int before = mainWindowActions.Locations.Count;
            LocationModel location = new LocationModel(5, "Test6", 1.6m, 6.1m, DateTime.Now);
            locationList.AddLocation(location);
            int after = mainWindowActions.Locations.Count;
            Assert.AreNotEqual(before + 1, after);
            mainWindowActions.Refresh.Execute(null);
            after = mainWindowActions.Locations.Count;
            Assert.AreEqual(before + 1, after);
        }
        #endregion

        #region AddWindow
        [TestMethod]
        public void AddWindowInitializationTest()
        {
            Assert.IsNotNull(addWindowActions.LocationToAdd);
            Assert.IsNotNull(addWindowActions.AddRecord);            
        }

        [TestMethod]
        public void CanExecuteAddWindowTest()
        {
            Assert.IsTrue(addWindowActions.AddRecord.CanExecute(null));
        }

        [TestMethod]
        public void InsertRecordTest()
        {
            int before = locationList.Locations.Count;
            addWindowActions.LocationToAdd = new LocationModel(8, "Location", 1.2m, 1.8m, DateTime.Now);
            addWindowActions.AddRecord.Execute(null);
            locationList.RefreshLocations();
            int after = locationList.Locations.Count;
            Assert.AreEqual(before + 1, after);
        }
        #endregion

        #region DetailWindow
        [TestMethod]
        public void DetailWindowInitializationTest()
        {
            locationList.CurrentLocation = locationList.Locations[0];
            Assert.IsNotNull(detailWindowActions.LocationToEdit);
            Assert.IsNotNull(detailWindowActions.Edit);
        }

        [TestMethod]
        public void CanExecuteDetailWindowTest()
        {
            Assert.IsTrue(detailWindowActions.Edit.CanExecute(null));
        }

        [TestMethod]
        public void EditLocationTest()
        {
            locationList.CurrentLocation = locationList.Locations[0];
            detailWindowActions.LocationToEdit.Name = "Edition";
            detailWindowActions.LocationToEdit.CostRate = 1.5m;
            detailWindowActions.LocationToEdit.Availability = 1.6m;
            detailWindowActions.Edit.Execute(null);
            Assert.AreEqual(locationList.Locations[0].Name, "Edition");
            Assert.AreEqual(locationList.Locations[0].CostRate, 1.5m);
            Assert.AreEqual(locationList.Locations[0].Availability, 1.6m);
        }

        [TestMethod]
        public void EditWhenCurrentLocationIsNullTest()
        {
            Assert.ThrowsException<NullReferenceException>(() => detailWindowActions.LocationToEdit.Name = "Edition");
            Assert.ThrowsException<NullReferenceException>(() => detailWindowActions.LocationToEdit.CostRate = 1.5m);
            Assert.ThrowsException<NullReferenceException>(() => detailWindowActions.LocationToEdit.Availability = 1.6m);
            Assert.IsNull(detailWindowActions.LocationToEdit);
        }

        [TestMethod]
        public void EditLocationWithoutConfirmationTest()
        {
            locationList.CurrentLocation = locationList.Locations[0];
            detailWindowActions.LocationToEdit.Name = "Edition";
            detailWindowActions.LocationToEdit.CostRate = 1.5m;
            detailWindowActions.LocationToEdit.Availability = 1.6m;
            locationList.RefreshLocations();
            Assert.AreNotEqual(locationList.Locations[0].Name, "Edition");
            Assert.AreNotEqual(locationList.Locations[0].CostRate, 1.5m);
            Assert.AreNotEqual(locationList.Locations[0].Availability, 1.6m);
        }
        #endregion
    }
}
