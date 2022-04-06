using MongoDB.Driver;
using ProjMongo.Model;
using System.Collections.Generic;

namespace ProjMongo.Service
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _addresses;

        public AddressService(IProjMongoDotnetDatabaseSettings settings)
        {

            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _addresses = database.GetCollection<Address>(settings.AddressCollectionName);

        }

        public List<Address> Get() =>
            _addresses.Find(address => true).ToList();

        public Address Get(string id) =>
           _addresses.Find<Address>(address => address.Id == id).FirstOrDefault();


        public Address Create(Address address)
        {
            _addresses.InsertOne(address);
            return address;
        }

        public void Update(string id, Address addressIn) =>
            _addresses.ReplaceOne(address => address.Id == id, addressIn);

        public void Remove(Address addressIn) =>
            _addresses.DeleteOne(address => address.Id == addressIn.Id);

        public void Remove(string id) =>
            _addresses.DeleteOne(address => address.Id == id);







    }
}
