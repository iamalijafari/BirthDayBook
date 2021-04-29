using System;

namespace BirthDayBook
{
    public class Person: IComparable<Person>, IFormattable
    {
        public string Key { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime? BirthDay { get; }
        public Person(string key,string firstName,string lastName,DateTime birthDay)
        {
            Key = key;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
        }
        public override string ToString() => $"{Key}- Name: {FirstName} {LastName} born in {BirthDay:yyyy/MMM/dd}";
        public string ToString(string format,IFormatProvider formatProvider)
        {
            if (format == null) format = "A";
            switch (format.ToUpper())
            {
                case "A":
                    return ToString();
                case "N":
                    return $"Name: {FirstName} {LastName}";
                case "B":
                    return $"{BirthDay:yyyy/MMM/dd}";
                default:
                    throw new FormatException($"Format {format} is not supported.");
            }
        }
        public string ToString(String format) => ToString(format, null);
        public int CompareTo(Person other)
        {
            int result = BirthDay?.CompareTo(other?.BirthDay) ?? -1;
            if (result == 0) result = LastName?.CompareTo(other?.LastName) ?? -1;
            if (result == 0) result = FirstName?.CompareTo(other?.FirstName) ?? -1;
            return result;
        }
    }
}
