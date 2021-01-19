using System;

namespace Model
{
    public class LocationModel : PropertyChange
    {
        private short id;
        private string name;
        private decimal costRate;
        private decimal availability;
        private DateTime modifiedDate;

        public LocationModel() { }

        public LocationModel(short locationId, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            this.id = locationId;
            this.name = name;
            this.costRate = costRate;
            this.availability = availability;
            this.modifiedDate = modifiedDate;
        }
        public short Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();

            }
        }
        public decimal CostRate
        {
            get
            {
                return costRate;
            }
            set
            {
                costRate = value;
                OnPropertyChanged();
            }
        }
        public decimal Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
                OnPropertyChanged();
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return modifiedDate;
            }
            set
            {
                modifiedDate = value;
                OnPropertyChanged();
            }
        }
        
    }
}
