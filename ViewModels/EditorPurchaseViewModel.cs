using System.ComponentModel.DataAnnotations;
using DesafioSky.Models;

namespace DesafioSky.ViewModels
{
    public class EditorPurchaseViewModel
    {

        [Required(ErrorMessage = "O produto é obrigatório")]
        public long ProductId { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]

        public string? Address { get; set; }

     


      
    }
}