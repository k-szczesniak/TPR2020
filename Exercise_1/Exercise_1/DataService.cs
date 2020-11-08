using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class DataService
    {
        private IRepository _repository;

        public DataService(IRepository repository)
        {
            _repository = repository;
        }
        //TODO: Dodać metody
        //TODO: Odnośnie całego projektu - czy dodawać id i inne atrybuty? Sprawdzanie spójności, testy
        
        #region User
        public void AddUser(User user)
        {
            _repository.AddUser(user);
        }

        public User GetUser(int id)
        {
            return _repository.GetUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public void UpdateUser(int id, string firtName, string lastName)
        {
            _repository.UpdateUser(id, firtName, lastName);
        }

        public void DeleteUser(User user)
        {
            _repository.DeleteUser(user);
        }
        #endregion

        #region Catalog
        public void AddCatalog(Catalog catalog)
        {
            _repository.AddCatalog(catalog);
        }

        public Catalog GetCatalog(int id)
        {
            return _repository.GetCatalog(id);
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return _repository.GetAllCatalogs();
        }

        public void UpdateCatalog(int id, string author, string title)
        {
            _repository.UpdateCatalog(id, author, title);
        }

        public void DeleteCatalog(Catalog catalog)
        {
            _repository.DeleteCatalog(catalog);
        }
        #endregion

        #region State
        public void AddState(State state)
        {
            _repository.AddState(state);
        }

        public State GetState(int id)
        {
            return _repository.GetState(id);
        }

        public IEnumerable<State> GetAllStates()
        {
            return _repository.GetAllStates();
        }

        public void UpdateState(int id, string description, DateTime date, bool isAvailable)
        {
            _repository.UpdateState(id, description, date, isAvailable);
        }

        public void DeleteState(State state)
        {
            _repository.DeleteState(state);
        }
        #endregion

        #region Event
        public void AddEvent(Event item)
        {
            _repository.AddEvent(item);
        }

        public Event GetEvent(int id)
        {
            return _repository.GetEvent(id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _repository.GetAllEvents();
        }

        public void UpdateEvent(int id, DateTime date)
        {
            _repository.UpdateEvent(id, date);
        }

        public void DeleteEvent(Event item)
        {
            _repository.DeleteEvent(item);
        }
        #endregion

        //
        public IEnumerable<Event> GetAllEventsBetweenDates(DateTime beginDate, DateTime endDate)
        {
            List<Event> matchEvents = new List<Event>();
            foreach (Event eventToCheck in _repository.GetAllEvents())
            {
                if ((eventToCheck.Date >= beginDate) && (eventToCheck.Date <= endDate))
                {
                    matchEvents.Add(eventToCheck);
                }
            }
            return matchEvents;
        }

        public IEnumerable<Event> GetAllEventsForUser(User user)
        {
            List<Event> matchEvents = new List<Event>();
            foreach (Event eventToCheck in _repository.GetAllEvents())
            {
                if (eventToCheck.User.Equals(user))
                {
                    matchEvents.Add(eventToCheck);
                }
            }
            return matchEvents;
        }

        public IEnumerable<Event> GetAllEventsForCatalog(Catalog catalog)
        {
            List<Event> matchEvents = new List<Event>();
            foreach (Event eventToCheck in _repository.GetAllEvents())
            {
                if (eventToCheck.State.Catalog.Equals(catalog))
                {
                    matchEvents.Add(eventToCheck);
                }
            }
            return matchEvents;
        }

        public IEnumerable<State> GetAllStatesForCatalog(Catalog catalog)
        {
            List<State> matchStates = new List<State>();
            foreach (State stateToCheck in _repository.GetAllStates())
            {
                if (stateToCheck.Catalog.Equals(catalog))
                {
                    matchStates.Add(stateToCheck);
                }
            }
            return matchStates;
        }

        //public IEnumerable<Event> GetAllEventsForState(State state)
        //{
        //    List<Event> matchEvents = new List<Event>();
        //    foreach (Event eventToCheck in _IRepository.GetAllEvents())
        //    {
        //        if (eventToCheck.State == (state))
        //        {
        //            matchEvents.Add(eventToCheck);
        //        }
        //    }
        //    return matchEvents;
        //}


        //public void CatalogCheckout(User user, State state)
        //{
        //    if (state.)
        //}

        //TODO:metody do wypozyczania i zwrotu
    }
}
