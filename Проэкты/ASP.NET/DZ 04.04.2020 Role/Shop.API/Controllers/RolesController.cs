using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services;
using Shop.API.Resources;
using Shop.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Shop.API.Controllers
{

    [Authorize]
    [Route("/api/roles")]
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;
        public RolesController(IRoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }

       
        [HttpGet]
        public async Task<IEnumerable<RoleResource>> GetAllAsync() 
        {
            var roles = await roleService.ListAsync();
            var resource = mapper.Map<IEnumerable<Role>,IEnumerable<RoleResource>>(roles);
            return resource;
        }
    
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var role = mapper.Map<SaveRoleResource, Role>(resource);
            var result = await roleService.SaveAsync(role);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var roleResource = mapper.Map<Role, RoleResource>(result.Role);
            return Ok(roleResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var role = mapper.Map<SaveRoleResource, Role>(resource);
            var result = await roleService.UpdateAsync(id, role);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var roleResource = mapper.Map<Role, RoleResource>(result.Role);
            return Ok(roleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await roleService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var roleResource = mapper.Map<Role, RoleResource>(result.Role);
            return Ok(roleResource);
        }
    }
}