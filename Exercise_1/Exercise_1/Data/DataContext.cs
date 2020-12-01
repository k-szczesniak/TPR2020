using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Exercise_1.Data
{
    public class DataContext : IDataContext
    {
        public List<User> Users { get; set; } = new List<User>();
        public Dictionary<int, Catalog> Catalogs { get; set; } = new Dictionary<int, Catalog>();
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
        public List<State> States { get; set; } = new List<State>();

        public override bool Equals(object obj)
        {
            if (obj is IDataContext)
            {
                var that = obj as IDataContext;

                return this.Users == that.Users && this.Catalogs == that.Catalogs && this.Events == that.Events && this.States == that.States;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = -590007617;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<User>>.Default.GetHashCode(Users);
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<int, Catalog>>.Default.GetHashCode(Catalogs);
            hashCode = hashCode * -1521134295 + EqualityComparer<ObservableCollection<Event>>.Default.GetHashCode(Events);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<State>>.Default.GetHashCode(States);
            return hashCode;
        }
    }
}
