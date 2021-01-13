using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
