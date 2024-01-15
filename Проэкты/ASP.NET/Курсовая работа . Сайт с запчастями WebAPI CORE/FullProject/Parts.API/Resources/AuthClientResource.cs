using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources
{
    public class AuthClientResource
    {
        [Required]
        [MaxLength(100)]
        public string Login { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}