using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiNegocio.Shared.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; } = decimal.Zero;
        [Required]
        public decimal Cost { get; set; } = decimal.Zero;
        [Required]
        public int Amount { get; set; }
        [Required]
        public int AmountC { get; set; }        
        public Guid? BusinessId { get; set; }        
        public virtual Business? Business { get; set; }
        public virtual ICollection<ProductInput> Inputs { get; set; } = new List<ProductInput>();
    }
}
