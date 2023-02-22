namespace GTR_Assign.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Price { get; set; }

        public int? Quantity { get; set; }

        public string? Quality { get; set; }

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}
