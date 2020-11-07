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

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public void AddCatalog(Catalog catalog)
        {
            throw new NotImplementedException();
        }

        public Catalog GetCatalog(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            throw new NotImplementedException();
        }

        public void UpdateCatalog(int id, Catalog catalog)
        {
            throw new NotImplementedException();
        }

        public void DeleteCatalog(Catalog catalog)
        {
            throw new NotImplementedException();
        }

        public void AddState(State state)
        {
            throw new NotImplementedException();
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
