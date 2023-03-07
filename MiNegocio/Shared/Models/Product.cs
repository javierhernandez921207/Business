using System.ComponentModel.DataAnnotations.Schema;

namespace MiNegocio.Shared.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public decimal Cost { get; set; } = decimal.Zero;
        public int Amount { get; set; }
        public int AmountC { get; set; }        
        public Guid? BusinessId { get; set; }        
        public virtual Business? Business { get; set; }
    }
}
