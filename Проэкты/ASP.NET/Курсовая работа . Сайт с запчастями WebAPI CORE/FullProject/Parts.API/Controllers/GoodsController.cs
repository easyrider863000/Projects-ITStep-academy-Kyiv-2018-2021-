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
    public class GoodsController : Controller
    {
        private readonly IGoodService goodService;
        private readonly IMapper mapper;
        public GoodsController(IGoodService goodService, IMapper mapper)
        {
            this.goodService = goodService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var goods = await goodService.ListAsync();
            var resource = mapper.Map<IEnumerable<Good>,IEnumerable<GoodResource>>(goods);
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
        public async Task<IActionResult> PostAsync([FromBody] SaveGoodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var good = mapper.Map<SaveGoodResource, Good>(resource);
            var goodResponse = await goodService.SaveAsync(good);  
            var goodResource = mapper.Map<Good, GoodResource>(goodResponse.Good);
            var result = new ResponseData
            {
                Data = goodResource,
                Message = goodResponse.Message,
                Success = goodResponse.Success
            };
            return Ok(result);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveGoodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var good = mapper.Map<SaveGoodResource, Good>(resource);
            var result = await goodService.UpdateAsync(id, good);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var goodResource = mapper.Map<Good, GoodResource>(result.Good);
            return Ok(goodResource);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await goodService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var goodResource = mapper.Map<Good, GoodResource>(result.Good);
            return Ok(goodResource);
        }
    }
}