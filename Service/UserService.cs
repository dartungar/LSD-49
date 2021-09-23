using System;
using System.Collections.Generic;
using Bogus;
using Database;
using Database.Models;


namespace Service
{
    public class UserService
    {
        private DbContext db;
        private Faker<User> randomUserGenerator;
        public UserService(DbContext db)
        {
            this.db = db;
            this.randomUserGenerator = RandomUserGenerator();
        }

        public void AddUser(User user)
        {
            db.Users.Insert(user);
        }

        public List<User> GetUsers()
        {
            return db.Users.GetList();
        }

        public User GenerateRandomUser()
        {
            return randomUserGenerator.Generate();
        }

        private Faker<User> RandomUserGenerator()
        {
            return new Faker<User>()
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName());
        }
    }
}
