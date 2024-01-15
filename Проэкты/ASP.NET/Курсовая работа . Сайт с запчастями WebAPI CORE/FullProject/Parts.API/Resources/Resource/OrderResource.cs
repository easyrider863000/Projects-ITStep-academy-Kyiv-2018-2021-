namespace Parts.API.Resources
{
    public class OrderResource
    {
        public int Id{get;set;}
        public int IdClient { get; set; }
        public int IdGood { get; set; }
        public float? Count { get; set; }
        public int IdOrderDetails { get; set; }

    }
}