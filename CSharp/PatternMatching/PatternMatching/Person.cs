using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        public Person(string name) => name.Split(' ').MoveElementsTo(out _firstName, out _lastName);

        public string FirstName => _firstName;
        public string LastName => _lastName;     
    }

    public static class PersonExtensions
    {
        public static void Deconstruct(this Person p, out string firstname, out string lastname)
        {
            firstname = p.FirstName;
            lastname = p.LastName;
        }
    }

    public static class StringCollectionExtension
    {
        public static void MoveElementsTo(this IList<string> coll, out string s1, out string s2)
        {
            if (coll.Count != 2) throw new ArgumentException("wrong collection count", nameof(coll));

            s1 = coll[0];
            s2 = coll[1];
        }
    }
}
