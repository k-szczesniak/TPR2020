using Service;
using System.Collections.Generic;

namespace GUITests
{
    class DataRepositoryForTests : IDataRepository
    {
        List<LocationWrapper> testList;

        public DataRepositoryForTests()
        {
            testList = InitTestList();
        }

        public void AddLocation(LocationWrapper location)
        {
            testList.Add(location);
        }

        public void DeleteLocation(int id)
        {
            testList.RemoveAt(id);
        }

        public IEnumerable<LocationWrapper> GetAllLocations()
        {
            return testList;
        }

        public LocationWrapper GetLocation(int id)
        {
            return testList[id];
        }

        public void UpdateLocation(int id, LocationWrapper location)
        {
            testList[id] = location;
        }

        private List<LocationWrapper> InitTestList()
        {
            List<LocationWrapper> initList = new List<LocationWrapper>
            {
                LocationParser.CreateNewLocationWrapper(0, "Test1", 0.1m, 1.0m),
                LocationParser.CreateNewLocationWrapper(1, "Test2", 1.1m, 1.1m),
                LocationParser.CreateNewLocationWrapper(2, "Test3", 2.1m, 1.2m),
                LocationParser.CreateNewLocationWrapper(3, "Test4", 3.1m, 1.3m),
                LocationParser.CreateNewLocationWrapper(4, "Test5", 4.1m, 1.4m)
            };
            return initList;
        }
    }
}
