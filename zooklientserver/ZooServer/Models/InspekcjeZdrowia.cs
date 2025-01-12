using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class InspekcjeZdrowia {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInspekcjiZdrowia { get; set; }
        [ForeignKey("Zwierzęta")]
        public int IDZwierzęcia { get; set; }
        [ForeignKey("Obowiązki")]
        public int IDObowiązku { get; set; }
        public DateTime DataInspekcji { get; set; }
        public string Opis { get; set; }
        public string Zalecenia { get; set; }

        //todo
        public override string ToString() {
            return "";
        }
    }
}
