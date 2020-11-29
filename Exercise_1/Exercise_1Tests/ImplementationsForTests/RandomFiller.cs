using Exercise_1.Data;
using System;
using System.Text;

namespace Exercise_1.Tests.ImplementationsForTests
{
    class RandomFiller : IFiller
    {
        Random random = new Random();

        public void Fill(IDataContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                context.Users.Add(new User(RandomString(random.Next(5, 10)), RandomString(random.Next(5, 10))));
            }

            for (int i = 0; i < 5; i++)
            {
                context.Catalogs.Add(i, new Catalog(RandomString(random.Next(5, 10)), RandomString(random.Next(5, 10))));
            }

            for (int i = 0; i < 5; i++)
            {
                context.States.Add(new State(context.Catalogs[i], RandomString(random.Next(5, 10)), new DateTime(random.Next(2015, 2020), random.Next(1, 12), random.Next(1, 27)), true));
            }

            for (int i = 0; i < 5; i++)
            {
                context.Events.Add(new CheckoutEvent(context.Users[i], context.States[i], new DateTime(random.Next(2015, 2020), random.Next(1, 12), random.Next(1, 27))));
            }

            for (int i = 0; i < 5; i++)
            {
                context.Events.Add(new ReturnEvent(context.Users[i], context.States[i], new DateTime(random.Next(2015, 2020), random.Next(1, 12), random.Next(1, 27))));
            }

        }

        private string RandomString(int length)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int alphabetLength = alphabet.Length;

            StringBuilder randomString = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                randomString.Append(alphabet[random.Next(alphabetLength)]);
            }

            return randomString.ToString();
        }
    }
}
