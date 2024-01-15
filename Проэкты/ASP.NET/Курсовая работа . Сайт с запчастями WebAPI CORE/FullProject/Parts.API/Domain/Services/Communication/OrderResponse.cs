using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services.Communication
{
    public class OrderResponse : BaseResponse
    {
        public Order Order {get; private set;}
        public OrderResponse(bool success, string message, Order order) : base(success, message)
        {
            Order = order;
        }

        public OrderResponse(Order order): this(true, string.Empty, order){}

        public OrderResponse(string message): this(false, message, null) {}
       
    }
}