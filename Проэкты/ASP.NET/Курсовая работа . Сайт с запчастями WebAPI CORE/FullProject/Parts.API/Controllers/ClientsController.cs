using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services;
using Parts.API.Extensions;
using Parts.API.Resources;
using Parts.API.Resources.Resource;
using Parts.API.Resources.SaveResource;

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientService clientService;
        private readonly IMapper mapper;
        public ClientsController(IClientService clientService, IMapper mapper)
        {
            this.clientService = clientService;
            this.mapper = mapper;
        }

        [Authorize (Roles="admin, director")]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync()
        {
            var clients = await clientService.ListAsync();
            var resource = mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            var result = new ResponseData
            {
                Data = resource,
                Message = "",
                Success = true
            };
            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var client = mapper.Map<SaveClientResource, Client>(resource);
            var result = await clientService.SaveAsync(client);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<Client, ClientResource>(result.Client);
            return Ok(clientResource);
        }

        [Authorize (Roles="admin, manager, director, user")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(id,NameIdentifire))){
                return BadRequest("Not done");
            }

            var client = mapper.Map<SaveClientResource, Client>(resource);
            var result = await clientService.UpdateAsync(id, client);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<Client, ClientResource>(result.Client);
            return Ok(clientResource);
        }
        [Authorize (Roles="admin, manager, director, user")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(id,NameIdentifire))){
                return BadRequest("Not done");
            }
            var result = await clientService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<Client, ClientResource>(result.Client);
            return Ok(clientResource);
        }


        [Authorize]
        [HttpGet("address/{id}")]
        public async Task<ResponseData> GetAddressAsync(int id)
        {
            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            var address = await clientService.GetAddressAsync(id, NameIdentifire);
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

        
        [Authorize]
        [HttpDelete("address/{clientId}/{addressId}")]
        public async Task<IActionResult> DeleteAddressAsync(int clientId,int addressId)
        {
            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientId,NameIdentifire))){
                return BadRequest("Not done");
            }
            var result = await clientService.DeleteAddressAsync(clientId, addressId);
            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<Address, AddressResource>(result.Address);
            return Ok(clientResource);
        }


        

        [Authorize]
        [HttpPost("address/{id}")]
        public async Task<IActionResult> PostAddressAsync(int id, [FromBody] SaveAddressResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(id,NameIdentifire))){
                return BadRequest("Not done");
            }

            var address = mapper.Map<SaveAddressResource, Address>(resource);
            var result = await clientService.SaveAddressAsync(id, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<Address, AddressResource>(result.Address);
            return Ok(addressResource);
        }

        

        [Authorize]
        [HttpPut("address/{clientId}/{addressId}")]
        public async Task<IActionResult> PutAddressAsync(int clientId, int addressId, [FromBody] SaveAddressResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientId,NameIdentifire))){
                return BadRequest("Not done");
            }

            var address = mapper.Map<SaveAddressResource, Address>(resource);
            var result = await clientService.UpdateAddressAsync(clientId, addressId, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<Address, AddressResource>(result.Address);
            return Ok(addressResource);
        }


        [Authorize]
        [HttpGet("addressphone/{clientId}/{addressId}")]
        public async Task<ResponseData> GetAddressPhoneAsync(int clientId, int addressId)
        {
            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            var address = await clientService.GetAddressPhoneAsync(clientId, addressId, NameIdentifire);
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

        
        [Authorize]
        [HttpDelete("addressphone/{clientId}/{addressId}/{phoneId}")]
        public async Task<IActionResult> DeleteAddressPhoneAsync(int clientId,int addressId, int phoneId)
        {
            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientId,NameIdentifire))){
                return BadRequest("Not done");
            }
            var result = await clientService.DeleteAddressPhoneAsync(clientId, addressId, phoneId);
            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<AddressPhoneNumber, AddressPhoneNumberResource>(result.AddressPhoneNumber);
            return Ok(clientResource);
        }


        

        [Authorize]
        [HttpPost("addressphone/{clientid}/{addressId}")]
        public async Task<IActionResult> PostAddressPhoneAsync(int clientid, int addressId, [FromBody] SaveAddressPhoneNumberResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientid,NameIdentifire))){
                return BadRequest("Not done");
            }

            var phones = mapper.Map<SaveAddressPhoneNumberResource, AddressPhoneNumber>(resource);
            var result = await clientService.SaveAddressPhoneAsync(addressId, phones);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressPhoneNumber, AddressPhoneNumberResource>(result.AddressPhoneNumber);
            return Ok(addressResource);
        }

        

        [Authorize]
        [HttpPut("addressphone/{clientId}/{addressId}/{phoneId}")]
        public async Task<IActionResult> PutAddressPhoneAsync(int clientId, int addressId, int phoneId, [FromBody] SaveAddressPhoneNumberResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientId,NameIdentifire))){
                return BadRequest("Not done");
            }

            var address = mapper.Map<SaveAddressPhoneNumberResource, AddressPhoneNumber>(resource);
            var result = await clientService.UpdateAddressPhoneAsync(clientId, addressId, phoneId, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressPhoneNumber, AddressPhoneNumberResource>(result.AddressPhoneNumber);
            return Ok(addressResource);
        }


        [Authorize]
        [HttpGet("addressmail/{clientId}/{addressId}")]
        public async Task<ResponseData> GetAddressMailAsync(int clientId, int addressId)
        {
            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            var address = await clientService.GetAddressMailAsync(clientId, addressId, NameIdentifire);
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

        
        [Authorize]
        [HttpDelete("addressmail/{clientId}/{addressId}/{mailId}")]
        public async Task<IActionResult> DeleteAddressMailAsync(int clientId,int addressId, int mailId)
        {
            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientId,NameIdentifire))){
                return BadRequest("Not done");
            }
            var result = await clientService.DeleteAddressMailAsync(clientId, addressId, mailId);
            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = mapper.Map<AddressMail, AddressMailResource>(result.AddressMail);
            return Ok(clientResource);
        }


        

        [Authorize]
        [HttpPost("addressmail/{clientid}/{addressId}")]
        public async Task<IActionResult> PostAddressMailAsync(int clientid, int addressId, [FromBody] SaveAddressMailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientid,NameIdentifire))){
                return BadRequest("Not done");
            }

            var mails = mapper.Map<SaveAddressMailResource, AddressMail>(resource);
            var result = await clientService.SaveAddressMailAsync(addressId, mails);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressMail, AddressMailResource>(result.AddressMail);
            return Ok(addressResource);
        }

        

        [Authorize]
        [HttpPut("addressmail/{clientId}/{addressId}/{mailId}")]
        public async Task<IActionResult> PutAddressMailAsync(int clientId, int addressId, int mailId, [FromBody] SaveAddressMailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var NameIdentifire = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            if(!(await clientService.IsClientSafety(clientId,NameIdentifire))){
                return BadRequest("Not done");
            }

            var address = mapper.Map<SaveAddressMailResource, AddressMail>(resource);
            var result = await clientService.UpdateAddressMailAsync(clientId, addressId, mailId, address);

            if (!result.Success)
                return BadRequest(result.Message);

            var addressResource = mapper.Map<AddressMail, AddressMailResource>(result.AddressMail);
            return Ok(addressResource);
        }
    }
}