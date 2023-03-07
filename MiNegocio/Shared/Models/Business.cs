﻿
namespace MiNegocio.Shared.Models
{
    public class Business
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public virtual ICollection<Product> Products { get; set; }
        
    }
}
