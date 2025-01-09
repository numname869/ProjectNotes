using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ZooServer.Data;
using ZooServer.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AnimalCareContext>(options =>
    options.UseInMemoryDatabase("AnimalCareDB"));

var app = builder.Build();

// Dodanie domyślnych danych logowania
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AnimalCareContext>();
    if (!context.Konta.Any()) // Sprawdzenie, czy są już konta
    {
        var defaultUser = new Konta
        {
            IDPracownika = 1,
            TypKonta = "admin",
            Login = "admin",  // Domyślny login
            Hasło = "password",  // Domyślne hasło
            //OstatnieLogowanie = DateTime.Now
        };
        context.Konta.Add(defaultUser);
        context.SaveChanges();
    }
}


app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();