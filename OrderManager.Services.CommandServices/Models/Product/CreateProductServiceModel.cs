using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OrderManager.Services.CommandServices.Models.Product
{
      [DataContract]
      public class CreateProductServiceModel
      {
          [Required]
          [StringLength(255)]
          [DataMember(Name = "name")]
          public string Name { get; set; }      
          
          [Required]
          [StringLength(255)]
          [DataMember(Name = "description")]
          public string Description { get; set; }

          [DataMember(Name = "price")]
          public decimal Price { get; set; }
      }
}