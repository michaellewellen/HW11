using System;
using System.Collections.Generic;
using System.Text;

namespace HW11.Types
{
    public class Person
    {
        public Person()
        {
        }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
