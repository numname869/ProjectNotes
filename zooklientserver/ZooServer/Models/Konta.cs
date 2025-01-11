using System;
using System.ComponentModel.DataAnnotations;

namespace ZooServer.Models
{
    public class Konta
    {
        [Key]
        public int IDKonta { get; set; } // Klucz główny

        public int IDPracownika { get; set; } // Powiązanie z pracownikiem

        [Required]
        public string TypKonta { get; set; } // administrator, weterynarz, kierownik, opiekun

        [Required]
        public string Login { get; set; }

        [Required]
        public string Haslo { get; set; } // Hasło (powinno być zahashowane)

        public DateTime OstatnieLogowanie { get; set; } = DateTime.Now;
    }
}