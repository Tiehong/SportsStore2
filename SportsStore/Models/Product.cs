using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace SportsStore.Models {

    public class Product {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a product description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a product price")]
        [Range(0.01, 100000, ErrorMessage = "Please enter a valid price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter a product category")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
