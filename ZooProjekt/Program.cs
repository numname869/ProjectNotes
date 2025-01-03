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
            AnimalCareContext context = new AnimalCareContext();
            context.SaveChanges();
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
