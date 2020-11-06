namespace Exercise_1
{
    interface IRepository
    {
        void AddUser(User user);
        User GetUser(string id);
        void UpdateUser(string replacedUserId, User user);
        void DeleteUser(User user);

        void AddCatalog(Catalog catalog);
        Catalog GetCatalog(string id);
        void UpdateCatalog(string replacedCatalogId, Catalog catalog);
        void DeleteCatalog(Catalog catalog);

        void AddState(State state);
        State GetState(string id);
        void UpdateState(string replacedStateId, State state);
        void DeleteState(State state);

        void AddEvent(Event @event);
        Event GetEvent(string id);
        void UpdateEvent(string replacedEventId, Event @event);
        void DeleteEvent(Event @event);

        //TODO: Dodać metodę GetAll, dla User, Catalog, State, Event

    }
}
