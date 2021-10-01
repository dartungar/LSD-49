using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace Database.Models
{
    public class User
    {
        [BsonId]
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
