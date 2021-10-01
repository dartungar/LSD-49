using System;
using MongoDB.Driver;
using MongoDB.Bson;
using Database.Models;

namespace Database
{
    public class DbContext
    {
        private IMongoDatabase db;
        private GenericRepository<User> users;
        public GenericRepository<User> Users
        {
            get { return users; }
            private set { users = value; }
        }
        public DbContext(string dbname)
        {
            var client = new MongoClient();
            db = client.GetDatabase(dbname);
            users = new GenericRepository<User>(db, "Users");
            // create single-column index
            users.CreateIndex("FirstName"); 
            // create multi-column index
            users.CreateIndex(new BsonDocument { 
                { "FirstName", 1 }, 
                { "LastName", 1 } 
            });
        }

    }
}
