using DesafioSky.Data;
using DesafioSky.Models;
using DesafioSky.Models.Enums;

namespace DesafioSky.Services;

public class InventoryStatusService
{
    public void CounterItens(long productId)
    {
        try
        {
            using var context = new AppDbContext();
            
            var counterItens = context.Purchases.Where(x => x.ProductId == productId).Count();

            var inventoryItem = context.Inventories.First(x => x.ProductId == productId);
            
            if (counterItens > 0)
            {
                inventoryItem.InventorySold += 1;
                inventoryItem.CurrentInvetory -= 1;
            }


            if (inventoryItem.CurrentInvetory < inventoryItem.MinRequired)
            {

                inventoryItem.Status = InventoryStatus.Lacking;
                // DESMARCAR PARA ENVIAR EMAIL
                // var emailService = new EmailService();
                // emailService.Send();
            }
            else if (inventoryItem.CurrentInvetory < (inventoryItem.MinRequired + 20))
            {
                inventoryItem.Status = InventoryStatus.Caution;
                // DESMARCAR PARA ENVIAR EMAIL
                // var emailService = new EmailService();
                // emailService.Send();
            }
            else inventoryItem.Status = InventoryStatus.Ok;

            context.Inventories.Update(inventoryItem);
            context.SaveChanges();

            var exportCsv = new ExportCsv();
            exportCsv.Inventory = inventoryItem;
            var data = exportCsv.ToString();


            File.WriteAllText(@"C:\Users\Public\Documents\hero.csv", data);







        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}