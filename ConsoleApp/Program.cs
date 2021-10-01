using System;
using Service;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var db = new Database.DbContext("TestDB");
            var userService = new UserService(db);
            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Press Enter to add random user to DB:");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    var user = userService.GenerateRandomUser();
                    userService.AddUser(user);
                    Console.WriteLine($"Added user {user.FirstName} {user.LastName} to DB.\n");
                } else
                {
                    Console.WriteLine("Shutting down...");
                    isRunning = false;
                }
            }
        }
    }

}
