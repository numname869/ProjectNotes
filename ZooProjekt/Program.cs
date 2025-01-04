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

        static void UserManagementMenu()
        {
            Console.WriteLine("\nZarządzanie użytkownikami:");
            Console.WriteLine("1. Stwórz użytkownika");
            Console.WriteLine("2. Przypisz obowiązki");
            Console.WriteLine("3. Wyświetl obowiązki");
            Console.WriteLine("4. Powrót do głównego menu");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ClearScreen("Tworzenie nowego użytkownika...");
                    CreateUser();
                    break;
                case "2":
                    ClearScreen("Przypisywanie obowiązków...");
                    AssignDuties();
                    break;
                case "3":
                    ClearScreen("Wyświetlanie obowiązków...");
                    ViewDuties();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Wybierz opcję ponownie.");
                    break;
            }
        }

        static void CreateUser()
        {
            Console.WriteLine("\nTworzenie nowego użytkownika...");
            Console.Write("Podaj nazwę użytkownika: ");
            string username = Console.ReadLine();

            Console.Write("Podaj hasło: ");
            string password = Console.ReadLine();

            if (ValidateCredentials(username, password))
            {
                Console.WriteLine("Użytkownik został pomyślnie utworzony.");
            }
            else
            {
                Console.WriteLine("Błąd: Nieprawidłowa nazwa użytkownika lub hasło.");
            }
        }

        static void AssignDuties()
        {
            Console.WriteLine("Przypisywanie obowiązków nie jest jeszcze zaimplementowane.");
        }

        static void ViewDuties()
        {
            Console.WriteLine("Wyświetlanie obowiązków nie jest jeszcze zaimplementowane.");
        }

        static void AnimalDataManagementMenu()
        {
            Console.WriteLine("\nZarządzanie danymi o zwierzętach:");
            Console.WriteLine("1. Rejestracja danych zwierzęcia");
            Console.WriteLine("2. Wyświetl historię karmienia");
            Console.WriteLine("3. Powrót do głównego menu");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ClearScreen("Rejestracja danych zwierzęcia...");
                    RegisterAnimalData();
                    break;
                case "2":
                    ClearScreen("Wyświetlanie historii karmienia...");
                    ViewFeedingHistory();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Wybierz opcję ponownie.");
                    break;
            }
        }

        static void RegisterAnimalData()
        {
            Console.WriteLine("Rejestracja danych zwierzęcia nie jest jeszcze zaimplementowana.");
        }

        static void ViewFeedingHistory()
        {
            Console.WriteLine("Wyświetlanie historii karmienia nie jest jeszcze zaimplementowane.");
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
