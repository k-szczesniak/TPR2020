using Exercise_1.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Exercise_1.Tests.TestContext
{
    class TestDataContext : IDataContext
    {
        public List<User> Users { get; set; } = new List<User>();
        public Dictionary<int, Catalog> Catalogs { get; set; } = new Dictionary<int, Catalog>();
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        public List<State> States { get; set; } = new List<State>();
    }
}
