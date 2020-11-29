using System;

namespace ConsoleApp
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
            //
            #endregion

            while (choice != 5)
            {
                choice = Console.Read() - '0';
                switch (choice)
                {
                    case 1:
                        //TODO: option 1;
                        break;
                    case 2:
                        //TODO: option 2;
                        break;
                    case 3:
                        //TODO: option 3;
                        break;
                    case 4:
                        //TODO: option 4;
                        break;
                    case 5:
                        //TODO: option 5;
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
