using System;

namespace Exercise_1
{
    public class Event
    {
        public User User { get; set; }
        public State State { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime GiveBackDate { get; set; }

        public Event(User user, State state, DateTime rentalDate, DateTime giveBackDate)
        {
            User = user;
            State = state;
            RentalDate = rentalDate;
            GiveBackDate = giveBackDate;
        }

        //TODO: Dodać toString i equals
        //TODO: Dogadać się jak to ma wyglądać
        //TODO: Przemyśleć identyfikatory
    }
}
