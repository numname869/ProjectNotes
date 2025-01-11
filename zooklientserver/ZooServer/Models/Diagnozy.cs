using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class Diagnozy {
        [Key]
        public int IDDiagnozy { get; set; }
        [ForeignKey("Zwierzęta")]
        public int IDZwierzęcia { get; set; }
        public string OpisDiagnozy { get; set; }
        public float Waga { get; set; }
        public float Długość { get; set; }
        public string InnePomiary { get; set; }
    }
}
