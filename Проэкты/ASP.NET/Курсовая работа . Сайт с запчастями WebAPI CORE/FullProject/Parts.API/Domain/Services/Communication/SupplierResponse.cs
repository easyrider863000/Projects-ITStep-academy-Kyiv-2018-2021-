using Parts.API.Domain.Models;

namespace Parts.API.Domain.Services.Communication
{
    public class SupplierResponse : BaseResponse
    {
        public Supplier Supplier {get; private set;}
        public SupplierResponse(bool success, string message, Supplier supplier) : base(success, message)
        {
            Supplier = supplier;
        }

        public SupplierResponse(Supplier supplier): this(true, string.Empty, supplier){}

        public SupplierResponse(string message): this(false, message, null) {}
       
    }
}