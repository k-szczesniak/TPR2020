using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class CheckoutEvent : Event
    {
        public CheckoutEvent(User user, State state, DateTime date) : base(user, state, date)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is CheckoutEvent @event &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return 624022166 + base.GetHashCode();
        }

        public override string ToString()
        {
            return "CheckoutEvent{ " + base.ToString() + " }";
        }
    }
}
