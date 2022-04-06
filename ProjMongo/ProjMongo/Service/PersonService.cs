using MongoDB.Driver;
using ProjMongo.Model;
using System.Collections.Generic;

namespace ProjMongo.Service
{
    public class PersonService
    {

        private readonly IMongoCollection<Person> _people;

        public PersonService(IProjMongoDotnetDatabaseSettings settings)
        {

            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DatabaseName);
            _people = database.GetCollection<Person>(settings.PersonCollectionName);

        }

        public List<Person> Get() =>
            _people.Find(person => true).ToList();

        public Person Get(string id) =>
           _people.Find<Person>(person => person.Id == id).FirstOrDefault();

        public Person Create(Person person)
        {
            _people.InsertOne(person);
            return person;
        }

        public void Update(string id, Person personIn) =>
            _people.ReplaceOne(person => person.Id == id, personIn);

        public void Remove(Person personIn) =>
            _people.DeleteOne(person => person.Id == personIn.Id);

        public void Remove(string id) =>
            _people.DeleteOne(person => person.Id == id);








    }
}
