using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooServer.Controllers;
using ZooServer.Data;
using ZooServer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class KontaControllerTests
{
    private readonly AnimalCareContext _context;
    private readonly KontaController _controller;

    public KontaControllerTests()
    {
        // 📌 Tworzenie kontekstu w pamięci
        var options = new DbContextOptionsBuilder<AnimalCareContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new AnimalCareContext(options);

        // 📌 WYCZYŚĆ bazę przed dodaniem danych (aby uniknąć duplikacji)
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        // 📌 Dodanie testowych użytkowników
        _context.Konta.AddRange(new List<Konta>
        {
            new Konta { IDKonta = 1, Login = "admin", Haslo = "admin123", TypKonta = "administrator" },
            new Konta { IDKonta = 2, Login = "vet", Haslo = "vet123", TypKonta = "weterynarz" }
        });

        _context.SaveChanges();

        _controller = new KontaController(_context);
    }

    // ✅ Test poprawnego logowania
    [Fact]
    public async Task Login_ValidCredentials_ReturnsOk()
    {
        var loginRequest = new LoginRequest { Login = "admin", Haslo = "admin123" };

        var result = await _controller.Login(loginRequest) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    // ❌ Test niepoprawnego logowania
    [Fact]
    public async Task Login_InvalidCredentials_ReturnsUnauthorized()
    {
        var loginRequest = new LoginRequest { Login = "wrong", Haslo = "wrong" };

        var result = await _controller.Login(loginRequest) as UnauthorizedObjectResult;

        Assert.NotNull(result);
        Assert.Equal(401, result.StatusCode);
    }
}