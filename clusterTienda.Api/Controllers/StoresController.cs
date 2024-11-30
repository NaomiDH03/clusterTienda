using clusterTienda.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clusterTienda.Api.Controllers
{
    [ApiController]
    [Route("/api/stores")]
    public class StoresController: ControllerBase
    {
        private readonly DataContext dataContext;

        public StoresController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet] //Metodo get
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Stores.ToListAsync());
        }

        [HttpGet("id:int")] //Metodo get pero con un id
        public async Task<IActionResult> GetAsync(int id)
        {
            var store = await dataContext.Stores.FirstOrDefaultAsync(x => x.Id == id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Store store)
        {
            dataContext.Stores.Add(store);
            await dataContext.SaveChangesAsync();
            return Ok(store);
        }

        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Store store)
        {
            dataContext.Stores.Update(store);
            await dataContext.SaveChangesAsync();
            return Ok(store);
        }

        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Stores.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
