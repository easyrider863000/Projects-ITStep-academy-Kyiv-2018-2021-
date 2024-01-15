using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources.SaveResource
{
    public class SaveStatusDeliveryResource
    {
        [Required]
        [MaxLength(50)]
        public string Name{get;set;}
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}