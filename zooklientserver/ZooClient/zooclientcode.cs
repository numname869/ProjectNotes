using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5134/api/") };
    private static int userId = 0;
    private static string userRole = "";

    static async Task Main()
    {
        Console.WriteLine("=== System logowania Zoo ===");

        while (true)
        {
            Console.WriteLine("\n1 - Zaloguj");
            Console.WriteLine("2 - Sprawdź chronioną zawartość");
            Console.WriteLine("3 - Wyjście");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await Login();
                    break;
                case "2":
                    await GetProtectedData();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("❌ Nieprawidłowa opcja, spróbuj ponownie.");
                    break;
            }
        }
    }

    private static async Task Login()
    {
        Console.Write("\n🔑 Podaj login: ");
        string login = Console.ReadLine();
        Console.Write("🔒 Podaj hasło: ");
        string haslo = Console.ReadLine();

        var request = new { Login = login, Haslo = haslo };

        try
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("konta/login", request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                userId = result.IDKonta;
                userRole = result.TypKonta;

                Console.WriteLine($"\n✅ Zalogowano pomyślnie! Twój ID: {userId}, Rola: {userRole}");
            }
            else
            {
                Console.WriteLine("\n❌ Błąd logowania. Sprawdź dane.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Błąd połączenia z serwerem: {ex.Message}");
        }
    }

    private static async Task GetProtectedData()
    {
        if (userId == 0)
        {
            Console.WriteLine("\n❌ Najpierw musisz się zalogować.");
            return;
        }

        try
        {
            HttpResponseMessage response = await client.GetAsync($"konta/protected/{userId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"\n✅ Odpowiedź serwera: {content}");
            }
            else
            {
                Console.WriteLine("\n❌ Brak dostępu. Może ID jest nieprawidłowe?");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Błąd połączenia z serwerem: {ex.Message}");
        }
    }
}

class LoginResponse
{
    public int IDKonta { get; set; }
    public string TypKonta { get; set; }
}