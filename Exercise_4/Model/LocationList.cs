using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LocationList
    {
        private readonly IDataRepository dataRepository;

        private LocationsDetail currentLocation;

        private ObservableCollection<LocationsDetail> locations;

        public LocationList()
        {
            this.dataRepository = new DataRepository();
            Locations = new ObservableCollection<LocationsDetail>();
            FillLocations();
        }

        public ObservableCollection<LocationsDetail> Locations
        {
            get => locations;
            set
            {
                locations = value;
                //NotifyPropertyChanged("Locations");
            }
        }

        public LocationsDetail CurrentLocation
        {
            get => currentLocation;
            set
            {
                currentLocation = value;
                //NotifyPropertyChanged("CurrentLocation");
            }
        }

        private void FillLocations()
        {
            IEnumerable<LocationWrapper> listFromService = dataRepository.GetAllLocations();
            foreach (LocationWrapper location in listFromService)
            {
                locations.Add(new LocationsDetail(location.LocationID, location.Name, location.CostRate, location.Availability, location.ModifiedDate));

            }
        }

        public void RefreshLocations()
        {
            Locations.Clear();
            FillLocations();
        }

        public void DeleteLocation()
        {
            if (currentLocation != null)
            {
                this.dataRepository.DeleteLocation(currentLocation.Id);
                Locations.Remove(currentLocation);
            }
        }

        public void AddLocation(LocationsDetail location)
        {
            this.dataRepository.AddLocation(LocationParser.CreateNewLocationWrapper(location.Id, location.Name, location.CostRate, location.Availability));
            Locations.Add(location);

        }

        public LocationsDetail GetLocation(short locationId)
        {
            LocationWrapper tempLocation = this.dataRepository.GetLocation(locationId);
            return new LocationsDetail(tempLocation.LocationID, tempLocation.Name, tempLocation.CostRate, tempLocation.Availability, tempLocation.ModifiedDate);
        }

        public void UpdateLocation()
        {
            this.dataRepository.UpdateLocation(currentLocation.Id, LocationParser.CreateNewLocationWrapper(currentLocation.Id, currentLocation.Name, currentLocation.CostRate, currentLocation.Availability));
        }
    }
}
