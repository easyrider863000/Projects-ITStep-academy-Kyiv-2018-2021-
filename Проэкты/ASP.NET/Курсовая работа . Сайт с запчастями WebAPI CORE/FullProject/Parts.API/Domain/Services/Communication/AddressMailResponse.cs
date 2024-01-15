using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services.Communication
{
    public class AddressMailResponse : BaseResponse
    {
        public AddressMail AddressMail {get; private set;}
        public AddressMailResponse(bool success, string message, AddressMail addressMail) : base(success, message)
        {
            AddressMail = addressMail;
        }

        public AddressMailResponse(AddressMail addressMail): this(true, string.Empty, addressMail){}

        public AddressMailResponse(string message): this(false, message, null) {}
       
    }
}