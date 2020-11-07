using System;
using System.Collections.Generic;

namespace Exercise_1
{
    public class DataRepository : IRepository
    {
        private IFiller _filler;
        public DataContext DataContext { get; private set; }

        public DataRepository(DataContext dataContext, IFiller filler)
        {
            DataContext = dataContext;
            _filler = filler;
            _filler.Fill("jakas_sciezka");
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
            
        }

        public State GetState(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<State> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public void UpdateState(int id, State state)
        {
            throw new NotImplementedException();
        }

        public void DeleteState(State state)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void AddEvent(Event item)
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(int id, Event item)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(Event item)
        {
            throw new NotImplementedException();
        }
    }
}
