using System;
using Database;
using Database.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Database.AppContext("TestDB");
            var user = new User() { FirstName = "Vasily", LastName = "The Great" };
            db.Users.Insert(user);
            var users = db.Users.GetList();
            foreach (var u in users)
            {
                Console.WriteLine(u.FirstName);
            }
        }
    }

}
