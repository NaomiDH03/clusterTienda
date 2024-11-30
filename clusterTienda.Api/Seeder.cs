
using clusterTienda.Shared.Entities;

namespace clusterTienda.Api
{
    public class Seeder
    {
        private readonly DataContext dataContext;

        public Seeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckStoresAsync();
        }

        private async Task CheckStoresAsync()
        {
            if (!dataContext.Stores.Any())
            {
                dataContext.Stores.Add(new Store { Name = "Tienda 1", Address = "Calle 1", Location = "Puebla" });
                dataContext.Stores.Add(new Store { Name = "Tienda 2", Address = "Calle 2", Location = "Puebla" });
            }
        }
    }
}
