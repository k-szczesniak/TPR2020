using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddWindowActions
    {
        private readonly LocationList locationList;

        private LocationsDetail locationToAdd;

        public Binding AddRecord { get; set; }

        public Action CloseWindow { get; set; }

        public AddWindowActions(LocationList locationList)
        {
            this.locationList = locationList;
            locationToAdd = new LocationsDetail();
            this.AddRecord = new Binding(InsertRecord);
        }

        public LocationsDetail LocationToAdd
        {
            get => locationToAdd;
            set
            {
                locationToAdd = value;
                //Notify
            }
        }

        public void InsertRecord()
        {
            locationList.AddLocation(locationToAdd);
            CloseWindow();
        }

    }
}
