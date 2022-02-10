using DesafioSky.Data;
using DesafioSky.Models;
using DesafioSky.Models.Enums;
using DesafioSky.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioSky.Controllers
{
    [ApiController]

    public class InventoryController : ControllerBase
    {
        [HttpGet("v1/inventories")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            try
            {
                var inventories = await context.Inventories.ToListAsync();
                return Ok(new ResultViewModel<List<Inventory>>(inventories));
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Inventory>>("05X04 - Falha interna no servidor"));


            }
        }



        [HttpGet("v1/inventories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            try
            {
                var inventories = await context.Inventories.FirstOrDefaultAsync(x => x.Id == id);
                if (inventories == null)
                    return NotFound(new ResultViewModel<Inventory>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Inventory>(inventories));
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ResultViewModel<Inventory>("Falha interna no servidor"));
            }
        }


        [HttpPost("v1/inventories")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorInventoryViewModels model,
            [FromServices] AppDbContext context)
        {

            try
            {
                var inventory = new Inventory
                {
                  
                    Name = model.Name,
                    Department = model.Department,
                    ProductId = model.ProductId,
                    StartingInventory = 400,
                    CurrentInvetory = 165,
                    InventoryReceived = 40,
                    InventorySold = 275,
                    MinRequired = 65,
                    Status = InventoryStatus.Ok
                    
                    
                    
                };
                
                await context.Inventories.AddAsync(inventory); 
                            
                await context.SaveChangesAsync();

                return Created($"v1/inventories/{inventory.Id}", new ResultViewModel<Inventory>(inventory));

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Inventory>("05XE9 - Não foi possível incluir no inventório"));
            }
        }

        [HttpPut("v1/inventories/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorInventoryViewModels model,
            [FromServices] AppDbContext context)
        {

            try
            {
                var inventory = await context.Inventories.FirstOrDefaultAsync(x => x.Id == id);

                if (inventory == null)
                    return NotFound(new ResultViewModel<Inventory>("Conteúdo não encontrado"));

                inventory.Name = model.Name;
                inventory.Department = model.Department;                
           

                context.Inventories.Update(inventory);
                context.SaveChanges();

                return Ok(new ResultViewModel<Inventory>(inventory));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Inventory>("05XE8 - Não foi possível alterar o Inventório"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Inventory>("05X11 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/inventories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            try
            {
                var inventory = await context.Inventories.FirstOrDefaultAsync(x => x.Id == id);


                if (inventory == null)
                    return NotFound(new ResultViewModel<Inventory>("Conteúdo não encontrado"));

                context.Inventories.Remove(inventory);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Inventory>(inventory));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Inventory>("05XE7 - Não foi possível excluir"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Inventory>("05X12 - Falha interna no servidor"));
            }
        }
    }

}
