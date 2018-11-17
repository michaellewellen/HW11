using HW11.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HW11.Data
{
    public class JsonDataStore : IDataStore
    {
        private const string Path = "People.json";

        public JsonDataStore()
        {
            if (File.Exists(Path))
            {
                people = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(Path));
            }
            else
            {
                people = new List<Person>();
            }
        }

        private List<Person> people;

        public void AddPerson(Person c)
        {
            people.Add(c);
            syncToDisk();
        }

        private void syncToDisk()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(people));
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return people;
        }
    }
}