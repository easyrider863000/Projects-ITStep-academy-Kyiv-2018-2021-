using System;
namespace Parts.API.Resources.Resource
{
    public class OrderDetailsResource
    {
        public int Id { get; set; }
        public int IdStatus { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}