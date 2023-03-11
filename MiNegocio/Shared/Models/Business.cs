
using System.ComponentModel.DataAnnotations;

namespace MiNegocio.Shared.Models
{
    public class Business
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();       
        public decimal TotalCost() {
            return Products.Sum(p => p.Cost * p.Amount);
        }
        public decimal TotalSale() { 
            return Products.Sum(p => p.Price * p.Amount);
        }
        public decimal TotalRevenue() { 
            return TotalSale() - TotalCost();
        }
    }
}
