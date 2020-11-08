using System;
using System.Collections.Generic;

namespace Exercise_1
{
    public abstract class Event
    {
        public User User { get; set; }
        public State State { get; set; }
        public DateTime Date { get; set; }

        public Event(User user, State state, DateTime date)
        {
            User = user;
            State = state;
            Date = date;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   EqualityComparer<User>.Default.Equals(User, @event.User) &&
                   EqualityComparer<State>.Default.Equals(State, @event.State) &&
                   Date == @event.Date;
        }

        public override int GetHashCode()
        {
            int hashCode = 1582712241;
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<State>.Default.GetHashCode(State);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Event{User: " + User + ", State: " + State + ", Date: " + Date + "}";
        }

        //TODO: Sprawdzić toString i equals
    }
}
