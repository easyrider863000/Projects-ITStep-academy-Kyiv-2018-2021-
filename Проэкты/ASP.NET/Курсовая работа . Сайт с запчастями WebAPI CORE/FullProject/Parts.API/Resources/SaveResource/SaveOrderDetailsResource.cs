using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources
{
    public class SaveOrderDetailsResource
    {
        [Required]
        public int IdStatus { get; set; }
        public string OrderDate {get;set;}
    }
}