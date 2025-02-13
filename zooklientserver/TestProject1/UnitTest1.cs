using Microsoft.EntityFrameworkCore;
using ZooServer.Accessors;
using ZooServer.Models;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void AddAccount_AddsAccountToDatabase()
        {
            
            var options = new DbContextOptionsBuilder<AnimalCareContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AnimalCareContext(options))
            {
                var account = new Konta { Login = "testuser", Haslo = "password" };

              
                context.Konta.Add(account);
                context.SaveChanges();

            
                Assert.Equal(1, context.Konta.Count());
                Assert.Equal("testuser", context.Konta.Single().Login);
            }
        }

        [Fact]
        public void UpdateAccount_ChangesAccountDetails()
        {
           
            var options = new DbContextOptionsBuilder<AnimalCareContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AnimalCareContext(options))
            {
                var account = new Konta { Login = "testuser", Haslo = "password" };
                context.Konta.Add(account);
                context.SaveChanges();
            }

            using (var context = new AnimalCareContext(options))
            {
                var account = context.Konta.Single();
                account.Haslo = "newpassword";

                
                context.Konta.Update(account);
                context.SaveChanges();

                var updatedAccount = context.Konta.Single();
                Assert.Equal("newpassword", updatedAccount.Haslo);
            }
        }

        [Fact]
        public void DeleteAccount_RemovesAccountFromDatabase()
        {
            
            var options = new DbContextOptionsBuilder<AnimalCareContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AnimalCareContext(options))
            {
                var account = new Konta { Login = "testuser", Haslo = "password" };
                context.Konta.Add(account);
                context.SaveChanges();
            }

            using (var context = new AnimalCareContext(options))
            {
                var account = context.Konta.Single();

              
                context.Konta.Remove(account);
                context.SaveChanges();

               
                Assert.Equal(0, context.Konta.Count());
            }
        }



    }
}