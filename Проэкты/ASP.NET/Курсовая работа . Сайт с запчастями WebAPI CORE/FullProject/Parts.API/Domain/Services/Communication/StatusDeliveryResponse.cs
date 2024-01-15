using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services.Communication
{
    public class StatusDeliveryResponse : BaseResponse
    {
        public StatusDelivery StatusDelivery {get; private set;}
        public StatusDeliveryResponse(bool success, string message, StatusDelivery statusDelivery) : base(success, message)
        {
            StatusDelivery = statusDelivery;
        }

        public StatusDeliveryResponse(StatusDelivery statusDelivery): this(true, string.Empty, statusDelivery){}

        public StatusDeliveryResponse(string message): this(false, message, null) {}
       
    }
}