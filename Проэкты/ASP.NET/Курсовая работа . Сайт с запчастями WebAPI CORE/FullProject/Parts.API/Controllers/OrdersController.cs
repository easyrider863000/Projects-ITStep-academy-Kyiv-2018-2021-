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
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var orders = await orderService.ListAsync();
            var resource = mapper.Map<IEnumerable<Order>,IEnumerable<OrderResource>>(orders);
            var result = new ResponseData
            {
                Data = resource,
                Success = true,
                Message = ""
            };
            return result;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var order = mapper.Map<SaveOrderResource, Order>(resource);
            var orderResponse = await orderService.SaveAsync(order);  
            var orderResource = mapper.Map<Order, OrderResource>(orderResponse.Order);
            var result = new ResponseData
            {
                Data = orderResource,
                Message = orderResponse.Message,
                Success = orderResponse.Success
            };
            return Ok(result);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var order = mapper.Map<SaveOrderResource, Order>(resource);
            var result = await orderService.UpdateAsync(id, order);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var orderResource = mapper.Map<Order, OrderResource>(result.Order);
            return Ok(orderResource);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await orderService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var orderResource = mapper.Map<Order, OrderResource>(result.Order);
            return Ok(orderResource);
        }
    }
}