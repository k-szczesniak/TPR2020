using System.Collections.Generic;

namespace Exercise_1
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName;
        }

        public override int GetHashCode()
        {
            int hashCode = 1938039292;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            return hashCode;
        }

        public override string ToString()
        {
            return "User{First name: " + FirstName + ", Last name: " + LastName + "}";
        }

        //TODO: Sprawdzić toString
    }

}
