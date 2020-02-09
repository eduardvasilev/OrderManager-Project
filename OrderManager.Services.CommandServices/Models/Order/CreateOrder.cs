using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.Services.CommandServices.Models.Order
{
    public class CreateOrder
    {
        [Required]
        public OrderItemServiceModel[] Products { get; set; }

        [Required]
        public string AdditionalData { get; set; }
        
        public DateTime? OrderDate { get; set; }
        
        public class OrderItemServiceModel
        {
            public long ProductId { get; set; }
            
            public long Amount { get; set; }
        }
    }
}