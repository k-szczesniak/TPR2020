using Model;

namespace ViewModel
{
    public class AddWindowActions
    {
        private readonly LocationList locationList;

        private LocationModel locationToAdd;

        public Binding AddRecord { get; set; }

        public AddWindowActions() : this(new LocationList()) { }        

        public AddWindowActions(LocationList locationList)
        {
            this.locationList = locationList;
            locationToAdd = new LocationModel();
            this.AddRecord = new Binding(InsertRecord);
        }

        public LocationModel LocationToAdd
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
