using System.ComponentModel.DataAnnotations;


namespace DesafioSky.ViewModels;

public class EditorInventoryViewModels
{
    [Required(ErrorMessage = "O produto é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O produto é obrigatório")]
    public string Department { get; set; }

     [Required(ErrorMessage = "O produto é obrigatório")]
    public long ProductId { get; set; }

}
