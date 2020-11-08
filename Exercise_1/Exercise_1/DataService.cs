using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_1
{
    public class DataService
    {
        private IRepository _repository;

        public DataService(IRepository repository)
        {
            _repository = repository;
        }
        
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

        public void UpdateState(int id, bool isAvailable)
        {
            _repository.UpdateState(id, isAvailable);
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

        public IEnumerable<Event> GetAllEventsBetweenDates(DateTime beginDate, DateTime endDate)
        {
            List<Event> matchEvents = new List<Event>();
            foreach (Event eventToCheck in GetAllEvents())
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
            foreach (Event eventToCheck in GetAllEvents())
            {
                if (eventToCheck.User == user)
                {
                    matchEvents.Add(eventToCheck);
                }
            }
            return matchEvents;
        }

        public IEnumerable<Event> GetAllEventsForCatalog(Catalog catalog)
        {
            List<Event> matchEvents = new List<Event>();
            foreach (Event eventToCheck in GetAllEvents())
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
            foreach (State stateToCheck in GetAllStates())
            {
                if (stateToCheck.Catalog.Equals(catalog))
                {
                    matchStates.Add(stateToCheck);
                }
            }
            return matchStates;
        }

        public int GetIndexOfTheState(State state)
        {
            List<State> allStates = GetAllStates().ToList<State>();
            for(int i = 0; i < allStates.Count; i++)
            {
                if (allStates[i] == state)
                {
                    return i;
                }
            }
            throw new Exception("Index not found");
        }

        public void CatalogCheckout(User user, State state)
        {
            if (state.IsAvailable)
            {
                int index = GetIndexOfTheState(state);
                UpdateState(index, false);
                AddEvent(new CheckoutEvent(user, state, DateTime.Now));
                return;
            }
            throw new ArgumentException("Book is not available");
        }

        public User GetUserConnectedWithState(State state)
        {
            List<Event> allEvents = GetAllEvents().ToList<Event>();
            for (int i = 0; i < allEvents.Count; i++)
            {
                if (allEvents[i].State == state)
                {
                    return allEvents[i].User;
                }
            }
            throw new Exception("Such user not exist");
        }

        public void CatalogReturn(User user, State state)
        {
            if(!state.IsAvailable && user == GetUserConnectedWithState(state))
            {
                int index = GetIndexOfTheState(state);
                UpdateState(index, true);
                AddEvent(new ReturnEvent(user, state, DateTime.Now));
            }
            else throw new ArgumentException("Book is available");
        }

    }
}
