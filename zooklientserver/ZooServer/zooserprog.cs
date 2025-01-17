using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ZooServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodanie usług do kontenera DI
builder.Services.AddControllers();
builder.Services.AddDbContext<AnimalCareContext>(options =>
    options.UseSqlServer("Data Source=localhost;Initial Catalog=AnimalCareDB;Integrated Security=True;Encrypt=False"));

var app = builder.Build();

// **Automatyczna migracja bazy danych**
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AnimalCareContext>();

    try
    {
        context.Database.Migrate(); // Wykonuje migracje

        // **Dodanie domyślnych kont użytkowników, jeśli tabela jest pusta**
        if (!context.Konta.Any())
        {
            var konta = new List<Konta>
            {
                new Konta { IDPracownika = 1, TypKonta = "administrator", Login = "admin", Haslo = "admin123" },
                new Konta { IDPracownika = 2, TypKonta = "weterynarz", Login = "vet", Haslo = "vet123" },
                new Konta { IDPracownika = 3, TypKonta = "kierownik", Login = "manager", Haslo = "manager123" },
                new Konta { IDPracownika = 4, TypKonta = "opiekun", Login = "keeper", Haslo = "keeper123" }
            };

            context.Konta.AddRange(konta);
            context.SaveChanges();
            Console.WriteLine("✅ Dodano domyślne konta użytkowników.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Błąd inicjalizacji bazy danych: {ex.Message}");
    }
}

// Middleware
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();