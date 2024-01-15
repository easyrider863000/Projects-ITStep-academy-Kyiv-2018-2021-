using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services.Communication
{
    public class AddressResponse : BaseResponse
    {
        public Address Address {get; private set;}
        public AddressResponse(bool success, string message, Address address) : base(success, message)
        {
            Address = address;
        }

        public AddressResponse(Address address): this(true, string.Empty, address){}

        public AddressResponse(string message): this(false, message, null) {}
       
    }
}