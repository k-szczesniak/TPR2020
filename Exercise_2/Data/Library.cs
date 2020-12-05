using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Data
{
    [XmlRootAttribute("Library", Namespace= "http://www.w3schools.com", IsNullable = false)]
    public class Library
    {
        [XmlArrayAttribute("Books")]
        public Book[] Books;
    }
}
