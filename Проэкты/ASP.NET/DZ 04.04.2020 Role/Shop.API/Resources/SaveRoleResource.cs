using System.ComponentModel.DataAnnotations;

namespace Shop.API.Resources
{
    public class SaveRoleResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}