using System;

namespace Exercise_1.Data
{
    public class ReturnEvent : Event
    {
        public ReturnEvent(User user, State state, DateTime date) : base(user, state, date)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is ReturnEvent @event &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return 624022166 + base.GetHashCode();
        }

        public override string ToString()
        {
            return "ReturnEvent{ " + base.ToString() + "}";
        }
    }
}
