using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainWindowActions
    {
        public LocationList LocationList { get; set; }

        private ObservableCollection<LocationsModel> locations;

        private LocationsModel currentLocation;

        public MainWindowActions()
        {
            LocationList = new LocationList();
            locations = LocationList.Locations;
        }

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

       
    }
}
