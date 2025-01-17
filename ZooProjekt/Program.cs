using System;

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
}

