using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OrderManager.Services.ReadServices.Models.Product
{
    [DataContract]
    public class ProductServiceModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }      
          
        [DataMember(Name = "description")]
        public string Description { get; set; }     
    }
}