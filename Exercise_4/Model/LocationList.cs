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
        private IDataRepository dataRepository;

        private LocationsModel currentLocation;

        private ObservableCollection<LocationsModel> locations;

        public LocationList()
        {
            this.dataRepository = new DataRepository();
            Locations = new ObservableCollection<LocationsModel>();
            FillLocations();
        }

        //TODO:locations i current jako property?
        public ObservableCollection<LocationsModel> Locations
        {
            get => locations;
            set
            {
                locations = value;
                //NotifyPropertyChanged("Locations");
            }
        }

        public LocationsModel CurrentLocation
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
                locations.Add(new LocationsModel(location.LocationID, location.Name));

            }
        }

        private void DeleteLocation()
        {
            if (currentLocation != null)
            {
                this.dataRepository.DeleteLocation(currentLocation.Id);
                Locations.Remove(currentLocation);
            }
        }


    }
}
