﻿namespace Exercise_1
{
    class DataRepository : IRepository
    {
        private IFiller _filler;

        public DataRepository(IFiller filler)
        {
            _filler = filler;
            _filler.Fill("jakas_sciezka");      //TODO: Jak możesz to zerknij czy to wstrzyknięcie zależności jest git
        }

        public void AddCatalog(Catalog catalog)
        {
            //TODO:Zaimplementować metodę
        }

        public void AddEvent(Event @event)
        {
            //TODO:Zaimplementować metodę
        }

        public void AddState(State state)
        {
            //TODO:Zaimplementować metodę
        }

        public void AddUser(User user)
        {
            //TODO:Zaimplementować metodę
        }

        public void DeleteCatalog(Catalog catalog)
        {
            //TODO:Zaimplementować metodę
        }

        public void DeleteEvent(Event @event)
        {
            //TODO:Zaimplementować metodę
        }

        public void DeleteState(State state)
        {
            //TODO:Zaimplementować metodę
        }

        public void DeleteUser(User user)
        {
            //TODO:Zaimplementować metodę
        }

        //Zakomentowane, bo był błąd kompilacji, bo nic nie zwracało

        //public Catalog GetCatalog(string id)
        //{
           
        //}

        //public Event GetEvent(string id)
        //{
                       
        //}

        //public State GetState(string id)
        //{
            
        //}

        //public User GetUser(string id)
        //{
            
        //}

        public void UpdateCatalog(string replacedCatalogId, Catalog catalog)
        {
            //TODO:Zaimplementować metodę
        }

        public void UpdateEvent(string replacedEventId, Event @event)
        {
            //TODO:Zaimplementować metodę
        }

        public void UpdateState(string replacedStateId, State state)
        {
            //TODO:Zaimplementować metodę
        }

        public void UpdateUser(string replacedUserId, User user)
        {
            //TODO:Zaimplementować metodę
        }
    }
}
