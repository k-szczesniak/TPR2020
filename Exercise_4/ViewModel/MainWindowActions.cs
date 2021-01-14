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

        private ObservableCollection<LocationsDetail> locations;

        private LocationsDetail currentLocation;

        public Binding ShowAddWindow { get; set; }

        public Binding ShowDetailsWindow { get; set; }

        public Binding DeleteRecord { get; set; }

        public Binding Refresh { get; set; }

        public Lazy<IWindow> ChildWindow { get; set; }

        public MainWindowActions()
        {
            LocationList = new LocationList();
            locations = LocationList.Locations;
            this.ShowAddWindow = new Binding(DisplayAddWindow);
            this.ShowDetailsWindow = new Binding(DisplayDetailsWindow);
            this.DeleteRecord = new Binding(DeleteLocation);
            this.Refresh = new Binding(RefreshList);
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

        private void DisplayAddWindow()
        {
            IWindow _child = ChildWindow.Value;
            _child.Show();

        }

        private void RefreshList()
        {
            LocationList.Locations.Clear();
            LocationList.FillLocations();
        }

        private void DisplayDetailsWindow()
        {

        }

        private void DeleteLocation()
        {

        }





    }
}
