using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class Zwierzęta {
        [Key]
        public int IDZwierzęcia { get; set; }
        [ForeignKey("Zagrody")]
        public int IDZagrody { get; set; }
        public string Nazwa { get; set; }
        public string Gatunek { get; set; }
        public int Wiek { get; set; }
        public DateTime DataPrzybycia { get; set; }
        public string Status { get; set; }
        public string Opis { get; set; }
    }
}
