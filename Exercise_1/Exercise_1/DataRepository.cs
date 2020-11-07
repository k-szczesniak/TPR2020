using System;
using System.Collections.Generic;

namespace Exercise_1
{
    public class DataRepository : IRepository
    {
        private IFiller _filler; //TODO:Tworzenie nowego property z fillerem, potrzebnie ?
        public DataContext DataContext { get; private set; }

        public DataRepository(DataContext dataContext, IFiller filler)
        {
            DataContext = dataContext;
            _filler = filler;
            _filler.Fill(dataContext);
        }

        #region User
        public void AddUser(User user)
        {
            DataContext.Users.Add(user);
        }

        public User GetUser(int id)
        {
            if (DataContext.Users.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }
            return DataContext.Users[id];
        }

        public IEnumerable<User> GetAllUsers()
        {
            return DataContext.Users;
        }

        public void UpdateUser(int id, string firstName, string lastName)
        {
            if (DataContext.Users.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }

            DataContext.Users[id].FirstName = firstName;
            DataContext.Users[id].LastName = lastName;
        }

        public void DeleteUser(User user)
        {
            foreach (Event item in DataContext.Events)
            {
                if (item.User == user)
                {
                    throw new Exception("Can not remove this user because he is connected with some event");
                }
            }
            DataContext.Users.Remove(user);
        }
        #endregion

        #region Catalog
        public void AddCatalog(Catalog catalog)
        {
            DataContext.Catalogs.Add(DataContext.Catalogs.Count, catalog);
        }

        public Catalog GetCatalog(int id)
        {
            if (DataContext.Catalogs.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }
            return DataContext.Catalogs[id];
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return DataContext.Catalogs.Values;
        }

        public void UpdateCatalog(int id, string author, string title)
        {
            if (DataContext.Catalogs.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }

            DataContext.Catalogs[id].Author = author;
            DataContext.Catalogs[id].Title = title;
        }

        public void DeleteCatalog(Catalog catalog)
        {
            foreach (State state in DataContext.States)
            {
                if (state.Catalog == catalog)
                {
                    throw new Exception("Can not remove this catalog because it is connected with some state");
                }
            }

            for (int i = 0; i < DataContext.Catalogs.Count; i++)
            {
                if (DataContext.Catalogs[i] == catalog)
                {
                    DataContext.Catalogs.Remove(i);
                    break;
                }
            }
        }
        #endregion

        #region State
        public void AddState(State state)
        {
            DataContext.States.Add(state);
        }

        public State GetState(int id)
        {
            if (DataContext.States.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }
            return DataContext.States[id];
        }

        public IEnumerable<State> GetAllStates()
        {
            return DataContext.States;
        }

        public void UpdateState(int id, string description, int amount, DateTime dateOfPurchase)
        {
            if (DataContext.States.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }

            DataContext.States[id].Description = description;
            DataContext.States[id].Amount = amount;
            DataContext.States[id].DateOfPurchase = dateOfPurchase;
        }

        public void DeleteState(State state)
        {
            foreach (Event item in DataContext.Events)
            {
                if (item.State == state)
                {
                    throw new Exception("Can not remove this state because it is connected with some event");
                }
            }

            DataContext.States.Remove(state);
        }
        #endregion

        public void AddEvent(Event item)
        {
            DataContext.Events.Add(item);
        }

        public Event GetEvent(int id)
        {
            if (DataContext.Events.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }
            return DataContext.Events[id];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return DataContext.Events;
        }

        public void UpdateEvent(int id, DateTime rentalDate, DateTime giveBackDate)
        {
            if (DataContext.Events.Count <= id || id < 0)
            {
                throw new Exception("There is no element with this id");
            }

            DataContext.Events[id].RentalDate = rentalDate;
            DataContext.Events[id].GiveBackDate = giveBackDate;
        }

        public void DeleteEvent(Event item)
        {
            DataContext.Events.Remove(item);
        }
    }
}
