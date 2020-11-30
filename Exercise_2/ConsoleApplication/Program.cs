using System;
using System.IO;
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
                Console.WriteLine("7. Exit");
            }

            Show();

            int choice = 0;

            #region Data
            IDataContext dataContext = new DataContext();
            IFiller filler = new ConsoleFiller();
            filler.Fill(dataContext);

            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;
            #endregion

            while (choice != 7)
            {
                choice = Console.Read() - '0';
                switch (choice)
                {
                    case 1:
                        using (FileStream fileStream = new FileStream("serializationDataContextTest.json", FileMode.Create))
                        {
                            JsonSerializer.Serialize(fileStream, dataContext);
                            Console.WriteLine("Object has been successfully serialized!");
                            Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        }                        
                        break;
                    case 2:
                        using (FileStream fileStream = new FileStream("serializationDataContextTest.json", FileMode.Open))
                        {
                            IDataContext dataContextDeserialized = JsonSerializer.Deserialize<DataContext>(fileStream);
                            Console.WriteLine("Object has been successfully deserialized!");
                            Console.WriteLine(dataContextDeserialized.Users[0]);
                            Console.WriteLine(dataContextDeserialized.Catalogs[0]);
                        }
                        break;
                    case 3:
                        using (FileStream fileStream = new FileStream("serializationClass1Test.json", FileMode.Create))
                        {
                            JsonSerializer.Serialize(fileStream, class1);
                            Console.WriteLine("Object has been successfully serialized!");
                            Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        }                        
                        break;
                    case 4:
                        using (FileStream fileStream = new FileStream("serializationClass1Test.json", FileMode.Open))
                        {
                            Class1 class1Deserialized = JsonSerializer.Deserialize<Class1>(fileStream);
                            Console.WriteLine("Object has been successfully deserialized!");
                            Console.WriteLine(class1Deserialized.Number);
                            Console.WriteLine(class1Deserialized.Text);
                        }                        
                        break;
                    case 5:
                        using (FileStream fileStream = new FileStream("ownSerializationTest.txt", FileMode.Create))
                        {
                            OurSerializer ourSerializer = new OurSerializer();
                            ourSerializer.Serialize(fileStream, class1);
                            Console.WriteLine("Object has been successfully serialized!");
                            Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        }
                        break;
                    case 6:
                        using(FileStream fileStream = new FileStream("ownSerializationTest.txt", FileMode.Open))
                        {
                            OurSerializer ourSerializer = new OurSerializer();
                            Class1 testClass1 = (Class1)ourSerializer.Deserialize(fileStream);
                            Console.WriteLine(testClass1.Class2.ToString());
                            Console.WriteLine(testClass1.Class3.ToString());
                            Console.WriteLine(testClass1.Number);
                            Console.WriteLine(testClass1.BooleanValue);
                            Console.WriteLine(testClass1.Text);
                            Console.WriteLine(testClass1.DateTime);
                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
            }

            Console.ReadKey();
        }
    
    }
}
