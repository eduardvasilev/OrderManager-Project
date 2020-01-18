using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OrderManager.Services.CommandServices.Models.Order
{
    [DataContract]

    public class CreateOrderServiceModel
    {
        [Required]
        [DataMember(Name = "products")]
        public OrderItemServiceModel[] Products { get; set; }

        [Required]
        [DataMember(Name = "additionalData")]
        public string AdditionalData { get; set; }
        
        [DataMember(Name = "orderDate")]
        public DateTime? OrderDate { get; set; }
        
        public class OrderItemServiceModel
        {
            [DataMember(Name = "productId")]
            public long ProductId { get; set; }
            
            [DataMember(Name = "amount")]
            public long Amount { get; set; }
        }
    }
}