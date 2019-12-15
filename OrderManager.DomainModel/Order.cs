using System;
using System.Collections.Generic;

namespace OrderManager.DomainModel
{
    public class Order : EntityBase
    {
        public DateTime CreationDate { get; set; }
        
        public DateTime OrderDate { get; set; }

        public string AdditionalData { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public long StatusId { get; set; }

        public OrderStatus GetStatus()
        {
            return (OrderStatus) StatusId;
        }

        public void SetStatus(OrderStatus status)
        {
            StatusId = (long) status;
        }
    }
}
