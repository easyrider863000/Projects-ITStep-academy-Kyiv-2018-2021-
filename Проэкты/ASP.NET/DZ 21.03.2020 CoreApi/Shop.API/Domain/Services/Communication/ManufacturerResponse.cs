using Shop.API.Domain.Models;

namespace Shop.API.Domain.Services.Communication
{
    public class ManufacturerResponse : BaseResponse
    {
        public Manufacturer Manufacturer {get; private set;}
        public ManufacturerResponse(bool success, string message, Manufacturer manufacturer) : base(success, message)
        {
            Manufacturer = manufacturer;
        }

        public ManufacturerResponse(Manufacturer manufacturer): this(true, string.Empty, manufacturer){}

        public ManufacturerResponse(string message): this(false, message, null) {}
    }
}