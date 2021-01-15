﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DetailWindowActions
    {
        private readonly LocationList locationList;

        public Binding Edit { get; private set; }

        public DetailWindowActions()
        {
            this.Edit = new Binding(EditLocation);
            this.locationList = new LocationList();
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
        }

    }
}
