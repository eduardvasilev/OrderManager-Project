using System.Runtime.Serialization;

namespace OrderManager.Services.CommandServices.Models.Order
{
    [DataContract]
    public class CreateOrderResponse
    {
        [DataMember(Name = "orderId")]
        public long OrderId { get; set; }     
    }
}