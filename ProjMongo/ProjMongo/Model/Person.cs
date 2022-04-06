﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjMongo.Model
{
    public class Person
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public Address Adress { get; set; }


    }
}
