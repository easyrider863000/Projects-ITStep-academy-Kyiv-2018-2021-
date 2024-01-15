using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services.Communication
{
    public class AddressPhoneNumberResponse : BaseResponse
    {
        public AddressPhoneNumber AddressPhoneNumber {get; private set;}
        public AddressPhoneNumberResponse(bool success, string message, AddressPhoneNumber addressPhoneNumber) : base(success, message)
        {
            AddressPhoneNumber = addressPhoneNumber;
        }

        public AddressPhoneNumberResponse(AddressPhoneNumber addressPhoneNumber): this(true, string.Empty, addressPhoneNumber){}

        public AddressPhoneNumberResponse(string message): this(false, message, null) {}
       
    }
}