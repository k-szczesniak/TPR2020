using Model;

namespace ViewModel
{
    public class DetailWindowActions
    {
        private readonly LocationList locationList;

        public Binding Edit { get; private set; }

        public DetailWindowActions() : this(new LocationList()) { }

        public DetailWindowActions(LocationList locationList)
        {
            this.Edit = new Binding(EditLocation);
            this.locationList = locationList;
        }

        public LocationModel LocationToEdit
        {
            get => locationList.CurrentLocation;
            set
            {
                locationList.CurrentLocation = value;
            }
        }

        public void EditLocation()
        {
            locationList.UpdateLocation();
        }
    }
}
