using System;
using System.IO;
using Data;
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
                Console.WriteLine("1. Import JSON");
                Console.WriteLine("2. Export JSON");
                Console.WriteLine("3. Import OWN");
                Console.WriteLine("4. Export OWN");
                Console.WriteLine("5. Exit");
            }

            Show();

            int choice = 0;

            #region Dane
            Class1 class1 = new Class1(1.0, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            #endregion

            while (choice != 5)
            {
                choice = Console.Read() - '0';
                switch (choice)
                {
                    case 1:
                        JsonSerializer.Serialize(class1, "serializationTest.json");
                        Console.WriteLine("Object has been successfully serialized!");
                        Console.WriteLine("File location: " + Directory.GetCurrentDirectory());
                        break;
                    case 2:
                        Class1 class1Deserialized = JsonSerializer.Deserialize<Class1>("serializationTest.json");
                        Console.WriteLine("Object has been successfully deserialized!");                                               
                        Console.WriteLine(class1Deserialized.Number);                                               
                        Console.WriteLine(class1Deserialized.Text);                                               
                        break;
                    case 3:
                        Console.WriteLine("Three option");
                        //TODO: option 3;
                        break;
                    case 4:
                        Console.WriteLine("Four option");
                        //TODO: option 4;
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }

            Console.ReadKey();
        }
    
    }
}
