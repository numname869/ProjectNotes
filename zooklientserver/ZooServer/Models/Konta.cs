using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooServer.Models
{
    public class Konta
    {
        [Key]
        public int IDKonta { get; set; }
        [ForeignKey("Pracownicy")]
        public int IDPracownika { get; set; }
        public string TypKonta { get; set; }
        public string Login { get; set; }
        public string Hasło { get; set; }
    }
}