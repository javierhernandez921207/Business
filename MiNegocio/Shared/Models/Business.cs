namespace MiNegocio.Shared.Models
{
    public class Business
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public List<Product> Products { get; set; }
        public Business()
        {
            Products = new List<Product>();
        }
    }
}
