using clusterTienda.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace clusterTienda.Api
{
    public class DataContext: DbContext
    {
        public DbSet<Store> Stores { get; set;}
        public DbSet<Icecream> Icecreams { get; set; }

        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Store>().HasIndex(x => x.Name).IsUnique(); //Para que no haya valores repetidos
        }
    }
}
