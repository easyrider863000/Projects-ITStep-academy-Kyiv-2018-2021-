using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Parts.API.Domain.Services;
using Parts.API.Resources;
using Parts.API.Domain.Models;
using Parts.API.Extensions;
using Parts.API.Resources.Resource;
using Parts.API.Resources.SaveResource;
using System.Linq;
using System.Security.Claims;

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;
        private readonly IMapper mapper;
        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var suppliers = await supplierService.ListAsync();
            var resource = mapper.Map<IEnumerable<Supplier>,IEnumerable<SupplierResource>>(suppliers);
            var result = new ResponseData
            {
                Data = resource,
                Success = true,
                Message = ""
            };
            return result;
        }
        [Authorize (Roles="admin, manager, director")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSupplierResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supplier = mapper.Map<SaveSupplierResource, Supplier>(resource);
            var supplierResponse = await supplierService.SaveAsync(supplier);  
            var supplierResource = mapper.Map<Supplier, SupplierResource>(supplierResponse.Supplier);
            var result = new ResponseData
            {
                Data = supplierResource,
                Message = supplierResponse.Message,
                Success = supplierResponse.Success
            };
            return Ok(result);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupplierResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supplier = mapper.Map<SaveSupplierResource, Supplier>(resource);
            var result = await supplierService.UpdateAsync(id, supplier);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var supplierResource = mapper.Map<Supplier, SupplierResource>(result.Supplier);
            return Ok(supplierResource);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await supplierService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var supplierResource = mapper.Map<Supplier, SupplierResource>(result.Supplier);
            return Ok(supplierResource);
        }
        

        [Authorize (Roles="admin, manager, director")]
        [HttpGet("address/{id}")]
        public async Task<ResponseData> GetAddressAsync(int id)
        {
            var address = await supplierService.GetAddressAsync(id);
            IEnumerable<AddressResource> resource = null;
            var msg = "Not Available";
            var success = false;
            if(address!=null){
                resource = mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(address);
                msg = "";
                success = true;
            }
            var result = new ResponseData
            {
                Data = resource,
                Message = msg,
                Success = success
            };
            return result;
        }
        

        
        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("address/{supplierId}/{addressId}")]
        public async Task<IActionResult> DeleteAddressAsync(int supplierId,int addressId)
        {
            var result = await supplierService.DeleteAddressAsync(supplierId, addressId);
            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<Address, AddressResource>(result.Address);
            return Ok(clientResource);
        }


        

        [Authorize (Roles="admin, manager, director")]
        [HttpPost("address/{id}")]
        public async Task<IActionResult> PostAddressAsync(int id, [FromBody] SaveAddressResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var address = mapper.Map<SaveAddressResource, Address>(resource);
            var result = await supplierService.SaveAddressAsync(id, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<Address, AddressResource>(result.Address);
            return Ok(addressResource);
        }

        

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("address/{supplierId}/{addressId}")]
        public async Task<IActionResult> PutAddressAsync(int supplierId, int addressId, [FromBody] SaveAddressResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var address = mapper.Map<SaveAddressResource, Address>(resource);
            var result = await supplierService.UpdateAddressAsync(supplierId, addressId, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<Address, AddressResource>(result.Address);
            return Ok(addressResource);
        }










        [Authorize (Roles="admin, manager, director")]
        [HttpGet("addressmail/{supplierId}/{addressId}")]
        public async Task<ResponseData> GetAddressMailAsync(int supplierId, int addressId)
        {
            var address = await supplierService.GetAddressMailAsync(supplierId, addressId);
            IEnumerable<AddressMailResource> resource = null;
            var msg = "Not Available";
            var success = false;
            if(address!=null){
                resource = mapper.Map<IEnumerable<AddressMail>, IEnumerable<AddressMailResource>>(address);
                msg = "";
                success = true;
            }
            var result = new ResponseData
            {
                Data = resource,
                Message = msg,
                Success = success
            };
            return result;
        }

        
        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("addressmail/{supplierId}/{addressId}/{mailId}")]
        public async Task<IActionResult> DeleteAddressMailAsync(int supplierId, int addressId, int mailId)
        {
            var result = await supplierService.DeleteAddressMailAsync(addressId, mailId);
            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<AddressMail, AddressMailResource>(result.AddressMail);
            return Ok(clientResource);
        }


        

        [Authorize (Roles="admin, manager, director")]
        [HttpPost("addressmail/{addressId}")]
        public async Task<IActionResult> PostAddressMailAsync(int addressId, [FromBody] SaveAddressMailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var mails = mapper.Map<SaveAddressMailResource, AddressMail>(resource);
            var result = await supplierService.SaveAddressMailAsync(addressId, mails);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressMail, AddressMailResource>(result.AddressMail);
            return Ok(addressResource);
        }

        

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("addressmail/{supplierId}/{addressId}/{mailId}")]
        public async Task<IActionResult> PutAddressMailAsync(int supplierId, int addressId, int mailId, [FromBody] SaveAddressMailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var address = mapper.Map<SaveAddressMailResource, AddressMail>(resource);
            var result = await supplierService.UpdateAddressMailAsync(supplierId, addressId, mailId, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressMail, AddressMailResource>(result.AddressMail);
            return Ok(addressResource);
        }










        [Authorize (Roles="admin, manager, director")]
        [HttpGet("addressphone/{supplierId}/{addressId}")]
        public async Task<ResponseData> GetAddressPhoneAsync(int supplierId, int addressId)
        {
            var address = await supplierService.GetAddressPhoneAsync(supplierId, addressId);
            IEnumerable<AddressPhoneNumberResource> resource = null;
            var msg = "Not Available";
            var success = false;
            if(address!=null){
                resource = mapper.Map<IEnumerable<AddressPhoneNumber>, IEnumerable<AddressPhoneNumberResource>>(address);
                msg = "";
                success = true;
            }
            var result = new ResponseData
            {
                Data = resource,
                Message = msg,
                Success = success
            };
            return result;
        }

        
        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("addressphone/{supplierId}/{addressId}/{phoneId}")]
        public async Task<IActionResult> DeleteAddressPhoneAsync(int supplierId, int addressId, int phoneId)
        {
            var result = await supplierService.DeleteAddressPhoneAsync(addressId, phoneId);
            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<AddressPhoneNumber, AddressPhoneNumberResource>(result.AddressPhoneNumber);
            return Ok(clientResource);
        }


        

        [Authorize (Roles="admin, manager, director")]
        [HttpPost("addressphone/{addressId}")]
        public async Task<IActionResult> PostAddressPhoneAsync(int addressId, [FromBody] SaveAddressPhoneNumberResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var phones = mapper.Map<SaveAddressPhoneNumberResource, AddressPhoneNumber>(resource);
            var result = await supplierService.SaveAddressPhoneAsync(addressId, phones);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressPhoneNumber, AddressPhoneNumberResource>(result.AddressPhoneNumber);
            return Ok(addressResource);
        }

        

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("addressphone/{supplierId}/{addressId}/{phoneId}")]
        public async Task<IActionResult> PutAddressPhoneAsync(int supplierId, int addressId, int phoneId, [FromBody] SaveAddressPhoneNumberResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var address = mapper.Map<SaveAddressPhoneNumberResource, AddressPhoneNumber>(resource);
            var result = await supplierService.UpdateAddressPhoneAsync(supplierId, addressId, phoneId, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressPhoneNumber, AddressPhoneNumberResource>(result.AddressPhoneNumber);
            return Ok(addressResource);
        }
    }
}