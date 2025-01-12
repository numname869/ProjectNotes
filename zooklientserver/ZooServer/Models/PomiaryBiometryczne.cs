using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class PomiaryBiometryczne {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPomiaru { get; set; }
        [ForeignKey("InspekcjeZdrowia")]
        public int IDInspekcjiZdrowia { get; set; }

        public float Temperatura { get; set; }
        public float Waga { get; set; }
        public float Długość { get; set; }
        public string InnePomiary { get; set; }
    }
}
