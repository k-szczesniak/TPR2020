using System;

namespace Exercise_1
{
    class Event
    {
        public string Id { get; set; }
        public User User { get; set; }
        public State State { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime GiveBackDate { get; set; }

        public Event(string id, User user, State state, DateTime rentalDate, DateTime giveBackDate)
        {
            Id = id;
            User = user;
            State = state;
            RentalDate = rentalDate;
            GiveBackDate = giveBackDate;
        }
    }
}
