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

        public void AddLocation(LocationWrapper locationWrapper)
        {
            Location locationToInsert = locationWrapper.getLocation();
            Task.Run(() =>
            {
                context.Locations.InsertOnSubmit(locationToInsert);
                context.SubmitChanges();
            });
        }

        public void DeleteLocation(int id)
        {
            Task.Run(() =>
            {
                context.Locations.DeleteOnSubmit(GetLocation(id).getLocation());
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            });
        }

        public IEnumerable<LocationWrapper> GetAllLocations()
        {
            List<LocationWrapper> locationWrappers = new List<LocationWrapper>();
            IQueryable<Location> locations = context.Locations;
            foreach (Location location in locations)
            {
                locationWrappers.Add(new LocationWrapper(location));
            }
            return locationWrappers;
        }

        public LocationWrapper GetLocation(int id)
        {
            Location location = context.Locations.Where(l => l.LocationID == id).FirstOrDefault();
            return new LocationWrapper(location);
        }

        public void UpdateLocation(int id, LocationWrapper locationWrapper)
        {
            Task.Run(() =>
            {
                Location updatedLocation = context.Locations.Where(p => p.LocationID == locationWrapper.LocationID).FirstOrDefault();
                foreach (System.Reflection.PropertyInfo property in updatedLocation.GetType().GetProperties())
                {
                    if (property.CanWrite)
                    {
                        property.SetValue(updatedLocation, property.GetValue(locationWrapper.getLocation()));
                    }
                }
                context.SubmitChanges();
            });
        }
    }
}
