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

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class StatusesDeliveryController : Controller
    {
        private readonly IStatusDeliveryService statusDeliveryService;
        private readonly IMapper mapper;
        public StatusesDeliveryController(IStatusDeliveryService statusDeliveryService, IMapper mapper)
        {
            this.statusDeliveryService = statusDeliveryService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var statusesDelivery = await statusDeliveryService.ListAsync();
            var resource = mapper.Map<IEnumerable<StatusDelivery>,IEnumerable<StatusDeliveryResource>>(statusesDelivery);
            var result = new ResponseData
            {
                Data = resource,
                Success = true,
                Message = ""
            };
            return result;
        }
        [Authorize (Roles="admin, manager")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStatusDeliveryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var statusDelivery = mapper.Map<SaveStatusDeliveryResource, StatusDelivery>(resource);
            var statusDeliveryResponse = await statusDeliveryService.SaveAsync(statusDelivery);  
            var statusDeliveryResource = mapper.Map<StatusDelivery, StatusDeliveryResource>(statusDeliveryResponse.StatusDelivery);
            var result = new ResponseData
            {
                Data = statusDeliveryResource,
                Message = statusDeliveryResponse.Message,
                Success = statusDeliveryResponse.Success
            };
            return Ok(result);
        }

        [Authorize (Roles="admin, manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStatusDeliveryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var statusDelivery = mapper.Map<SaveStatusDeliveryResource, StatusDelivery>(resource);
            var result = await statusDeliveryService.UpdateAsync(id, statusDelivery);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var statusDeliveryResource = mapper.Map<StatusDelivery, StatusDeliveryResource>(result.StatusDelivery);
            return Ok(statusDeliveryResource);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await statusDeliveryService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var statusDeliveryResource = mapper.Map<StatusDelivery, StatusDeliveryResource>(result.StatusDelivery);
            return Ok(statusDeliveryResource);
        }
    }
}