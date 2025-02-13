using Microsoft.EntityFrameworkCore;
using ZooServer.Accessors;
using ZooServer.Models;
using Xunit;
using System;
using System.Linq;

namespace TestProject1
{
    public class UnitTest1
    {
        private AnimalCareContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AnimalCareContext>()
                          .UseInMemoryDatabase(databaseName: "ZooTestDatabase")
                          .Options;

            return new AnimalCareContext(options);
        }

        [Fact]
        public void TestUpdateKonto()
        {
            
            var dbContext = CreateDbContext();
            dbContext.Konta.Add(new Konta { IDKonta = 1, Login = "oldLogin", Haslo = "oldPassword", TypKonta = "User" });
            dbContext.SaveChanges();

            var dataModifier = new DataModifier(dbContext);

          
            dataModifier.UpdateKonto(1, "newLogin", "newPassword", "Admin");

            var updatedAccount = dbContext.Konta.SingleOrDefault(k => k.IDKonta == 1);
            Assert.NotNull(updatedAccount);
            Assert.Equal("newLogin", updatedAccount.Login);
            Assert.Equal("newPassword", updatedAccount.Haslo);
            Assert.Equal("Admin", updatedAccount.TypKonta);
        }

        [Fact]
        public void TestUpdatePracownik()
        {
            
            var dbContext = CreateDbContext();
            dbContext.Pracownicy.Add(new Pracownicy { IDPracownika = 1, Imiê = "Jan", Nazwisko = "Kowalski", Rola = "Zoolog", Email = "jan.kowalski@zoo.com", NumerTelefonu = "123456789" });
            dbContext.SaveChanges();

            var dataModifier = new DataModifier(dbContext);

            
            dataModifier.UpdatePracownik(1, "Kamil", "Nowak", "Lekarz", "kamil.nowak@zoo.com", "987654321");

           
            var updatedPracownik = dbContext.Pracownicy.SingleOrDefault(p => p.IDPracownika == 1);
            Assert.NotNull(updatedPracownik);
            Assert.Equal("Kamil", updatedPracownik.Imiê);
            Assert.Equal("Nowak", updatedPracownik.Nazwisko);
            Assert.Equal("Lekarz", updatedPracownik.Rola);
            Assert.Equal("kamil.nowak@zoo.com", updatedPracownik.Email);
            Assert.Equal("987654321", updatedPracownik.NumerTelefonu);
        }

        [Fact]
        public void TestUpdateZwierze()
        {
            
            var dbContext = CreateDbContext();
            dbContext.Zwierzêta.Add(new Zwierzêta { IDZwierzêcia = 1, Nazwa = "Tygrys", Gatunek = "Panthera tigris", Wiek = 5, Status = "Zdrowy", Opis = "Wielki tygrys" });
            dbContext.SaveChanges();

            var dataModifier = new DataModifier(dbContext);

            
            dataModifier.UpdateZwierze(1, "Lwica", "Panthera leo", 4, "Zdrowy", "Wielka lwica");

           
            var updatedZwierze = dbContext.Zwierzêta.SingleOrDefault(z => z.IDZwierzêcia == 1);
            Assert.NotNull(updatedZwierze);
            Assert.Equal("Lwica", updatedZwierze.Nazwa);
            Assert.Equal("Panthera leo", updatedZwierze.Gatunek);
            Assert.Equal(4, updatedZwierze.Wiek);
            Assert.Equal("Zdrowy", updatedZwierze.Status);
            Assert.Equal("Wielka lwica", updatedZwierze.Opis);
        }

        [Fact]
        public void TestUpdateZagroda()
        {
            
            var dbContext = CreateDbContext();
            dbContext.Zagrody.Add(new Zagrody { IDZagrody = 1, TypZagrody = "Klatka", Wielkoœæ = 100, Lokalizacja = "Wschodnia czêœæ zoo", Pojemnoœæ = 5, Status = "Aktywna" });
            dbContext.SaveChanges();

            var dataModifier = new DataModifier(dbContext);

            
            dataModifier.UpdateZagroda(1, "Akwarium", 200, "Zachodnia czêœæ zoo", 10, "Zamkniêta");

            
            var updatedZagroda = dbContext.Zagrody.SingleOrDefault(z => z.IDZagrody == 1);
            Assert.NotNull(updatedZagroda);
            Assert.Equal("Akwarium", updatedZagroda.TypZagrody);
            Assert.Equal(200, updatedZagroda.Wielkoœæ);
            Assert.Equal("Zachodnia czêœæ zoo", updatedZagroda.Lokalizacja);
            Assert.Equal(10, updatedZagroda.Pojemnoœæ);
            Assert.Equal("Zamkniêta", updatedZagroda.Status);
        }


    }
}
