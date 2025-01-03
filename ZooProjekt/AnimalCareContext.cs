using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProjekt
{
    public class AnimalCareContext : DbContext
    {
        public DbSet<Konto> Konta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AnimalCareDB;Integrated Security=True;Encrypt=False");
        }
    }
}
