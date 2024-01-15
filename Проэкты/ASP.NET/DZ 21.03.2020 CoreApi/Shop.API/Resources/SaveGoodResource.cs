using System.ComponentModel.DataAnnotations;

namespace Shop.API.Resources
{
    public class SaveGoodResource
    {
        [Required]
        [MaxLength(50)]
        public string GoodName { get; set; }
        [Required]
        public int GoodCount { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
    }
}