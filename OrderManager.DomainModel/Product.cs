namespace OrderManager.DomainModel
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public byte[] Picture { get; set; }
    }
}
