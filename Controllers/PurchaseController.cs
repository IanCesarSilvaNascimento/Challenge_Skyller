using DesafioSky.Data;

using DesafioSky.Models;
using DesafioSky.Services;
using DesafioSky.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioSky.Controllers
{
    [ApiController]

    public class PurchaseController : ControllerBase
    {
        [HttpGet("v1/purchases")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            try
            {
                var purchase = await context.Purchases.ToListAsync();
                return Ok(new ResultViewModel<List<Purchase>>(purchase));
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Purchase>>("05X04 - Falha interna no servidor"));


            }
        }



        [HttpGet("v1/purchases/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            try
            {
                var purchase = await context.Purchases.FirstOrDefaultAsync(x => x.Id == id);
                if (purchase == null)
                    return NotFound(new ResultViewModel<Purchase>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Purchase>(purchase));
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ResultViewModel<Purchase>("Falha interna no servidor"));
            }

        }


        [HttpPost("v1/purchases")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorPurchaseViewModel model,
            [FromServices] AppDbContext context)
        {

            try
            {
                var purchase = new Purchase
                {
                    ProductId = model.ProductId,
                    Address = model.Address


                };
                await context.Purchases.AddAsync(purchase);
                await context.SaveChangesAsync();

                var inventoryStatusService = new InventoryStatusService();
                inventoryStatusService.CounterItens(purchase.ProductId);

                
                
                return Created($"v1/purchases/{purchase.Id}", new ResultViewModel<Purchase>(purchase));

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Purchase>("05XE9 - Não foi possível incluir a compra"));
            }
        }

        [HttpPut("v1/purchases/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorPurchaseViewModel model,
            [FromServices] AppDbContext context)
        {

            try
            {
                var purchase = await context.Purchases.FirstOrDefaultAsync(x => x.Id == id);

                if (purchase == null)
                    return NotFound(new ResultViewModel<Purchase>("Conteúdo não encontrado inventory"));

                purchase.ProductId = model.ProductId;
                purchase.Address = model.Address;
                // purchase.Inventories = model.Inventories;

                context.Purchases.Update(purchase);
                context.SaveChanges();

                return Ok(new ResultViewModel<Purchase>(purchase));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Purchase>("05XE8 - Não foi possível alterar a compra"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Purchase>("05X11 - Falha interna no servidor"));
            }

        }

        [HttpDelete("v1/purchases/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            try
            {
                var purchase = await context.Purchases.FirstOrDefaultAsync(x => x.Id == id);


                if (purchase == null)
                    return NotFound(new ResultViewModel<Purchase>("Conteúdo não encontrado"));

                context.Purchases.Remove(purchase);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Purchase>(purchase));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Purchase>("05XE7 - Não foi possível excluir"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Purchase>("05X12 - Falha interna no servidor"));
            }

        }

    }
}