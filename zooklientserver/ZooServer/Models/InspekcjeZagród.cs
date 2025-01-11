using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class InspekcjeZagród {
        [Key]
        public int IDInspekcjiZagrody { get; set; }
        [ForeignKey("Zagrody")]
        public int IDZagrody { get; set; }
        [ForeignKey("Obowiązki")]
        public int IDObowiązku { get; set; }
        public DateTime DataInspekcji { get; set; }
        public string WynikInspekcji { get; set; }
        public string Opis { get; set; }
        public string Zalecenia { get; set; }
    }
}
