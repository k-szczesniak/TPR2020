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

        public Binding ShowAddWindow { get; set; }

        public Binding ShowDetailsWindow { get; set; }

        public Binding DeleteRecord { get; set; }

        public Binding Refresh { get; set; }

        public Lazy<IWindow> AddWindow { get; set; }

        public Lazy<IWindow> DetailWindow { get; set; }

        public IWindowResolver WindowDetailResolver { get; set; }
        public IWindowResolver WindowAddResolver { get; set; }


        public MainWindowActions()
        {
            LocationList = new LocationList();
            //locations = LocationList.Locations;
            this.ShowAddWindow = new Binding(DisplayAddWindow);
            this.ShowDetailsWindow = new Binding(DisplayDetailsWindow);
            this.DeleteRecord = new Binding(DeleteLocation);
            this.Refresh = new Binding(RefreshList);
        }

        public ObservableCollection<LocationsDetail> Locations
        {
            get => LocationList.Locations;
            set
            {
                LocationList.Locations = value;
                //NotifyPropertyChanged("Locations");
            }
        }

        public LocationsDetail CurrentLocation
        {
            get => LocationList.CurrentLocation;
            set
            {
                LocationList.CurrentLocation = value;
                //NotifyPropertyChanged("CurrentLocation");
            }
        }

        private void DisplayAddWindow()
        {
            AddWindowActions addWindowActions = new AddWindowActions(this.LocationList);
            IOperationWindow window = WindowAddResolver.GetWindow();
            window.BindViewModel(addWindowActions);
            window.Show();


            //IWindow _child = AddWindow.Value;
            //_child.Show();
        }

        private void RefreshList()
        {
            LocationList.RefreshLocations();
        }

        private void DisplayDetailsWindow()
        {

            if (CurrentLocation != null)
            {
                DetailWindowActions detailWindowActions = new DetailWindowActions(this.LocationList);
                IOperationWindow window = WindowDetailResolver.GetWindow();
                window.BindViewModel(detailWindowActions);
                window.Show();


                //IWindow _child = DetailWindow.Value;
                //_child.Show();
            }
        }

        private void DeleteLocation()
        {
            LocationList.DeleteLocation();
        }
    }
}
