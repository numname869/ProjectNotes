using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooServer.Models {
    public class Zagrody {
        [Key]
        public int IDZagrody { get; set; }
        public string NazwaZagrody { get; set; }
        public string TypZagrody { get; set; }
        public float Wielkość { get; set; }
        public string Lokalizacja { get; set; }
        public int Pojemność { get; set; }
        public string Status { get; set; }
    }
}
