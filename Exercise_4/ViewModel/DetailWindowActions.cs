using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DetailWindowActions : IViewModel 
    {
        private readonly LocationList locationList;

        public Binding Edit { get; private set; }


        //TODO: Zastanowić się nad tym
        public Action CloseWindow { get; set; }

        public DetailWindowActions() : this(new LocationList()) { }

        public DetailWindowActions(LocationList locationList)
        {
            this.Edit = new Binding(EditLocation);
            this.locationList = locationList;
        }

        public LocationsDetail LocationToEdit
        {
            get => locationList.CurrentLocation;
            set
            {
                locationList.CurrentLocation = value;
                //Notify
            }
        }

        public void EditLocation()
        {
            locationList.UpdateLocation();
            CloseWindow();
        }


    }
}
