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
        void AddLocation(Location location);

        IEnumerable<Location> GetAllLocations();

        Location GetLocation(int id);

        void UpdateLocation(int id, Location location);

        void DeleteLocation(int id);
    }
}
