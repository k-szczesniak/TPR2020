using System;

namespace Exercise_1
{
    public class Wykaz
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }

        public Wykaz(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
    }

}
