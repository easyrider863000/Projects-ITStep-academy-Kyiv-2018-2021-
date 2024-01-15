using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(2048)]
        public string PhotoPath{get;set;}
    }
}