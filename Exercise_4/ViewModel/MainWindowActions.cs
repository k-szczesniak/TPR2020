using Model;
using System;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class MainWindowActions
    {
        public LocationList LocationList { get; set; }

        public Binding ShowAddWindow { get; set; }

        public Binding ShowDetailsWindow { get; set; }

        public Binding DeleteRecord { get; set; }

        public Binding Refresh { get; set; }

        public Lazy<IOperationWindow> DetailWindow { get; set; }

        public Lazy<IOperationWindow> AddWindow { get; set; }

        public MainWindowActions() : this(new LocationList()) { }

        public MainWindowActions(LocationList locationList)
        {
            LocationList = locationList;
            this.ShowAddWindow = new Binding(DisplayAddWindow);
            this.ShowDetailsWindow = new Binding(DisplayDetailsWindow);
            this.DeleteRecord = new Binding(DeleteLocation);
            this.Refresh = new Binding(RefreshList);
        }

        public ObservableCollection<LocationModel> Locations
        {
            get => LocationList.Locations;
            set
            {
                LocationList.Locations = value;
            }
        }

        public LocationModel CurrentLocation
        {
            get => LocationList.CurrentLocation;
            set
            {
                LocationList.CurrentLocation = value;
            }
        }

        private void DisplayAddWindow()
        {
            AddWindowActions addWindowActions = new AddWindowActions(this.LocationList);
            IOperationWindow window = AddWindow.Value;
            window.BindViewModel(addWindowActions);
            window.Show();
        }

        private void DisplayDetailsWindow()
        {
            if (CurrentLocation != null)
            {
                DetailWindowActions detailWindowActions = new DetailWindowActions(this.LocationList);
                IOperationWindow window = DetailWindow.Value;
                window.BindViewModel(detailWindowActions);
                window.Show();
            }
        }

        private void DeleteLocation()
        {
            LocationList.DeleteLocation();
        }

        private void RefreshList()
        {
            LocationList.RefreshLocations();
        }
    }
}
