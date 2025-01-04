using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ZooProjekt
{
  
    
    internal class Program
    {

        static void Main(string[] args)
        {

            //   AnimalCareContext context = new AnimalCareContext();
            //   context.SaveChanges();

            Console.WriteLine("Witamy w Systemie Rehabilitacji Zwierząt");
            if (!LoginUser())
            {
                Console.WriteLine("Nieprawidłowe dane logowania. Zamykanie aplikacji...");
                return;
            }

            DisplayMainMenu();
        }

        static bool LoginUser()
        {
            Console.Write("Podaj login: ");
            string username = Console.ReadLine();

            Console.Write("Podaj hasło: ");
            string password = Console.ReadLine();

            return ValidateCredentials(username, password);
        }

        static bool ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            // Placeholder for actual validation logic.
            return username == "admin" && password == "password";
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\n===============================");
            Console.WriteLine("   System Rehabilitacji Zwierząt");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Zarządzanie użytkownikami");
            Console.WriteLine("2. Zarządzanie danymi o zwierzętach");
            Console.WriteLine("3. Raporty");
            Console.WriteLine("4. Administracja");
            Console.WriteLine("5. Wylogowanie");
            Console.WriteLine("===============================");
            Console.Write("Wybierz opcję: ");
        }

        private static void RemoveTestValues(AnimalCareContext context)
        {
            var idWhere1 = from konto in context.Konta
                           where konto.IDPracownika == -1
                           select konto;
            context.Konta.RemoveRange(idWhere1);
        }

        private static void AddTestValue(AnimalCareContext context)
        {
            int maxID = 0;
            if (context.Konta.Count() > 0) {
                var id = from konto in context.Konta
                         select konto.IDKonta;
                maxID = id.Max();
            }
            var acc = new Konta {
                IDKonta = ++maxID,
                IDPracownika = -1,
                TypKonta = "admin",
                Login = "test",
                Hasło = "test",
                OstatnieLogowanie = System.DateTime.Now
            };
            context.Konta.Add(acc);
        }
    }
}
