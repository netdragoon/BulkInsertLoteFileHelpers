using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class PhoneViewModel
    {
        public int Id { get; set; }
        public int? PeopleId { get; set; }

        [Required(ErrorMessage = "Digite o DDD")]
        [MinLength(3, ErrorMessage = "Digite o DDD com 3 digitos")]
        [MaxLength(3, ErrorMessage = "Digite o DDD com 3 digitos")]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "Digite o DDD")]
        [MinLength(9, ErrorMessage = "Digite o DDD com no mínimo 9 digitos")]
        [MaxLength(14, ErrorMessage = "Digite o DDD com no máximo 14 digitos")]
        public string Number { get; set; }
    }
}