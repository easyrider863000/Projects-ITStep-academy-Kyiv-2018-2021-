using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services.Communication
{
    public class OrderDetailsResponse : BaseResponse
    {
        public OrderDetails OrderDetails {get; private set;}
        public OrderDetailsResponse(bool success, string message, OrderDetails orderDetails) : base(success, message)
        {
            OrderDetails = orderDetails;
        }

        public OrderDetailsResponse(OrderDetails orderDetails): this(true, string.Empty, orderDetails){}

        public OrderDetailsResponse(string message): this(false, message, null) {}
       
    }
}