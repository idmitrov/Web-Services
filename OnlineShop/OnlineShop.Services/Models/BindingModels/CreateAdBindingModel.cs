namespace OnlineShop.Services.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateAdBindingModel
    {
        // NAME
        [Required]
        public string Name { get; set; }
    
        // DESCRIPTION
        public string Description { get; set; }
    
        // TYPE ID
        [Required]
        public int TypeId { get; set; }
    
        // PRICE
        [Required]
        public decimal Price { get; set; }

        // CATEGORIES
        [Required]
        public IEnumerable<int> Categories { get; set; }
    }
}