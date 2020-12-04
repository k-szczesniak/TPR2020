using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Data
{
    [XmlRootAttribute("Library", Namespace="http://www.cpandl.com", IsNullable = false)]
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
