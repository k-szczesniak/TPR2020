using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Service;
using ViewModel;

namespace GUITests
{
    [TestClass]
    public class ViewModelTests
    {
        IDataRepository testDataRepository;
        LocationList locationList;
        MainWindowActions mainWindowActions;

        [TestInitialize]
        public void Initialize()
        {
            testDataRepository = new DataRepositoryForTests();
            locationList = new LocationList(testDataRepository);
            mainWindowActions = new MainWindowActions(locationList);
        }

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
        public void CanExecuteTest()
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
    }
}
