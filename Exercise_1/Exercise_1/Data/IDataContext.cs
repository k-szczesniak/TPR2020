using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Exercise_1.Data
{
    public interface IDataContext
    {
        List<User> Users { get; set; }
        Dictionary<int, Catalog> Catalogs { get; set; }
        ObservableCollection<Event> Events { get; set; }
        List<State> States { get; set; }
    }
}
