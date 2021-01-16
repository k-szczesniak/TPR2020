using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public class LocationList : PropertyChange
    {
        private readonly IDataRepository dataRepository;

        private LocationModel currentLocation;

        private ObservableCollection<LocationModel> locations;

        public LocationList() : this(new DataRepository()) { }

        public LocationList(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
            Locations = new ObservableCollection<LocationModel>();
            FillLocations();
        }

        public ObservableCollection<LocationModel> Locations
        {
            get => locations;
            set
            {
                locations = value;
                OnPropertyChanged();
            }
        }

        public LocationModel CurrentLocation
        {
            get => currentLocation;
            set
            {
                currentLocation = value;
                OnPropertyChanged();
            }
        }

        private void FillLocations()
        {
            IEnumerable<LocationWrapper> listFromService = dataRepository.GetAllLocations();
            foreach (LocationWrapper location in listFromService)
            {
                locations.Add(new LocationModel(location.LocationID, location.Name, location.CostRate, location.Availability, location.ModifiedDate));
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

        public void AddLocation(LocationModel location)
        {
            this.dataRepository.AddLocation(LocationParser.CreateNewLocationWrapper(location.Id, location.Name, location.CostRate, location.Availability));
        }

        public LocationModel GetLocation(short locationId)
        {
            LocationWrapper tempLocation = this.dataRepository.GetLocation(locationId);
            return new LocationModel(tempLocation.LocationID, tempLocation.Name, tempLocation.CostRate, tempLocation.Availability, tempLocation.ModifiedDate);
        }

        public void UpdateLocation()
        {
            if (currentLocation != null)
            {
                this.dataRepository.UpdateLocation(currentLocation.Id, LocationParser.CreateNewLocationWrapper(currentLocation.Id, currentLocation.Name, currentLocation.CostRate, currentLocation.Availability));
            }
        }
    }
}
