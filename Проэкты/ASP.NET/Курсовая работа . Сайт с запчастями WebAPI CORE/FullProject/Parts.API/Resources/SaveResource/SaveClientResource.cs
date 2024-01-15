using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources.SaveResource
{
    public class SaveClientResource
    {
        [Required]
        [MaxLength(100)]
        public string Name{get;set;}
        [Required]
        [MaxLength(100)]
        public string SurName{get;set;}
        public string Description{get;set;}
        [Required]
        [MaxLength(100)]
        public string Login { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        public int IdRole{get;set;}
    }
}