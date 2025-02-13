using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ZooServer.Accessors;
using ZooServer.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ZooServer.Tests
{
    public class DataGetterTests
    {
        private DbContextOptions<AnimalCareContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<AnimalCareContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public void FindAccount_ReturnsCorrectAccount()
        {
            // Arrange
            var options = GetDbContextOptions();
            using (var context = new AnimalCareContext(options))
            {
                context.Konta.Add(new Konta { Login = "testuser", Haslo = "password" });
                context.SaveChanges();
            }

            using (var context = new AnimalCareContext(options))
            {
                var dataGetter = new DataGetter(context);

                // Act
                var account = dataGetter.FindAccount("testuser");

                // Assert
                Assert.NotNull(account);
                Assert.Equal("testuser", account.Login);
            }
        }
    }
}

public class AnimalCareContext : DbContext
{
    public AnimalCareContext(DbContextOptions<AnimalCareContext> options) : base(options) { }

    public DbSet<Diagnozy> Diagnozy { get; set; }
    public DbSet<InspekcjeZagród> InspekcjeZagród { get; set; }
    public DbSet<InspekcjeZdrowia> InspekcjeZdrowia { get; set; }
    public DbSet<Karmienia> Karmienia { get; set; }
    public DbSet<Konta> Konta { get; set; }
    public DbSet<Obowi¹zki> Obowi¹zki { get; set; }
    public DbSet<PomiaryBiometryczne> PomiaryBiometryczne { get; set; }
    public DbSet<Pracownicy> Pracownicy { get; set; }
    public DbSet<Zagrody> Zagrody { get; set; }
    public DbSet<Zwierzêta> Zwierzêta { get; set; }
}
