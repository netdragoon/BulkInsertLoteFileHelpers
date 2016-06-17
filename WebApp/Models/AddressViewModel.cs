using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o estado")]
        [MinLength(2, ErrorMessage = "Digite o estado com duas letras")]
        [MaxLength(2, ErrorMessage = "Digite o estado com duas letras")]
        public string State { get; set; }

        [Required(ErrorMessage = "Digite a cidade")]
        [MinLength(3, ErrorMessage = "Digite a cidade com no minimo 3 letras")]
        [MaxLength(50, ErrorMessage = "Digite a cidade no máximo 50 letras")]
        public string City { get; set; }
    }
}