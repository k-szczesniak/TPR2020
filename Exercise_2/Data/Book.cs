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
        [XmlAttribute]
        public int Id { get; set; }

        public Book()
        {
        }

        public Book(string title, string author, string genre, double price, int id)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
            Id = id;
        }
    }
}
