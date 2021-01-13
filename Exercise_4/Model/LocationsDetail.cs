using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LocationsDetail
    {
        private short id;
        private string name;
        private decimal costRate;
        private decimal availability;
        private DateTime modifiedDate;

        public LocationsDetail() { }

        public LocationsDetail(short locationId, string name, decimal costRate, decimal availability, DateTime modifiedDate)
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
                //NotifyPropertyChanged("Id");
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
                //NotifyPropertyChanged("Name");
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
                //NotifyPropertyChanged("CostRate");
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
                //NotifyPropertyChanged("Availability");
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
                //NotifyPropertyChanged("ModifiedDate");
            }
        }
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
