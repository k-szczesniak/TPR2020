using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   EqualityComparer<User>.Default.Equals(User, @event.User) &&
                   EqualityComparer<State>.Default.Equals(State, @event.State) &&
                   RentalDate == @event.RentalDate &&
                   GiveBackDate == @event.GiveBackDate;
        }

        public override int GetHashCode()
        {
            int hashCode = 770629798;
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<State>.Default.GetHashCode(State);
            hashCode = hashCode * -1521134295 + RentalDate.GetHashCode();
            hashCode = hashCode * -1521134295 + GiveBackDate.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Event{User: " + User + ", State: " + State + ", RentalDate: " + RentalDate + ", GiveBackDate: " + GiveBackDate + "}";
        }


        //TODO: Sprawdzić toString i equals
    }
}
