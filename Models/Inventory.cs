using DesafioSky.Models.Enums;

namespace DesafioSky.Models;


    public class Inventory
{

    public int Id { get; set; }

    public long ProductId { get; set; }
    public string Name { get; set; }

    public string Department { get; set; }

    public int StartingInventory { get; set; }

    public int CurrentInvetory { get; set; }

    public int InventoryReceived { get; set; }

    public int InventorySold { get; set; }

    public int MinRequired { get; set; }

    public InventoryStatus Status { get; set; }

  

}
