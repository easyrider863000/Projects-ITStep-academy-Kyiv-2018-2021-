namespace Parts.API.Resources.Resource
{
    public class GoodResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int IdManufacturer { get; set; }
        public int IdCategory { get; set; }
        public int IdSupplier { get; set; }
        public decimal Price { get; set; }
        public bool? IsBeating { get; set; }
        public bool? IsLiquid { get; set; }
        public string PhotoPath { get; set; }
    }
}