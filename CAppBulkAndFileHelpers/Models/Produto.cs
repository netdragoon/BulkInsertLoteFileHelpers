using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CAppBulkAndFileHelpers.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key()] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int Id { get; set; }

        [Required()]
        [MaxLength(50)]
        public string Description { get; set; }

        public Produto()
        {

        }

        public Produto(string description)
        {
            Description = description;
        }

        public static Produto Create(string description)
        {
            return new Produto(description);
        }
    }
}
