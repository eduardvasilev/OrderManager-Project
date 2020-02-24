using System;

namespace OrderManager.Services.ReadServices.Models.Order
{
    public class OrderServiceModel
    {
        public long Id { get; set; }

        public DateTime CreationDate { get; set; }

        public long StatusId { get; set; }

        public string AdditionalData { get; set; }

    }
}