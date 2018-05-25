using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesSample
{
    class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public Person(string firstname, string lastname)
        {
            _firstName = firstname;
            _lastName = lastname;
        }

        public override String ToString() => $"{_firstName} {_lastName}";

        //public (string, string) Deconstruct()
        //{
        //    return (_firstName, _lastName);
        //}

        public void Deconstruct(out string firstname, out string lastname)
        {
            firstname = _firstName;
            lastname = _lastName;
        }
    }
}
