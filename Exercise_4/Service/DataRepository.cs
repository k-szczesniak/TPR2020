using Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class DataRepository : IDataRepository
    {
        private LocationDataContext context;

        public DataRepository()
        {
            this.context = new LocationDataContext();
        }

        public void AddLocation(Location location)
        {
            Task.Run(() =>
            {
                context.Locations.InsertOnSubmit(location);
                context.SubmitChanges();
            });
        }

        public void DeleteLocation(int id)
        {
            Task.Run(() =>
            {
                context.Locations.DeleteOnSubmit(GetLocation(id));
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            });
        }

        public IEnumerable<Location> GetAllLocations()
        {
            IQueryable<Location> locations = context.Locations;
            return locations.ToList();
        }

        public Location GetLocation(int id)
        {
            return context.Locations.Where(l => l.LocationID == id).FirstOrDefault();
        }

        public void UpdateLocation(int id, Location location)
        {
            Task.Run(() =>
            {
                Location updatedLocation = context.Locations.Where(p => p.LocationID == location.LocationID).FirstOrDefault();
                foreach (System.Reflection.PropertyInfo property in updatedLocation.GetType().GetProperties())
                {
                    if (property.CanWrite)
                    {
                        property.SetValue(updatedLocation, property.GetValue(location));
                    }
                }
                context.SubmitChanges();
            });
        }
    }
}
