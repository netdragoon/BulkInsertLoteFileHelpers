using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class PeopleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        [MinLength(2, ErrorMessage = "Digite o nome com no minimo 2 letras")]
        [MaxLength(50, ErrorMessage = "Digite o nome com até 50 letras")]
        public string Name { get; set; }
    }
}