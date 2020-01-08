using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OrderManager.Services.ReadServices.Models.Product
{
    [DataContract]
    public class ProductServiceModel
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }      
          
        [DataMember(Name = "description")]
        public string Description { get; set; }     
    }
}