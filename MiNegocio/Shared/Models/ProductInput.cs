using System.ComponentModel.DataAnnotations;

namespace MiNegocio.Shared.Models
{
    public class ProductInput
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
