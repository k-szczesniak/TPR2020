using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System.IO;

namespace SerializationTests
{
    [TestClass]
    public class SerializerXmlTest
    {
        Library library;
        Library deserializedLibrary;
        Book book1;
        Book book2;        

        [TestInitialize]
        public void TestInitialize()
        {
            library = new Library();
            book1 = new Book("Pan Tadeusz", "Adam Mickiewicz", "Sci-Fi", 25.50);
            book2 = new Book("Lalka", "Bolesław Prus", "Historyczna", 35.80);            
            Book[] books = { book1, book2};
            library.Books = books;
        }       

        [TestMethod]
        public void LibrarySerializationTest()
        {
            using (FileStream fileStream = new FileStream("serializationLibraryTest.xml", FileMode.Create))
            {
                SerializerXml.Serialize(fileStream, library);               
            }

            using (FileStream fileStream = new FileStream("serializationLibraryTest.xml", FileMode.Open))
            {
                deserializedLibrary = SerializerXml.Deserialize(fileStream);
            }

            Assert.IsNotNull(deserializedLibrary);
            Assert.AreNotSame(library, deserializedLibrary);

            Assert.AreEqual(library.Books[0].Author, deserializedLibrary.Books[0].Author);
            Assert.AreEqual(library.Books[0].Title, deserializedLibrary.Books[0].Title);
            Assert.AreEqual(library.Books[0].Genre, deserializedLibrary.Books[0].Genre);
            Assert.AreEqual(library.Books[0].Price, deserializedLibrary.Books[0].Price);

            Assert.AreEqual(library.Books[1].Author, deserializedLibrary.Books[1].Author);
            Assert.AreEqual(library.Books[1].Title, deserializedLibrary.Books[1].Title);
            Assert.AreEqual(library.Books[1].Genre, deserializedLibrary.Books[1].Genre);
            Assert.AreEqual(library.Books[1].Price, deserializedLibrary.Books[1].Price);
        }
    } 
}
