using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OrderManager.Services.ReadServices.Models.Product
{
    [DataContract]
    public class ProductServiceModel
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(255)]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [StringLength(500)]
        [DataMember(Name = "description")]
        public string Description { get; set; }     
    }
}