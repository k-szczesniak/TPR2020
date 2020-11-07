using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class DataService
    {
        private IRepository _IRepository;

        public DataService(IRepository IRepository)
        {
            _IRepository = IRepository;
        }
        //TODO: Dodać metody
        //TODO: Odnośnie całego projektu - czy dodawać id i inne atrybuty? Sprawdzanie spójności, testy
        
        #region User
        public void AddUser(User user)
        {
            _IRepository.AddUser(user);
        }

        public User GetUser(int id)
        {
            return _IRepository.GetUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _IRepository.GetAllUsers();
        }

        public void UpdateUser(int id, string firtName, string lastName)
        {
            _IRepository.UpdateUser(id, firtName, lastName);
        }

        public void DeleteUser(User user)
        {
            _IRepository.DeleteUser(user);
        }
        #endregion

        #region Catalog
        public void AddCatalog(Catalog catalog)
        {
            _IRepository.AddCatalog(catalog);
        }

        public Catalog GetCatalog(int id)
        {
            return _IRepository.GetCatalog(id);
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return _IRepository.GetAllCatalogs();
        }

        public void UpdateCatalog(int id, string author, string title)
        {
            _IRepository.UpdateCatalog(id, author, title);
        }

        public void DeleteCatalog(Catalog catalog)
        {
            _IRepository.DeleteCatalog(catalog);
        }
        #endregion

        #region State
        public void AddState(State state)
        {
            _IRepository.AddState(state);
        }

        public State GetState(int id)
        {
            return _IRepository.GetState(id);
        }

        public IEnumerable<State> GetAllStates()
        {
            return _IRepository.GetAllStates();
        }

        public void UpdateState(int id, string description, int amount, DateTime dateOfPurchase)
        {
            _IRepository.UpdateState(id, description, amount, dateOfPurchase);
        }

        public void DeleteState(State state)
        {
            _IRepository.DeleteState(state);
        }
        #endregion

        #region Event
        public void AddEvent(Event item)
        {
            _IRepository.AddEvent(item);
        }

        public Event GetEvent(int id)
        {
            return GetEvent(id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _IRepository.GetAllEvents();
        }

        public void UpdateEvent(int id, DateTime rentalDate, DateTime giveBackDate)
        {
            _IRepository.UpdateEvent(id, rentalDate, giveBackDate);
        }

        public void DeleteEvent(Event item)
        {
            _IRepository.DeleteEvent(item);
        }
        #endregion

        //


    }
}
