using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources.SaveResource
{
    public class SaveAddressPhoneNumberResource
    {
        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
    }
}