using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources.SaveResource
{
    public class SaveAddressMailResource
    {
        [Required]
        [MaxLength(50)]
        public string Mail { get; set; }
    }
}