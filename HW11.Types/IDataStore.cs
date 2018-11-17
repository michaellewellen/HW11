using System;
using System.Collections.Generic;
using System.Text;

namespace HW11.Types
{
    public interface IDataStore
    {
        void AddPerson(Person p);
        IEnumerable<Person> GetAllPeople();
    }
}
