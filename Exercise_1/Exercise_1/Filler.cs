using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class Filler : IFiller
    {
        public void Fill(DataContext context)
        {
            #region User
            context.Users.Add(new User("Jan", "Kowalski"));
            context.Users.Add(new User("Janusz", "Nowak"));
            context.Users.Add(new User("Anna", "Nowak"));
            context.Users.Add(new User("Michał", "Kwiatkowski"));
            context.Users.Add(new User("Violetta", "Michniewska"));
            #endregion

            #region Catalogs
            context.Catalogs.Add(1, new Catalog("Bolasław Prus", "Lalka"));
            context.Catalogs.Add(2, new Catalog("Stanisław Wyspiański", "Wesele"));
            context.Catalogs.Add(3, new Catalog("Juliusz Słowacki", "Balladyna"));
            context.Catalogs.Add(4, new Catalog("Adam Mickiewicz", "Dziady"));
            context.Catalogs.Add(5, new Catalog("Albert Camus", "Dżuma"));
            #endregion

            #region States
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                context.States.Add(new State(context.Catalogs[i + 1], "Book description " + i, 1, DateTime.Today.AddDays(-rand.Next(365))));
            }
            #endregion

        }
    }
}
