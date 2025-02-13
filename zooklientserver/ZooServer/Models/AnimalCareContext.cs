using Microsoft.EntityFrameworkCore;

namespace ZooServer.Models
{
    public class AnimalCareContext : DbContext
    {
        public AnimalCareContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Diagnozy> Diagnozy { get; set; }
        public DbSet<InspekcjeZagród> InspekcjeZagród { get; set; }
        public DbSet<InspekcjeZdrowia> InspekcjeZdrowia { get; set; }
        public DbSet<Karmienia> Karmienia { get; set; }
        public DbSet<Konta> Konta { get; set; }
        public DbSet<Obowiązki> Obowiązki { get; set; }
        public DbSet<PomiaryBiometryczne> PomiaryBiometryczne { get; set; }
        public DbSet<Pracownicy> Pracownicy { get; set; }
        public DbSet<Zagrody> Zagrody { get; set; }
        public DbSet<Zwierzęta> Zwierzęta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AnimalCareDB;Integrated Security=True;Encrypt=False");
        }
    }
}