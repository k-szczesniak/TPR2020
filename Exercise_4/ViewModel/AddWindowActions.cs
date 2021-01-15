using Model;

namespace ViewModel
{
    public class AddWindowActions
    {
        private readonly LocationList locationList;

        private LocationsDetail locationToAdd;

        public Binding AddRecord { get; set; }

        public AddWindowActions() : this(new LocationList()) { }        

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
            }
        }

        public void InsertRecord()
        {
            locationList.AddLocation(locationToAdd);
        }

    }
}
