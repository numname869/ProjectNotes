using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class Karmienia {
        [Key]
        public int IDKarmienia { get; set; }
        [ForeignKey("Zwierzęta")]
        public int IDZwierzęcia { get; set; }
        [ForeignKey("Obowiązki")]
        public int IDObowiązku { get; set; }
        public DateTime DataKarmienia { get; set; }
        public string RodzajKarmy { get; set; }
        public float IlośćKarmy { get; set; }

        public override string ToString() {
            return "";
        }
    }
}
