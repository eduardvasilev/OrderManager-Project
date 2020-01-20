using System.ComponentModel.DataAnnotations;

namespace OrderManager.Services.CommandServices.Models.Product
{
    public class CreateProductServiceModel
      {
          [Required]
          [StringLength(255)]
          public string Name { get; set; }      
          
          [Required]
          [StringLength(255)]
          public string Description { get; set; }

          public decimal Price { get; set; }
      }
}