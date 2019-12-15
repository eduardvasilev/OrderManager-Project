namespace OrderManager.DomainModel
{
    public class OrderItem: EntityBase
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public long Amount { get; set; }
    }
}
