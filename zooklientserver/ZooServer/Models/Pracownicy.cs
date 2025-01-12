using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class Pracownicy {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPracownika { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime DataZwolnienia { get; set; }
        public string Rola { get; set; }
        public string Email { get; set; }
        public string NumerTelefonu { get; set; }
        public bool StatusZatrudnienia { get; set; }
    }
}
