using System.Collections.Generic;

namespace Exercise_1
{
    interface IRepository
    {
        void AddUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        void UpdateUser(int id, User user);
        void DeleteUser(User user);

        void AddCatalog(Catalog catalog);
        Catalog GetCatalog(int id);
        IEnumerable<Catalog> GetAllCatalogs();
        void UpdateCatalog(int id, Catalog catalog);
        void DeleteCatalog(Catalog catalog);

        void AddState(State state);
        State GetState(int id);
        IEnumerable<State> GetAllStates();
        void UpdateState(int id, State state);
        void DeleteState(State state);

        void AddEvent(Event item);
        Event GetEvent(int id);
        IEnumerable<Event> GetAllEvents();
        void UpdateEvent(int id, Event item);
        void DeleteEvent(Event item);
    }
}
