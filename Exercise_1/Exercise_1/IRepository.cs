using System;
using System.Collections.Generic;

namespace Exercise_1
{
    public interface IRepository
    {
        void AddUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        void UpdateUser(int id, string firstName, string LastName);
        void DeleteUser(User user);

        void AddCatalog(Catalog catalog);
        Catalog GetCatalog(int id);
        IEnumerable<Catalog> GetAllCatalogs();
        void UpdateCatalog(int id, string author, string title);
        void DeleteCatalog(Catalog catalog);

        void AddState(State state);
        State GetState(int id);
        IEnumerable<State> GetAllStates();
        void UpdateState(int id, string description, DateTime dateOfPurchase, bool isAvailable);
        void DeleteState(State state);

        void AddEvent(Event item);
        Event GetEvent(int id);
        IEnumerable<Event> GetAllEvents();
        void UpdateEvent(int id, DateTime date);
        void DeleteEvent(Event item);
    }
}
