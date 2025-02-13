using Microsoft.EntityFrameworkCore;
using ZooServer.Models;

namespace ZooServer.Data
{
    public class AnimalCareContext : DbContext
    {
        public virtual DbSet<Konta> Konta { get; set; }

        public AnimalCareContext(DbContextOptions<AnimalCareContext> options) : base(options) { }
    }
}