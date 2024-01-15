using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services;
using Shop.API.Resources;
using Shop.API.Extensions;

namespace Shop.API.Controllers
{
    [Route("/api/manufacturers")]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService manufacturerService;
        private readonly IMapper mapper;
        public ManufacturersController(IManufacturerService manufacturerService, IMapper mapper)
        {
            this.manufacturerService = manufacturerService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<ManufacturerResource>> GetAllAsync() 
        {
            var manufacturers = await manufacturerService.ListAsync();
            var resource = mapper.Map<IEnumerable<Manufacturer>,IEnumerable<ManufacturerResource>>(manufacturers);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveManufacturerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var manufacturer = mapper.Map<SaveManufacturerResource, Manufacturer>(resource);
            var result = await manufacturerService.SaveAsync(manufacturer);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var manufacturerResource = mapper.Map<Manufacturer, ManufacturerResource>(result.Manufacturer);
            return Ok(manufacturerResource);
        }

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