using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Data
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }

        public Book()
        {
        }

        public Book(string title, string author, string genre, double price)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
        }
    }
}
