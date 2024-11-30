using clusterTienda.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clusterTienda.Api.Controllers
{
    [ApiController]
    [Route("/api/icecreams")]
    public class IcecreamsController: ControllerBase
    {

        private readonly DataContext dataContext;

        public IcecreamsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet] //Metodo get
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Icecreams.ToListAsync());
        }

        [HttpGet("id:int")] //Metodo get pero con un id
        public async Task<IActionResult> GetAsync(int id)
        {
            var icecream = await dataContext.Icecreams.FirstOrDefaultAsync(x => x.Id == id);
            if (icecream == null)
            {
                return NotFound();
            }
            return Ok(icecream);
        }

        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Icecream icecream)
        {
            dataContext.Icecreams.Add(icecream);
            await dataContext.SaveChangesAsync();
            return Ok(icecream);
        }

        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Icecream icecream)
        {
            dataContext.Icecreams.Update(icecream);
            await dataContext.SaveChangesAsync();
            return Ok(icecream);
        }

        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Icecreams.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
