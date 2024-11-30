
using clusterTienda.Shared.Entities;
using Microsoft.EntityFrameworkCore;

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
            await CheckIcecreamsAsync();
            await CheckClientsAsync();
        }

        private async Task CheckClientsAsync()
        {
            if (!dataContext.Clients.Any())
            {
                //Necesito que por lo menos 1 tienda porque ya existe una relacion
                var icecream = await dataContext.Icecreams.FirstOrDefaultAsync(x => x.Flavour == "chocolate");
                if (icecream != null)
                {
                    dataContext.Clients.Add(new Client { Name = "Pablo", telephone = 23456,Icecream = icecream});
                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckIcecreamsAsync()
        {
            if (!dataContext.Icecreams.Any())
            {
                //Necesito que por lo menos 1 tienda porque ya existe una relacion
                var store = await dataContext.Stores.FirstOrDefaultAsync(x => x.Name == "Chedraui");
                if (store != null)
                {
                    dataContext.Icecreams.Add(new Icecream { Flavour = "Chocolate", Description = "Muy buen helado", Price = 10, Store = store });
                    dataContext.Icecreams.Add(new Icecream { Flavour = "Vainilla", Description = "Muy buen helado", Price = 15, Store = store });
                 
                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckStoresAsync()
        {
            if (!dataContext.Stores.Any())
            {
                dataContext.Stores.Add(new Store { Name = "Chedraui", Address = "Calle 2", Location = "Puebla" });
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
