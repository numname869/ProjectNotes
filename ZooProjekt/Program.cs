using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Globalne obiekty
    static UserManagementFacade userManagement;
    static User loggedInUser = null;

    static void Main(string[] args)
    {
        var users = new List<User>();
        userManagement = new UserManagementFacade(users);
        SeedData(); // Dodanie przykładowych danych

        while (true)
        {
            ClearScreen();
            if (loggedInUser == null)
            {
                ShowLoginMenu();
            }
            else
            {
                ShowMainMenu();
            }
        }
    }

    // Menu główne
    static void ShowMainMenu()
    {
        Console.WriteLine($"Witaj, {loggedInUser.Username} ({loggedInUser.Role})!");
        Console.WriteLine("=== System Zarządzania Rehabilitacją Zwierząt ===");
        Console.WriteLine("1. Zarządzanie użytkownikami (wybierz opcję)");
        Console.WriteLine("2. Wylogowanie (wybierz opcję)");
        Console.Write("Wybierz opcję: ");
        ConsoleKeyInfo key = Console.ReadKey();

        switch (key.Key)
        {
            case ConsoleKey.D1:
                ManageUsers();
                break;
            case ConsoleKey.D2:
                loggedInUser = null;
                break;
            default:
                Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                WaitForUser();
                break;
        }
    }

    // Menu logowania
    static void ShowLoginMenu()
    {
        Console.WriteLine("=== Logowanie ===");
        Console.Write("Podaj nazwę użytkownika: ");
        string username = ValidateInput(Console.ReadLine(), "Nazwa użytkownika nie może być pusta.");
        Console.Write("Podaj hasło: ");
        string password = ValidateInput(ReadPassword(), "Hasło nie może być puste.");

        var user = userManagement.Authenticate(username, password);
        if (user != null)
        {
            loggedInUser = user;
            Console.WriteLine("Logowanie powiodło się!");
        }
        else
        {
            Console.WriteLine("Nieprawidłowa nazwa użytkownika lub hasło.");
        }

        WaitForUser();
    }

    // Zarządzanie użytkownikami
    static void ManageUsers()
    {
        if (loggedInUser.Role != "Administrator")
        {
            Console.WriteLine("Brak uprawnień do zarządzania użytkownikami.");
            WaitForUser();
            return;
        }

        while (true)
        {
            ClearScreen();
            Console.WriteLine("=== Zarządzanie użytkownikami ===");
            Console.WriteLine("1. Dodaj użytkownika (wybierz opcję)");
            Console.WriteLine("2. Edytuj użytkownika (wybierz opcję)");
            Console.WriteLine("3. Usuń użytkownika (wybierz opcję)");
            Console.WriteLine("4. Wyświetl listę użytkowników (wybierz opcję)");
            Console.WriteLine("5. Powrót");
            Console.Write("Wybierz opcję: ");
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    AddUser();
                    break;
                case ConsoleKey.D2:
                    EditUser();
                    break;
                case ConsoleKey.D3:
                    DeleteUser();
                    break;
                case ConsoleKey.D4:
                    DisplayUsers();
                    break;
                case ConsoleKey.D5:
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    WaitForUser();
                    break;
            }
        }
    }

    static void AddUser()
    {
        ClearScreen();
        Console.WriteLine("=== Dodawanie użytkownika ===");
        Console.Write("Podaj nazwę użytkownika: ");
        string username = ValidateInput(Console.ReadLine(), "Nazwa użytkownika nie może być pusta.");
        Console.Write("Podaj hasło: ");
        string password = ValidateInput(ReadPassword(), "Hasło nie może być puste.");
        Console.Write("Podaj rolę (Administrator/Weterynarz/Opiekun/Kierownik): ");
        string role = ValidateRole(Console.ReadLine());

        userManagement.AddUser(username, password, role);
        Console.WriteLine("Użytkownik został dodany.");
        WaitForUser();
    }

    static void EditUser()
    {
        ClearScreen();
        Console.WriteLine("=== Edycja użytkownika ===");
        Console.Write("Podaj nazwę użytkownika do edycji: ");
        string username = ValidateInput(Console.ReadLine(), "Nazwa użytkownika nie może być pusta.");

        Console.Write("Podaj nowe hasło (pozostaw puste, aby nie zmieniać): ");
        string newPassword = ReadPassword();
        Console.Write("Podaj nową rolę (pozostaw puste, aby nie zmieniać): ");
        string newRole = Console.ReadLine();

        if (userManagement.EditUser(username, newPassword, newRole))
        {
            Console.WriteLine("Dane użytkownika zostały zaktualizowane.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono użytkownika.");
        }

        WaitForUser();
    }

    static void DeleteUser()
    {
        ClearScreen();
        Console.WriteLine("=== Usuwanie użytkownika ===");
        Console.Write("Podaj nazwę użytkownika do usunięcia: ");
        string username = ValidateInput(Console.ReadLine(), "Nazwa użytkownika nie może być pusta.");

        if (userManagement.DeleteUser(username))
        {
            Console.WriteLine("Użytkownik został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono użytkownika.");
        }

        WaitForUser();
    }

    static void DisplayUsers()
    {
        ClearScreen();
        Console.WriteLine("=== Lista użytkowników ===");
        foreach (var user in userManagement.GetUsers())
        {
            Console.WriteLine($"- {user.Username} ({user.Role})");
        }
        WaitForUser();
    }

    // Walidacja
    static string ValidateInput(string input, string errorMessage)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Spróbuj ponownie: ");
            input = Console.ReadLine();
        }
        return input;
    }

    static string ValidateRole(string role)
    {
        var validRoles = new List<string> { "Administrator", "Weterynarz", "Opiekun", "Kierownik" };
        while (!validRoles.Contains(role))
        {
            Console.WriteLine("Nieprawidłowa rola. Dostępne role: Administrator, Weterynarz, Opiekun, Kierownik.");
            Console.Write("Spróbuj ponownie: ");
            role = Console.ReadLine();
        }
        return role;
    }

    static string ReadPassword()
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

    static void SeedData()
    {
        userManagement.AddUser("admin", "admin", "Administrator");
    }

    // Funkcje pomocnicze
    static void ClearScreen()
    {
        Console.Clear();
        Console.WriteLine("Czyszczenie ekranu...");
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
    }

    static void WaitForUser()
    {
        Console.WriteLine("Naciśnij Enter, aby kontynuować...");
        Console.ReadLine();
    }
}

// Klasy
class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

class UserManagementFacade
{
    private readonly List<User> users;

    public UserManagementFacade(List<User> users)
    {
        this.users = users;
    }

    public void AddUser(string username, string password, string role)
    {
        users.Add(new User { Username = username, Password = password, Role = role });
    }

    public bool EditUser(string username, string newPassword, string newRole)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user == null) return false;

        if (!string.IsNullOrEmpty(newPassword)) user.Password = newPassword;
        if (!string.IsNullOrEmpty(newRole)) user.Role = newRole;

        return true;
    }

    public bool DeleteUser(string username)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user == null) return false;

        users.Remove(user);
        return true;
    }

    public IEnumerable<User> GetUsers()
    {
        return users;
    }

    public User Authenticate(string username, string password)
    {
        return users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
