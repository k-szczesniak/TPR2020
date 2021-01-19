using System.Collections.Generic;

namespace Service
{
    public interface IDataRepository
    {
        void AddLocation(LocationWrapper location);

        IEnumerable<LocationWrapper> GetAllLocations();

        LocationWrapper GetLocation(int id);

        void UpdateLocation(int id, LocationWrapper location);

        void DeleteLocation(int id);
    }
}
