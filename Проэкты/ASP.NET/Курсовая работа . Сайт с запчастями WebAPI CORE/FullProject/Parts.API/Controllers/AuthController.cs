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

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController: Controller
    {
        private readonly IAuthService clientService;
        private readonly IMapper mapper;
        public AuthController(IAuthService clientService, IMapper mapper)
        {
            this.clientService = clientService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthClientResource client)
        {
            var clientA = await clientService.Authenticate(client.Login, client.Password);
            var result = mapper.Map<Client, ClientResource>(clientA);
            var response = new ResponseData
            {
                Success = result != null,
                Message = result != null ? "" : "Incorrect login or password",
                Data = result
            };

            return Ok(response);
        }
    }
}