using System.ComponentModel.DataAnnotations;

namespace Parts.API.Resources
{
    public class SaveOrderResource
    {
        [Required]
        public int IdClient { get; set; }
        [Required]
        public int IdGood { get; set; }
        public decimal Count { get; set; }
        [Required]
        public int IdOrderDetails { get; set; }
    }
}