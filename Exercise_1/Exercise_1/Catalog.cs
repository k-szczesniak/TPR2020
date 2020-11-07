using System.Collections.Generic;

namespace Exercise_1
{
    class Catalog
    {
        public string Author { get; set; }
        public string Title { get; set; }

        public Catalog(string author, string title)
        {
            Author = author;
            Title = title;
        }

        public override bool Equals(object obj)
        {
            return obj is Catalog catalog &&
                   Author == catalog.Author &&
                   Title == catalog.Title;
        }

        public override int GetHashCode()
        {
            int hashCode = 507744655;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            return hashCode;
        }

        public override string ToString()
        {
            return "Book{Title: " + Title + ", Author: " + Author + "}";
        }


        //TODO: Sprawdzić toString
    }
}
