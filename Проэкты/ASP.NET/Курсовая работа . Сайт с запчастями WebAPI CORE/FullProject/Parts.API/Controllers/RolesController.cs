using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Parts.API.Resources;
using Parts.API.Domain.Models;
using Parts.API.Resources.Resource;
using Parts.API.Domain.Services;

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;
        public RolesController(IRoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }

        [Authorize (Roles="user, admin, manager, director")]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var roles = await roleService.ListAsync();
            var resource = mapper.Map<IEnumerable<Role>,IEnumerable<RoleResource>>(roles);
            var result = new ResponseData
            {
                Data = resource,
                Success = true,
                Message = ""
            };
            return result;
        }
    }
}