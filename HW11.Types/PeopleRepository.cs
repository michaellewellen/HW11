using HW11.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW11
{
    public class PeopleRepository
    {
        private readonly IDataStore dataStore;

        public PeopleRepository(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public bool AddPerson(Person c)
        {
            try
            {
                dataStore.AddPerson(c);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Person> GetAllCards()
        {
            return dataStore.GetAllPeople();
        }
    }
}
