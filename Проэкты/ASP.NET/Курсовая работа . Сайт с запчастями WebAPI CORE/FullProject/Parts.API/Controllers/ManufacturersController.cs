using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Parts.API.Domain.Services;
using Parts.API.Resources;
using Parts.API.Domain.Models;
using Parts.API.Extensions;

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService manufacturerService;
        private readonly IMapper mapper;
        public ManufacturersController(IManufacturerService manufacturerService, IMapper mapper)
        {
            this.manufacturerService = manufacturerService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var manufacturers = await manufacturerService.ListAsync();
            var resource = mapper.Map<IEnumerable<Manufacturer>,IEnumerable<ManufacturerResource>>(manufacturers);
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
        public async Task<IActionResult> PostAsync([FromBody] SaveManufacturerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var manufacturer = mapper.Map<SaveManufacturerResource, Manufacturer>(resource);
            var manufacturerResponse = await manufacturerService.SaveAsync(manufacturer);  
            var manufacturerResource = mapper.Map<Manufacturer, ManufacturerResource>(manufacturerResponse.Manufacturer);
            var result = new ResponseData
            {
                Data = manufacturerResource,
                Message = manufacturerResponse.Message,
                Success = manufacturerResponse.Success
            };
            return Ok(result);
        }

        [Authorize (Roles="admin, manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveManufacturerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var manufacturer = mapper.Map<SaveManufacturerResource, Manufacturer>(resource);
            var result = await manufacturerService.UpdateAsync(id, manufacturer);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var manufacturerResource = mapper.Map<Manufacturer, ManufacturerResource>(result.Manufacturer);
            return Ok(manufacturerResource);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await manufacturerService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var manufacturerResource = mapper.Map<Manufacturer, ManufacturerResource>(result.Manufacturer);
            return Ok(manufacturerResource);
        }
    }
}