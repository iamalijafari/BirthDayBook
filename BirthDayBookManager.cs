using System; 
using System.Collections.Generic;

namespace BirthDayBook
{
    public class BirthDayBookManager
    {
        private static List<Person> PeopleInList = new List<Person>();
        private static string IDGeneraator(char singleChar) => $"{singleChar}{PeopleInList.Count+1, 6:000000}";

        public static void AddNewPerson()
        {
            Console.Write("Enter person first name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Enter person last name: ");
            string LastName = Console.ReadLine();
            Console.Write("Enter person birthday in format yyyy/mm/dd: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime BirthDay)) throw new FormatException("Invalid format enterd for birthday.");
            Person newPerson = new Person(IDGeneraator(LastName?.ToUpper()[0] ?? 'A'),FirstName, LastName, BirthDay);
            PeopleInList.Add(newPerson);
            Console.WriteLine("Prosses done. New person added.");
        }
        public static void RemovePerson()
        {
            ShowAllPeople();
            Console.Write("Enter key to delete: ");
            string Key = Console.ReadLine();
            if (Key == null || Key == "") throw new ArgumentNullException("Key value can`t be null.");
            if (char.IsDigit(Key[0])) throw new InvalidKeyFormatException("Enterd key is not valid. First character must be char.");
            if (Key.Length != 7) throw new InvalidKeyFormatException("Entered Key is not valid. Length of key must equals to 7.");
            if(PeopleInList.Remove(PeopleInList.Find(p => p.Key == Key.ToUpper())))
            {
                Console.WriteLine("Selected person deleted.");
            }
            else
            {
                throw new KeyNotFoundException("Entered key not found.");
            }
        }
        public static void ShowAllPeople(string format = "A")
        {
            PeopleInList.Sort();
            foreach(Person person in PeopleInList)
            {
                Console.WriteLine(person.ToString(format));
            }
        }
    }
}
