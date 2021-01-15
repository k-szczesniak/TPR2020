﻿using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public class LocationList : PropertyChange
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
                OnPropertyChanged();
            }
        }

        public LocationsDetail CurrentLocation
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
        }

        public LocationsDetail GetLocation(short locationId)
        {
            LocationWrapper tempLocation = this.dataRepository.GetLocation(locationId);
            return new LocationsDetail(tempLocation.LocationID, tempLocation.Name, tempLocation.CostRate, tempLocation.Availability, tempLocation.ModifiedDate);
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
