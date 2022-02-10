using DesafioSky.Models;

namespace DesafioSky.Services;
public class ExportCsv
{
    public ExportCsv() { }
    public ExportCsv(Inventory inventory)
    {
        Inventory = inventory;
    }

    public Inventory Inventory { get; set; }

    public override string ToString()
        => $"{Inventory.Id},{Inventory.Name},{Inventory.Department},{Inventory.ProductId},{Inventory.StartingInventory},{Inventory.CurrentInvetory},{Inventory.InventoryReceived},{Inventory.InventorySold},{Inventory.MinRequired},{Inventory.Status}";


}

