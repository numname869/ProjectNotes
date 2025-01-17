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
    public void ShowMainMenu()
    {
        Console.WriteLine($"Welcome, {loggedInUser.Username} ({loggedInUser.Role})!");
        Console.WriteLine("=== Animal Rehabilitation Management System ===");
        Console.WriteLine("1. Manage Users");
        Console.WriteLine("2. Logout");
        Console.Write("Choose an option: ");
        var key = Console.ReadKey();

        switch (key.Key)
        {
            case ConsoleKey.D1:
                ManageUsers();
                break;
            case ConsoleKey.D2:
                loggedInUser = null;
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                WaitForUser();
                break;
        }

    }
    private void ManageUsers()
    {
        // Functionality placeholder for managing users
        Console.WriteLine("\n=== User Management ===");
        WaitForUser();
    }
    private string ReadPassword()
    {
        string password = "";
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password[0..^1];
                Console.Write("\b \b");
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    private void WaitForUser()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }



}

