using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProjekt
{
    public class Konto //entity
    {
        [Key]
        public int IDKonta { get; set; } //primary key
        public int IDPracownika { get; set; } //foreign key
        public string TypKonta { get; set; }
        public string Login { get; set; }
        public string Hasło { get; set; }
        public DateTime OstatnieLogowanie { get; set; }
    }
}
