using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.ValueObjects
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName() => $"{FirstName} {LastName}";
    }
}
