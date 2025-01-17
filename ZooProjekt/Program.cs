using System;
using System.Collections.Generic;
using System.Linq;


namespace ZooProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Run();
        }
        
        }

    }
class Application
{
    private UserManagementFacade userManagement = new UserManagementFacade();

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            if (!userManagement.IsUserLoggedIn())
            {
                userManagement.ShowLoginMenu();
            }
            else
            {
                userManagement.ShowMainMenu();
            }
        }
    }
    class UserManagementFacade
    {
        private List<User> users = new List<User>();
        private User loggedInUser = null;

        public UserManagementFacade()
        {
            // Placeholder for initialization logic
        }

        public void ShowLoginMenu()
        {
            // Placeholder for login menu logic
        }

        public void ShowMainMenu()
        {
            // Placeholder for main menu logic
        }

        public bool IsUserLoggedIn()
        {
            return loggedInUser != null;
        }
        private void SeedData()
        {
            users.Add(new User { Username = "admin", Password = "admin", Role = "Administrator" });
        }

    }
    public void ShowLoginMenu()
    {
        Console.WriteLine("=== Login ===");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = ReadPassword();

        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            loggedInUser = user;
            Console.WriteLine("Login successful!");
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
        WaitForUser();
    }


}

