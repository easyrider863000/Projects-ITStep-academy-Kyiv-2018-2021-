using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources.SaveResource
{
    public class SaveGoodResource
    {
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Number { get; set; }
        public string Description { get; set; }
        
        [Required]
        public int IdManufacturer { get; set; }

        [Required]
        public int IdCategory { get; set; }
        
        [Required]
        public int IdSupplier { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        public bool? IsBeating { get; set; }
        public bool? IsLiquid { get; set; }
        public string PhotoPath { get; set; }
    }
}