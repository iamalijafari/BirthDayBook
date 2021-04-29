using System;

namespace BirthDayBook
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("************************************************************");
                Console.WriteLine("Main  Menu".PadLeft(35,' '));
                Console.WriteLine("************************************************************");
                Console.WriteLine("Press 1 to add person");
                Console.WriteLine("Press 2 to remove person");
                Console.WriteLine("Press 3 to show all persons");
                Console.WriteLine("Press Q to exit");
                char MainMenuKey = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (MainMenuKey)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("************************************************************");
                        Console.WriteLine("Add New  Person Menu".PadLeft(40, ' '));
                        Console.WriteLine("************************************************************");
                        try
                        {
                            BirthDayBookManager.AddNewPerson();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Format Exception");
                            Console.WriteLine($"Adding new person faild, Error message: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Adding new person faild, Error message: {ex.Message}");
                        }
                        Console.Write("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("************************************************************");
                        Console.WriteLine("Remove Person Menu".PadLeft(39, ' '));
                        Console.WriteLine("************************************************************");
                        try
                        {
                            BirthDayBookManager.RemovePerson();
                        }
                        catch(ArgumentNullException ex)
                        {
                            Console.WriteLine("Null key!");
                            Console.WriteLine($"Prosses faild. Error message: {ex.Message}");
                        }
                        catch(InvalidKeyFormatException ex)
                        {
                            Console.WriteLine("Invalid key!");
                            Console.WriteLine($"Prosses faild. Error message: {ex.Message}");
                        }
                        catch(KeyNotFoundException ex)
                        {
                            Console.WriteLine("Key not found");
                            Console.WriteLine($"Prosses faild. {ex.Message}");
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Unexpected Error.");
                        }
                        Console.WriteLine("Press any key to countinue.");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("************************************************************");
                        Console.WriteLine("All  Persons in List".PadLeft(40, ' '));
                        Console.WriteLine("Sorted by Birthday".PadLeft(39, ' '));
                        Console.WriteLine("************************************************************");
                        Console.Write("Press A for all information, N for Names, or B for birthdays to show: ");
                        char ShowMemuKey = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        Console.WriteLine("************************************************************");
                        try
                        {
                            BirthDayBookManager.ShowAllPeople(ShowMemuKey.ToString());
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine("Press any key to countinue.");
                        Console.ReadKey();
                        break;
                    case 'q':
                    case 'Q':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Invalid enterd key, press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
