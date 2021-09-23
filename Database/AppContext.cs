using System;
using MongoDB.Driver;
using Database.Models;

namespace Database
{
    public class AppContext
    {
        private IMongoDatabase db;
        private GenericRepository<User> users;
        public GenericRepository<User> Users
        {
            get { return users; }
            private set { users = value; }
        }
        public AppContext(string dbname)
        {
            var client = new MongoClient();
            db = client.GetDatabase(dbname);
            users = new GenericRepository<User>(db, "Users");
        }

    }
}
