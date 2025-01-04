using System.ComponentModel.DataAnnotations;

namespace ZooServer.Models
{
    public class Konta
    {
        [Key]
        public int IDKonta { get; set; }
        public int IDPracownika { get; set; }
        public string TypKonta { get; set; }
        public string Login { get; set; }
        public string Hasło { get; set; }
    }
}