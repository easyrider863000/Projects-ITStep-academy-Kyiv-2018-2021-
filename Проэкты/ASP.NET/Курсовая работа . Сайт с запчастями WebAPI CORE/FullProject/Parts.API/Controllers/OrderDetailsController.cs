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

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsService orderDetailsService;
        private readonly IMapper mapper;
        public OrderDetailsController(IOrderDetailsService orderDetailsService, IMapper mapper)
        {
            this.orderDetailsService = orderDetailsService;
            this.mapper = mapper;
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var orderDetailss = await orderDetailsService.ListAsync();
            var resource = mapper.Map<IEnumerable<OrderDetails>,IEnumerable<OrderDetailsResource>>(orderDetailss);
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
        public async Task<IActionResult> PostAsync([FromBody] SaveOrderDetailsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var orderDetails = mapper.Map<SaveOrderDetailsResource, OrderDetails>(resource);
            var orderDetailsResponse = await orderDetailsService.SaveAsync(orderDetails);  
            var orderDetailsResource = mapper.Map<OrderDetails, OrderDetailsResource>(orderDetailsResponse.OrderDetails);
            var result = new ResponseData
            {
                Data = orderDetailsResource,
                Message = orderDetailsResponse.Message,
                Success = orderDetailsResponse.Success
            };
            return Ok(result);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderDetailsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var orderDetails = mapper.Map<SaveOrderDetailsResource, OrderDetails>(resource);
            var result = await orderDetailsService.UpdateAsync(id, orderDetails);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var orderDetailsResource = mapper.Map<OrderDetails, OrderDetailsResource>(result.OrderDetails);
            return Ok(orderDetailsResource);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await orderDetailsService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var orderDetailsResource = mapper.Map<OrderDetails, OrderDetailsResource>(result.OrderDetails);
            return Ok(orderDetailsResource);
        }
    }
}