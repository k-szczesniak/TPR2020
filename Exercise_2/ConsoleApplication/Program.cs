using System;
using System.IO;
using System.Xml.Schema;
using Data;
using Exercise_1.Data;
using Serialization;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            void Show()
            {
                Console.WriteLine("Hello !");
                Console.WriteLine("Choose one option from the list below:");
                Console.WriteLine("1. Export DataContext to JSON");
                Console.WriteLine("2. Import DataContext from JSON");
                Console.WriteLine("3. Export graph to JSON");
                Console.WriteLine("4. Import graph from JSON");
                Console.WriteLine("5. Export graph to TXT");
                Console.WriteLine("6. Import graph from TXT");
                Console.WriteLine("7. Export Library to XML and validate");
                Console.WriteLine("8. Import Library from XML");
                Console.WriteLine("9. Validate XML");
                Console.WriteLine("Press 0 key to exit");
            }

            Show();

            int choice = -1;
            OurSerializer ourSerializer = new OurSerializer();

            #region Data
            IDataContext dataContext = new DataContext();
            IFiller filler = new ConsoleFiller();
            filler.Fill(dataContext);

            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.2, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.3, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            Library library = new Library();
            Book book1 = new Book("Pan Tadeusz", "Adam Mickiewicz", "Sci-Fi", 25.50);
            Book book2 = new Book("Lalka", "Bolesław Prus", "Historyczna", 35.80);
            Book book3 = new Book("Romeo i Julia", "William Szekspir", "Dramat", 15.90);
            Book[] books = { book1, book2, book3 };
            library.Books = books;

            IDataContext dataContextDeserialized;
            Class1 class1JsonDeserialized;
            Class1 class1OwnDeserializd;
            Library libraryDeserialized;
            #endregion

            while (choice != 0)
            {
                choice = Console.Read() - '0';
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        using (FileStream fileStream = new FileStream("serializationDataContext.json", FileMode.Create))
                        {
                            JsonSerializer.Serialize(fileStream, dataContext);
                            Console.WriteLine("Object has been successfully serialized!");
                            Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        }
                        break;
                    case 2:
                        try
                        {
                            using (FileStream fileStream = new FileStream("serializationDataContext.json", FileMode.Open))
                            {
                                dataContextDeserialized = JsonSerializer.Deserialize<DataContext>(fileStream);
                                Console.WriteLine("Object has been successfully deserialized!");
                            }
                        }
                        catch (FileNotFoundException e)
                        {
                            Console.WriteLine("Error: " + e.GetType() + " has occured during deserialization!");
                        }
                        break;
                    case 3:
                        using (FileStream fileStream = new FileStream("serializationClass1.json", FileMode.Create))
                        {
                            JsonSerializer.Serialize(fileStream, class1);
                            Console.WriteLine("Object has been successfully serialized!");
                            Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        }
                        break;
                    case 4:
                        try
                        {
                            using (FileStream fileStream = new FileStream("serializationClass1.json", FileMode.Open))
                            {
                                class1JsonDeserialized = JsonSerializer.Deserialize<Class1>(fileStream);
                                Console.WriteLine("Object has been successfully deserialized!");
                            }
                        }
                        catch (FileNotFoundException e)
                        {
                            Console.WriteLine("Error: " + e.GetType() + " has occured during deserialization!");
                        }
                        break;
                    case 5:
                        using (FileStream fileStream = new FileStream("ownSerialization.txt", FileMode.Create))
                        {
                            ourSerializer.Serialize(fileStream, class1);
                            Console.WriteLine("Object has been successfully serialized!");
                            Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        }
                        break;
                    case 6:
                        try
                        {
                            using (FileStream fileStream = new FileStream("ownSerialization.txt", FileMode.Open))
                            {
                                class1OwnDeserializd = (Class1)ourSerializer.Deserialize(fileStream);
                                Console.WriteLine("Object has been successfully deserialized!");
                            }
                        }
                        catch (FileNotFoundException e)
                        {
                            Console.WriteLine("Error: " + e.GetType() + " has occured during deserialization!");
                        }
                        break;
                    case 7:
                        using (FileStream fileStream = new FileStream("serializationXmlLibrary.xml", FileMode.Create))
                        {
                            SerializerXml.Serialize(fileStream, library);
                        }
                        try
                        {
                            SerializerXml.Validate();
                            Console.WriteLine("Object has been successfully serialized and validated!");
                            Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        }
                        catch (XmlSchemaValidationException e)
                        {
                            File.Delete("serializationXmlLibrary.xml");
                            Console.WriteLine("Error: " + e.GetType() + " has occured during validation and file was not created!");
                        }

                        break;
                    case 8:
                        try
                        {
                            using (FileStream fileStream = new FileStream("serializationXmlLibrary.xml", FileMode.Open))
                            {
                                libraryDeserialized = SerializerXml.Deserialize(fileStream);
                                Console.WriteLine("Object has been successfully deserialized!");
                            }
                        }
                        catch (FileNotFoundException e)
                        {
                            Console.WriteLine("Error: " + e.GetType() + " has occured during deserialization!");
                        }

                        break;
                    case 9:
                        try
                        {
                            using (FileStream fileStream = new FileStream("serializationXmlLibrary.html", FileMode.Create))
                            {
                                SerializerXml.TransformToXHTML(fileStream);
                                Console.WriteLine("Object has been successfully transformed!");
                            }
                        }
                        catch (FileNotFoundException e)
                        {
                            File.Delete("serializationXmlLibrary.html");
                            Console.WriteLine("Error: " + e.GetType() + " has occured during transformation and file was not created!");                            
                        }                        
                        break;
                }
            }

            Console.ReadKey();
        }

    }
}
