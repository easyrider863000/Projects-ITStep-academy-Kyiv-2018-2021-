using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources.SaveResource
{
    public class SaveAddressResource
    {
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(100)]
        public string House { get; set; }
        [MaxLength(100)]
        public string Flat { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}