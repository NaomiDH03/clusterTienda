using clusterTienda.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clusterTienda.Api.Controllers
{
    [ApiController]
    [Route("/api/clients")]
    public class ClientsController: ControllerBase
    {

        private readonly DataContext dataContext;

        public ClientsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet] //Metodo get
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Clients.Include(c => c.Icecream).ThenInclude(i => i.Store).ToListAsync());
        }

        [HttpGet("id:int")] //Metodo get pero con un id
        public async Task<IActionResult> GetAsync(int id)
        {
            var client = await dataContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Client client)
        {
            dataContext.Clients.Add(client);
            await dataContext.SaveChangesAsync();
            return Ok(client);
        }

        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Client client)
        {
            dataContext.Clients.Update(client);
            await dataContext.SaveChangesAsync();
            return Ok(client);
        }

        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Clients.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
