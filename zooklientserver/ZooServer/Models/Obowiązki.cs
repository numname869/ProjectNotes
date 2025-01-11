using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class Obowiązki {
        [Key]
        public int IDObowiązku { get; set; }
        [ForeignKey("Pracownicy")]
        public int IDPracownika { get; set; }
        public string TypHistorii { get; set; }
        public DateTime DataPoczątku { get; set; }
        public DateTime DataZakończenia { get; set; }
        public int Okres { get; set; }
        public string Status { get; set; }
        public string Opis { get; set; }
    }
}
