using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class Event
    {
        public User User { get; set; }
        public State State { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime GiveBackDate { get; set; }
    }
}
