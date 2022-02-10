namespace DesafioSky.Models;


    public class Purchase
{
    public int Id { get; set; }

    public long ProductId { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime SendDate { get; set; }

    public DateTime EstimatedDeliveryDate { get; set; }

   

}
